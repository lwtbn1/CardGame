using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;
public class UIUtil  {

    public static void PanelSetParent(GameObject parent, GameObject child)
    {
        RectTransform childRect = child.GetComponent<RectTransform>();
        RectTransform parentRect = parent.GetComponent<RectTransform>();
        childRect.SetParent(parentRect, false);
        childRect.sizeDelta = Vector2.zero;
        childRect.anchoredPosition = Vector3.zero;
        childRect.localScale = Vector3.one;
    }
    public static void SetParent(Transform parent, Transform tipsObj)
    {
        tipsObj.SetParent(parent, false);
        tipsObj.localPosition = Vector3.zero;
        tipsObj.localScale = Vector3.one;
        tipsObj.localEulerAngles = Vector3.zero;
    }
    public static GameObject FindInChild(GameObject obj, string name)
    {
        if (obj != null && obj.name == name)
            return obj;
        else
        {
            for (var i = 0; i < obj.transform.childCount; i++)
            {
                GameObject target =FindInChild(obj.transform.GetChild(i).gameObject, name);
                if (target != null)
                    return target;
            }
        }
        return null;
    }

    public static void DX_显式_上移_渐隐消失<T>(Transform target,float duration, float speed, Action cb) where T : UnityEngine.UI.Graphic
    {
        Tweener tweener = target.DOLocalMoveY(duration * speed, duration);
        tweener.OnStart(()=> {
            target.GetComponent<T>().CrossFadeAlpha(0, duration, true);
        });
        tweener.OnComplete(() => {
            tweener.Kill();
            tweener = null;
            if (cb != null)
                cb();
            });
    }

    public static int TextLen(string input, Text text)
    {
        CharacterInfo characterInfo;
        Font font = text.font;
        int width = 0;
        FontStyle fontStyle = text.fontStyle;
        font.RequestCharactersInTexture(input, text.fontSize, fontStyle);
        for (int i = 0; i < input.Length; i++)
        {
            font.GetCharacterInfo(input[i], out characterInfo, text.fontSize);
            width += characterInfo.advance;
        }
        return width;
    }

}
