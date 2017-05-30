﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class NetworkManagerWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(NetworkManager), typeof(UnityEngine.MonoBehaviour));
		L.RegFunction("CallMethod", CallMethod);
		L.RegFunction("AddEvent", AddEvent);
		L.RegFunction("SendConnect", SendConnect);
		L.RegFunction("SendMessage", SendMessage);
		L.RegFunction("RegistForeverCallBack", RegistForeverCallBack);
		L.RegFunction("__eq", op_Equality);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.RegVar("recvCallBackDict", get_recvCallBackDict, set_recvCallBackDict);
		L.RegVar("foreverCallBackDict", get_foreverCallBackDict, set_foreverCallBackDict);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int CallMethod(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);
			NetworkManager obj = (NetworkManager)ToLua.CheckObject(L, 1, typeof(NetworkManager));
			string arg0 = ToLua.CheckString(L, 2);
			object[] arg1 = ToLua.ToParamsObject(L, 3, count - 2);
			object[] o = obj.CallMethod(arg0, arg1);
			ToLua.Push(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int AddEvent(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			RecvData arg0 = (RecvData)ToLua.CheckObject(L, 1, typeof(RecvData));
			NetworkManager.AddEvent(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendConnect(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 3);
			NetworkManager obj = (NetworkManager)ToLua.CheckObject(L, 1, typeof(NetworkManager));
			string arg0 = ToLua.CheckString(L, 2);
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
			obj.SendConnect(arg0, arg1);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int SendMessage(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 2 && TypeChecker.CheckTypes(L, 1, typeof(NetworkManager), typeof(string)))
			{
				NetworkManager obj = (NetworkManager)ToLua.ToObject(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				obj.SendMessage(arg0);
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(NetworkManager), typeof(string), typeof(UnityEngine.SendMessageOptions)))
			{
				NetworkManager obj = (NetworkManager)ToLua.ToObject(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				UnityEngine.SendMessageOptions arg1 = (UnityEngine.SendMessageOptions)ToLua.ToObject(L, 3);
				obj.SendMessage(arg0, arg1);
				return 0;
			}
			else if (count == 3 && TypeChecker.CheckTypes(L, 1, typeof(NetworkManager), typeof(string), typeof(object)))
			{
				NetworkManager obj = (NetworkManager)ToLua.ToObject(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				object arg1 = ToLua.ToVarObject(L, 3);
				obj.SendMessage(arg0, arg1);
				return 0;
			}
			else if (count == 4 && TypeChecker.CheckTypes(L, 1, typeof(NetworkManager), typeof(string), typeof(object), typeof(UnityEngine.SendMessageOptions)))
			{
				NetworkManager obj = (NetworkManager)ToLua.ToObject(L, 1);
				string arg0 = ToLua.ToString(L, 2);
				object arg1 = ToLua.ToVarObject(L, 3);
				UnityEngine.SendMessageOptions arg2 = (UnityEngine.SendMessageOptions)ToLua.ToObject(L, 4);
				obj.SendMessage(arg0, arg1, arg2);
				return 0;
			}
			else if (count == 5 && TypeChecker.CheckTypes(L, 1, typeof(NetworkManager), typeof(byte), typeof(byte), typeof(byte[]), typeof(LuaInterface.LuaFunction)))
			{
				NetworkManager obj = (NetworkManager)ToLua.ToObject(L, 1);
				byte arg0 = (byte)LuaDLL.lua_tonumber(L, 2);
				byte arg1 = (byte)LuaDLL.lua_tonumber(L, 3);
				byte[] arg2 = ToLua.CheckByteBuffer(L, 4);
				LuaFunction arg3 = ToLua.ToLuaFunction(L, 5);
				obj.SendMessage(arg0, arg1, arg2, arg3);
				return 0;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to method: NetworkManager.SendMessage");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int RegistForeverCallBack(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			NetworkManager obj = (NetworkManager)ToLua.CheckObject(L, 1, typeof(NetworkManager));
			int arg0 = (int)LuaDLL.luaL_checknumber(L, 2);
			int arg1 = (int)LuaDLL.luaL_checknumber(L, 3);
			LuaFunction arg2 = ToLua.CheckLuaFunction(L, 4);
			obj.RegistForeverCallBack(arg0, arg1, arg2);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int op_Equality(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 2);
			UnityEngine.Object arg0 = (UnityEngine.Object)ToLua.ToObject(L, 1);
			UnityEngine.Object arg1 = (UnityEngine.Object)ToLua.ToObject(L, 2);
			bool o = arg0 == arg1;
			LuaDLL.lua_pushboolean(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_recvCallBackDict(IntPtr L)
	{
		try
		{
			ToLua.PushObject(L, NetworkManager.recvCallBackDict);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_foreverCallBackDict(IntPtr L)
	{
		try
		{
			ToLua.PushObject(L, NetworkManager.foreverCallBackDict);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_recvCallBackDict(IntPtr L)
	{
		try
		{
			System.Collections.Generic.Dictionary<uint,LuaInterface.LuaFunction> arg0 = (System.Collections.Generic.Dictionary<uint,LuaInterface.LuaFunction>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.Dictionary<uint,LuaInterface.LuaFunction>));
			NetworkManager.recvCallBackDict = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_foreverCallBackDict(IntPtr L)
	{
		try
		{
			System.Collections.Generic.Dictionary<int,LuaInterface.LuaFunction> arg0 = (System.Collections.Generic.Dictionary<int,LuaInterface.LuaFunction>)ToLua.CheckObject(L, 2, typeof(System.Collections.Generic.Dictionary<int,LuaInterface.LuaFunction>));
			NetworkManager.foreverCallBackDict = arg0;
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

