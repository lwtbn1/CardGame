using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LuaInterface;
public class SdkAdapter {
    private static string str = "result";
    public static void Authorize_Wei_Xin(LuaFunction func)
    {
        Social.Authorize(Platform.WEIXIN, (platform,stCode, message ) =>
        {
            if (stCode == Social.SUCCESS)
            {
                Debug.Log("xxxxxx message=" + message.Count);
                str = "success __";
                foreach (KeyValuePair<string, string> kv in message)
                {
                    string n = kv.Key;
                    string s = kv.Value;
                    str = str + "   " + n + ":" + s;
                }
                Debug.Log(str);
            }
            else
            {
                str = "fail=";
                foreach (KeyValuePair<string, string> kv in message)
                {
                    string n = kv.Key;
                    string s = kv.Value;
                    str = str + "   " + n + ":" + s;
                }
                Debug.Log(str);
            };
            LuaHelper.Call(func, new object[] { stCode }, true);
        });

    }

    Social.AuthDelegate authcallback =
            delegate(Platform platform, int stCode, Dictionary<string, string> message)
            {
                if (stCode == Social.SUCCESS)
                {
                    Debug.Log("xxxxxx message=" + message.Count);
                    str = "success";
                    foreach (KeyValuePair<string, string> kv in message)
                    {
                        string n = kv.Key;
                        string s = kv.Value;
                        str = str + "   " + n + ":" + s;
                    }


                }
                else
                {
                    str = "fail=";
                    foreach (KeyValuePair<string, string> kv in message)
                    {
                        string n = kv.Key;
                        string s = kv.Value;
                        str = str + "   " + n + ":" + s;
                    }
                };
            };
}
