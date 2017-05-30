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
public class ResManager : MonoBehaviour
{

    private Dictionary<string, AssetBundle> bundles = new Dictionary<string, AssetBundle>();
    /// <summary>
    /// 同步加载图片
    /// </summary>
    /// <param name="atlas">图集名</param>
    /// <param name="sp_name">图名</param>
    /// <returns></returns>
    public Sprite LoadSpriteSyn(string atlas, string sp_name)
    {
        AssetBundle bundle = getBundle(atlas);
        if (bundle == null)
            bundle = AssetBundle.LoadFromFile(GameDef.UIPathRoot + "/" + atlas + GameDef.BundleExtName);
        cacheBundle(atlas, bundle);
        Sprite sp = bundle.LoadAsset<Sprite>(sp_name);

        return sp;
    }

    /// <summary>
    /// 异步加载图片
    /// </summary>
    /// <param name="atlas">图集名</param>
    /// <param name="sp_name">图片名</param>
    /// <param name="callBack">加载后执行</param>
    public IEnumerator LoadSpriteAsyn(string atlas, string sp_name, Action<Sprite> callBack)
    {
        AssetBundle bundle = getBundle(atlas);
        if (bundle == null)
        {
            AssetBundleCreateRequest bundleReq = AssetBundle.LoadFromFileAsync(GameDef.UIPathRoot + "/" + atlas + GameDef.BundleExtName);
            while (!bundleReq.isDone)
                yield return false;
            bundle = bundleReq.assetBundle;

        }
        cacheBundle(atlas, bundle);
        Sprite sp = bundle.LoadAsset<Sprite>(sp_name);
        if (callBack != null)
            callBack(sp);
    }


    /// <summary>
    /// 异步加载资源
    /// </summary>
    /// <param name="bundleName"></param>
    /// <param name="assetName"></param>
    /// <param name="callBack"></param>
    /// <returns></returns>
    private IEnumerator LoadAssetAsynYed(string bundleName, string assetName, Action<GameObject> callBack)
    {
        AssetBundle bundle = getBundle(bundleName);
        if (bundle == null)
        {
            AssetBundleCreateRequest bundleReq = AssetBundle.LoadFromFileAsync(GameDef.PanelPathRoot + bundleName + GameDef.BundleExtName);
            while (!bundleReq.isDone)
                yield return false;
            bundle = bundleReq.assetBundle;

        }
        cacheBundle(bundleName, bundle);
        GameObject obj = bundle.LoadAsset<GameObject>(assetName);
        if (callBack != null)
            callBack(obj);
    }

    public void LoadPanelAsyn(string bundleName, string assetName, Action<GameObject> callBack)
    {
        StartCoroutine(LoadAssetAsynYed(bundleName, assetName, callBack));
    }
    public void LoadTipsAsyn(string bundleName, string assetName, Action<GameObject> callBack)
    {
        StartCoroutine(LoadAssetAsynYed(bundleName, assetName, callBack));
    }
    /// <summary>
    /// 缓存加载出来的bundle
    /// </summary>
    /// <param name="name"></param>
    /// <param name="bundle"></param>
    private void cacheBundle(string name, AssetBundle bundle)
    {
        if (bundles.ContainsKey(name))
            return;
        bundles.Add(name, bundle);
    }
    /// <summary>
    /// 从缓存中获取bundle
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    public AssetBundle getBundle(string name)
    {
        AssetBundle bundle = null;
        if (bundles.ContainsKey(name))
            bundle = bundles[name];
        return bundle;
    }
    /// <summary>
    /// 卸载bundle
    /// </summary>
    /// <param name="name"></param>
    /// <param name="unloadAllLoadedObjects"></param>
    public void UnloadBundle(string name, bool unloadAllLoadedObjects = false)
    {
        if (bundles.ContainsKey(name))
        {
            bundles[name].Unload(unloadAllLoadedObjects);
        }
    }



}


