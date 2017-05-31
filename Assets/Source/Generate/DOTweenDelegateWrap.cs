﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class DOTweenDelegateWrap
{
	public static void Register(LuaState L)
	{
		L.BeginClass(typeof(DOTweenDelegate), typeof(System.Object));
		L.RegFunction("GetDelegate", GetDelegate);
		L.RegFunction("DOMove", DOMove);
		L.RegFunction("DOLocalMove", DOLocalMove);
		L.RegFunction("DOLocalMoveX", DOLocalMoveX);
		L.RegFunction("DOLocalMoveY", DOLocalMoveY);
		L.RegFunction("DOLocalMoveZ", DOLocalMoveZ);
		L.RegFunction("DOScale", DOScale);
		L.RegFunction("Kill", Kill);
		L.RegFunction("New", _CreateDOTweenDelegate);
		L.RegFunction("__tostring", ToLua.op_ToString);
		L.EndClass();
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateDOTweenDelegate(IntPtr L)
	{
		try
		{
			int count = LuaDLL.lua_gettop(L);

			if (count == 0)
			{
				DOTweenDelegate obj = new DOTweenDelegate();
				ToLua.PushObject(L, obj);
				return 1;
			}
			else
			{
				return LuaDLL.luaL_throw(L, "invalid arguments to ctor method: DOTweenDelegate.New");
			}
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetDelegate(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 0);
			DOTweenDelegate o = DOTweenDelegate.GetDelegate();
			ToLua.PushObject(L, o);
			return 1;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOMove(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 4);
			DOTweenDelegate obj = (DOTweenDelegate)ToLua.CheckObject(L, 1, typeof(DOTweenDelegate));
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Transform));
			UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 4);
			obj.DOMove(arg0, arg1, arg2);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOLocalMove(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 6);
			DOTweenDelegate obj = (DOTweenDelegate)ToLua.CheckObject(L, 1, typeof(DOTweenDelegate));
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Transform));
			UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 4);
			LuaFunction arg3 = ToLua.CheckLuaFunction(L, 5);
			LuaFunction arg4 = ToLua.CheckLuaFunction(L, 6);
			obj.DOLocalMove(arg0, arg1, arg2, arg3, arg4);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOLocalMoveX(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 6);
			DOTweenDelegate obj = (DOTweenDelegate)ToLua.CheckObject(L, 1, typeof(DOTweenDelegate));
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Transform));
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 4);
			LuaFunction arg3 = ToLua.CheckLuaFunction(L, 5);
			LuaFunction arg4 = ToLua.CheckLuaFunction(L, 6);
			obj.DOLocalMoveX(arg0, arg1, arg2, arg3, arg4);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOLocalMoveY(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 6);
			DOTweenDelegate obj = (DOTweenDelegate)ToLua.CheckObject(L, 1, typeof(DOTweenDelegate));
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Transform));
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 4);
			LuaFunction arg3 = ToLua.CheckLuaFunction(L, 5);
			LuaFunction arg4 = ToLua.CheckLuaFunction(L, 6);
			obj.DOLocalMoveY(arg0, arg1, arg2, arg3, arg4);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOLocalMoveZ(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 6);
			DOTweenDelegate obj = (DOTweenDelegate)ToLua.CheckObject(L, 1, typeof(DOTweenDelegate));
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Transform));
			float arg1 = (float)LuaDLL.luaL_checknumber(L, 3);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 4);
			LuaFunction arg3 = ToLua.CheckLuaFunction(L, 5);
			LuaFunction arg4 = ToLua.CheckLuaFunction(L, 6);
			obj.DOLocalMoveZ(arg0, arg1, arg2, arg3, arg4);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int DOScale(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 6);
			DOTweenDelegate obj = (DOTweenDelegate)ToLua.CheckObject(L, 1, typeof(DOTweenDelegate));
			UnityEngine.Transform arg0 = (UnityEngine.Transform)ToLua.CheckUnityObject(L, 2, typeof(UnityEngine.Transform));
			UnityEngine.Vector3 arg1 = ToLua.ToVector3(L, 3);
			float arg2 = (float)LuaDLL.luaL_checknumber(L, 4);
			LuaFunction arg3 = ToLua.CheckLuaFunction(L, 5);
			LuaFunction arg4 = ToLua.CheckLuaFunction(L, 6);
			obj.DOScale(arg0, arg1, arg2, arg3, arg4);
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Kill(IntPtr L)
	{
		try
		{
			ToLua.CheckArgsCount(L, 1);
			DOTweenDelegate obj = (DOTweenDelegate)ToLua.CheckObject(L, 1, typeof(DOTweenDelegate));
			obj.Kill();
			return 0;
		}
		catch(Exception e)
		{
			return LuaDLL.toluaL_exception(L, e);
		}
	}
}

