﻿//this source code was auto-generated by tolua#, do not modify it
using System;
using LuaInterface;

public class UnityEngine_CameraClearFlagsWrap
{
	public static void Register(LuaState L)
	{
		L.BeginEnum(typeof(UnityEngine.CameraClearFlags));
		L.RegVar("Skybox", new LuaCSFunction(get_Skybox), null);
		L.RegVar("Color", new LuaCSFunction(get_Color), null);
		L.RegVar("SolidColor", new LuaCSFunction(get_SolidColor), null);
		L.RegVar("Depth", new LuaCSFunction(get_Depth), null);
		L.RegVar("Nothing", new LuaCSFunction(get_Nothing), null);
		L.RegFunction("IntToEnum", new LuaCSFunction(IntToEnum));
		L.EndEnum();
		TypeTraits<UnityEngine.CameraClearFlags>.Check = CheckType;
		StackTraits<UnityEngine.CameraClearFlags>.Push = Push;
	}

	static void Push(IntPtr L, UnityEngine.CameraClearFlags arg)
	{
		ToLua.Push(L, arg);
	}

	static Type TypeOf_UnityEngine_CameraClearFlags = typeof(UnityEngine.CameraClearFlags);

	static bool CheckType(IntPtr L, int pos)
	{
		return TypeChecker.CheckEnumType(TypeOf_UnityEngine_CameraClearFlags, L, pos);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Skybox(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.CameraClearFlags.Skybox);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Color(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.CameraClearFlags.Color);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_SolidColor(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.CameraClearFlags.SolidColor);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Depth(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.CameraClearFlags.Depth);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_Nothing(IntPtr L)
	{
		ToLua.Push(L, UnityEngine.CameraClearFlags.Nothing);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int IntToEnum(IntPtr L)
	{
		int arg0 = (int)LuaDLL.lua_tointeger(L, 1);
		UnityEngine.CameraClearFlags o = (UnityEngine.CameraClearFlags)arg0;
		ToLua.Push(L, o);
		return 1;
	}
}

