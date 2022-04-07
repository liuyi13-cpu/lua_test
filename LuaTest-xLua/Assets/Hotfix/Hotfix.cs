using System;
using UnityEngine;
using XLua;

public class Hotfix : MonoBehaviour
{
    public TextAsset luaScript;
    public TextAsset hotfixLuaScript;
    
    private string logText = "";
    private LuaEnv luaEnv;
    
    private void Start()
    {
        Application.logMessageReceived += Log;

        luaEnv = new LuaEnv();
        luaEnv.DoString(luaScript.text);
    }

    private void Log(string cond, string trace, LogType lt)
    {
        logText += cond;
        logText += "\n";
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(50, 20, 200, 100), "hotfix"))
        {
            try
            {
                luaEnv.DoString(hotfixLuaScript.text);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
        }
        if (GUI.Button(new Rect(50, 220, 200, 100), "Clear Screen"))
        {
            logText = "";
        }
        
        GUI.Label(new Rect(400, 0, 500, 1000), logText);
    }
}
