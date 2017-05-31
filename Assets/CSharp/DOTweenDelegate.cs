using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using LuaInterface;
public class DOTweenDelegate  {
    public static DOTweenDelegate GetDelegate()
    {
        return new DOTweenDelegate();
    }
    Tweener tweener;
    # region Transform Move相关
    public void DOMove(Transform transform, Vector3 endValue, float duration)
    {
        tweener = transform.DOMove(endValue, duration);
    }

    public void DOLocalMove(Transform transform, Vector3 endValue, float duration, LuaFunction OnStart, LuaFunction OnComplete)
    {
        tweener = transform.DOLocalMove(endValue, duration);
        RegisterAction(OnStart, OnComplete);
    }
    public void DOLocalMoveX(Transform transform, float endValue, float duration, LuaFunction OnStart, LuaFunction OnComplete)
    {
        tweener = transform.DOLocalMoveX(endValue, duration);
        RegisterAction(OnStart, OnComplete);
    }
    public void DOLocalMoveY(Transform transform, float endValue, float duration, LuaFunction OnStart, LuaFunction OnComplete)
    {
        tweener = transform.DOLocalMoveY(endValue, duration);
        RegisterAction(OnStart, OnComplete);
    }
    public void DOLocalMoveZ(Transform transform, float endValue, float duration, LuaFunction OnStart, LuaFunction OnComplete)
    {
        tweener = transform.DOLocalMoveZ(endValue, duration);
        RegisterAction(OnStart, OnComplete);
    }
    #endregion

    #region Transform Scal相关
    public void DOScale(Transform transform, Vector3 endValue, float duration, LuaFunction OnStart, LuaFunction OnComplete)
    {
        tweener = transform.DOScale(endValue, duration);
        RegisterAction(OnStart, OnComplete);
    }
    #endregion
    void RegisterAction(LuaFunction OnStart, LuaFunction OnComplete)
    {
        if (OnStart != null)
        {
            tweener.OnStart(() =>
            {
                LuaHelper.Call(OnStart, null, true);
            });
        }
        tweener.OnComplete(() =>
        {
            LuaHelper.Call(OnComplete, null, true);
            Kill();
        });
    }
    public void Kill()
    {
        if (tweener != null)
        {
            tweener.Kill();
            tweener = null;
        }
    }
}
