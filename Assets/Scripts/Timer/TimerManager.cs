using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private ReadData ReadData;
    [SerializeField] private KeyboardChangeState KeyboardChangeState;
    private TimerClass ChangeStateTimer;
    private TimerClass gameTimer;

    void Start()
    {
        ChangeStateTimer = gameObject.AddComponent<TimerClass>();
        ChangeStateTimer.TimerCompleted += KeyboardChangeState.NextState;
        ChangeStateTimer.StartTimer(ReadData.GetTransferTime());
        
        gameTimer = gameObject.AddComponent<TimerClass>();
        gameTimer.TimerCompleted += GameTimeDone;
        gameTimer.StartTimer(ReadData.GetSeconds());
    }
    void TimeLeft()
    {//fade in/out pop-up met als text: 1 minuut left
        print("1 min left");
    }
    void GameTimeDone()
    {//fade in zwart scherm met text : bedankt voor spelen (hou de trekker vast om te starten)
        print("time up");
    }
}
