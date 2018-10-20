using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger  {



    static bool _debug = true;

    public static bool debug
    {
        get
        {
            return _debug;
        }

        set
        {
            _debug = value;
        }
    }

    public static bool IsInEditorMode()
    {
        if (Application.isEditor && !Application.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool IsInEditorPlayMode()
    {
        if (Application.isEditor && Application.isPlaying)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static void Log(string s)
    {
        if (debug)
            Debug.Log(s);
    }

    public static void LogWarning(string s)
    {
        if (debug)
            Debug.LogWarning(s);
    }
}
