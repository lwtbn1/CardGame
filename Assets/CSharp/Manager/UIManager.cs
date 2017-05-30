//**********************************************************************
// Name:        
// Author:      
// Version:     
// Date:        
// Description: 
//**********************************************************************
using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using LuaInterface;
public class UIManager : MonoBehaviour
{
    string curOpenPanel;
    Dictionary<string, GameObject> panelCache = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> popupsCache = new Dictionary<string, GameObject>();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="bundleName"></param>
    /// <param name="panelName"></param>
    /// <param name="func"></param>
    /// <param name="syn"></param>
    public void PushPanel(string bundleName, string panelName, LuaTable table)
    {
        curOpenPanel = panelName;
        if (panelCache.ContainsKey(panelName))
        {
            GameObject willShowPanel = null;
            panelCache.TryGetValue(panelName, out willShowPanel);
            if (willShowPanel != null)
                willShowPanel.SetActive(true);
            LuaFunction func = table.GetLuaFunction("Enable");
            if (func != null)
                func.Call(willShowPanel);
        }
        else
        {
            ResManager resMgr = GameManager.Instance.GetManager<ResManager>("ResManager");
            resMgr.LoadPanelAsyn(bundleName, panelName, (obj)=>{
                GameObject panel = GameObject.Instantiate<GameObject>(obj);
                if (!panelCache.ContainsKey(panelName))
                    panelCache.Add(panelName, panel);
                UIUtil.PanelSetParent(Global.PanelRoot, panel);
                panel.SetActive(true);
                panel.name = panelName;
                panel.AddComponent<LuaBehaviour>();
                LuaFunction func = table.GetLuaFunction("OnCreate");
                if (func != null)
                    func.Call(panel);
                    
            });
           
        }
    }

    public void HidePanel(string panelName)
    {
        GameObject curPanel = null;
        panelCache.TryGetValue(curOpenPanel, out curPanel);
        if (curPanel != null)
            curPanel.SetActive(false);
    }

    public void PushPopups(string popupsName)
    {

    }

    public void ShowTextTips(string tip)
    {
        GameObject tipsObj = null;
        ResManager resMgr = GameManager.Instance.GetManager<ResManager>("ResManager");
        resMgr.LoadTipsAsyn("Tips", "TextTips", (obj) => {
            tipsObj = GameObject.Instantiate<GameObject>(obj);
            tipsObj.GetComponent<Text>().text = tip;
            UIUtil.SetParent(Global.TipsRoot.transform, tipsObj.transform);
            UIUtil.DX_显式_上移_渐隐消失<Text>(tipsObj.transform, 1, 100, () =>
            {
                GameObject.Destroy(tipsObj);
            });
        });

    }

}


