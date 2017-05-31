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
    public IEnumerator LoadAssetAsynYed(string bundleName, string assetName, Action<GameObject> callBack)
    {
        bundleName = bundleName.ToLower();
        yield return LoadBundleAsynYed(bundleName);
        AssetBundle bundle = getBundle(bundleName);
        GameObject obj = bundle.LoadAsset<GameObject>(assetName);
        if (callBack != null)
            callBack(obj);
    }
    public IEnumerator LoadBundleAsynYed(string bundleName)
    {
        bundleName = bundleName.ToLower();
        AssetBundle bundle = getBundle(bundleName);
        if (bundle == null)
        {
            AssetBundleCreateRequest bundleReq = AssetBundle.LoadFromFileAsync(GameDef.BundlePathRoot + "/" + bundleName + GameDef.BundleExtName);
            while (!bundleReq.isDone)
                yield return false;
            bundle = bundleReq.assetBundle;

        }
        cacheBundle(bundleName, bundle);
    }
    /// <summary>
    /// 加载面板
    /// </summary>
    /// <param name="bundleName"></param>
    /// <param name="assetName"></param>
    /// <param name="callBack"></param>
    public void LoadPanelAsyn(string bundleName, string assetName, Action<GameObject> callBack)
    {
        StartCoroutine(LoadAssetAsynYed(bundleName, assetName, callBack));
    }
    /// <summary>
    /// 加载tips
    /// </summary>
    /// <param name="bundleName"></param>
    /// <param name="assetName"></param>
    /// <param name="callBack"></param>
    public void LoadTipsAsyn(string bundleName, string assetName, Action<GameObject> callBack)
    {
        StartCoroutine(LoadAssetAsynYed(bundleName, assetName, callBack));
    }

    /// <summary>
    /// 加载某一资源
    /// </summary>
    /// <param name="bundleName"></param>
    /// <param name="assetName"></param>
    /// <param name="func"></param>
    public void LoadAssetAsyn(string bundleName, string assetName, LuaFunction func)
    {
        StartCoroutine(LoadAssetAsynYed(bundleName, assetName, (asset) => {
            LuaHelper.Call(func, new object[] { asset }, true);
        }));
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
    #region 预加载Bundles
    private IEnumerator LoadBundlesYed(LuaTable table, LuaFunction onStartLoad, LuaFunction onLoading, LuaFunction onEndLoad)
    {
        if (table == null || table.Length == 0)
            yield break;
        object[] array = table.ToArray();
        LuaHelper.Call(onStartLoad,null,true);
        for (var i = 0; i < array.Length; i++)
        {
            string bundleName = array[i].ToString();
            yield return LoadBundleAsynYed(bundleName);
            yield return new WaitForSeconds(0.1f);
            LuaHelper.Call(onLoading, new object[]{(float)(i + 1) / (float)array.Length}, false);
        }
        LuaHelper.LuaFuncDispose(onLoading);
        LuaHelper.Call(onEndLoad,null,true);

    }
    public void LoadBundles(LuaTable table, LuaFunction onStartLoad, LuaFunction onLoading, LuaFunction onEndLoad)
    {
        StartCoroutine(LoadBundlesYed(table, onStartLoad, onLoading, onEndLoad));
    }
    #endregion
}


