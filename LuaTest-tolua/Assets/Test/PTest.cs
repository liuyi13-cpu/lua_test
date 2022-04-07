using System.Collections;
using UnityEngine;
using LuaInterface;

public class PTest : MonoBehaviour {
    public LuaState state = null;
    public string logText = "";
    public WaitForSeconds ws = new WaitForSeconds(2);
    public int runCount;

    TestItem[] testItems;

    LuaFunction gcFunc;


    void Awake()
    {
        new LuaResLoader();
        state = new LuaState();
        state.Start();
        LuaBinder.Bind(state);

        Application.logMessageReceived += ShowTips;
    }

    void Start()
    {
        runCount = 10;

        testItems = new TestItem[17+ 4];
        for (int i=0; i<=10+ 4; ++i)
        {
            testItems[i] = new TestLua(this, i, transform);
        }
        testItems[11+ 4] = new TestEmptyFunc(this, 11+ 4);
        testItems[12+ 4] = new TestGetLuaValue(this, 12+ 4, "_V0");
        testItems[13+ 4] = new TestGetLuaValue(this, 13+ 4, "_V1");
        testItems[14+ 4] = new TestGetLuaValue(this, 14+ 4, "_V2");
        testItems[15+ 4] = new TestGetLuaValue(this, 15+ 4, "_V3");
        testItems[16+ 4] = new TestGetLuaValue(this, 16+ 4, "_V4");


        state.DoFile("TestPerf.lua");
        gcFunc = state.GetFunction("GC");
    }

    void ShowTips(string msg, string stackTrace, LogType type)
    {
        logText += msg;
        logText += "\r\n";
    }
    
    public void GC()
    {
        gcFunc.Call();
        Resources.UnloadUnusedAssets();
        System.GC.Collect();

        gcFunc.Call();
        Resources.UnloadUnusedAssets();
        System.GC.Collect();

        print("GC Done!");
    }


    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 10, 100, 50), "GC"))
        {
            GC();
        }

        if (GUI.Button(new Rect(130, 10, 100, 50), "Version"))
        {
            state.GetFunction("Version").Call();
        }

        if (GUI.Button(new Rect(10, 80, 100, 50), "Jit Switch"))
        {
            state.GetFunction("JitSwitch").Call();
        }

        if (GUI.Button(new Rect(130, 80, 100, 50), "Clear Screen"))
        {
            logText = "";
        }


        int[] rows = { 10, 110, 210 };
        int[] cols = { 0, 0, 70 };
        int col = 150;
        for (int i=0; i<testItems.Length; ++i)
        {
            if (GUI.Button(new Rect(rows[i % 3], col, 100, 50), "Test" + i))
            {
                StartCoroutine(testItems[i].Test());
            }

            col += cols[i % 3];
        }

        


        GUI.Label(new Rect(400, 0, 500, 1000), logText);
    }
}
