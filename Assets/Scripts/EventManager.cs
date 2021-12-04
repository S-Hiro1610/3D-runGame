using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager
{
    public static event Action OnGameStart;
    public static event Action OnStop;
    public static event Action OnGameEnd;
    public static event Action OnRestart;

    public static void GameStart()
    {
        OnGameStart?.Invoke();
    }
    public static void Stop()
    {
        OnStop?.Invoke();
    }
    public static void GameEnd()
    {
        OnGameEnd?.Invoke();
    }
    public static void Restart()
    {
        OnRestart?.Invoke();
    }
}
