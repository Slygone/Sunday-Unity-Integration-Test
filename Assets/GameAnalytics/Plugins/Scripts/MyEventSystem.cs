using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class MyEventSystem : GameAnalytics
{
    public static MyEventSystem I;

    private void Awake()
    {
        I = this;
        Initialize();
        //DontDestroyOnLoad(this.gameObject);
    }

    public void StartLevel(int level)
    {
        NewProgressionEvent(GAProgressionStatus.Start, level.ToString());
    }
    
    public void FailLevel(int level)
    {
        NewProgressionEvent(GAProgressionStatus.Fail, level.ToString());
    }
    
    public void CompleteLevel(int level)
    {
        NewProgressionEvent(GAProgressionStatus.Complete, level.ToString());
    }
}
