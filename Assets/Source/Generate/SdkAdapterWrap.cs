﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class SdkAdapterWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(SdkAdapter), typeof(System.Object));
		L.RegFunction("Authorize_Wei_Xin", Authorize_Wei_Xin);
		L.RegFunction("New", _CreateSdkAdapter);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateSdkAdapter(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				SdkAdapter obj = new SdkAdapter();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: SdkAdapter.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Authorize_Wei_Xin(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			LuaFunction arg0 = ToLua.CheckLuaFunction(L, 1);
			SdkAdapter.Authorize_Wei_Xin(arg0);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

