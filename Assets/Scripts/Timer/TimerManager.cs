using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private Fade _fade;
    //[SerializeField] private ReadData ReadData;
    //[SerializeField] private KeyboardChangeState KeyboardChangeState;
    [SerializeField] private Text _bedanktText;
    [SerializeField] private Text _resetText;
    [SerializeField] private Text _timeLeftText;
    [SerializeField] private Image _canvasImage;
    private TimerClass ChangeStateTimer;
    private TimerClass gameTimer;

    void Start()
    {
        /*
        ChangeStateTimer = gameObject.AddComponent<TimerClass>();
        ChangeStateTimer.TimerCompleted += KeyboardChangeState.NextState;
        ChangeStateTimer.TimerCompleted += ResetChangeStateTimer;
        ChangeStateTimer.StartTimer(ReadData.GetTransferTime());*/

        gameTimer = gameObject.AddComponent<TimerClass>();
        gameTimer.TimerCompleted += TimeLeft;
        gameTimer.StartTimer(10/*ReadData.GetSeconds() - 60*/);

        _fade.FadeOutInstantly(_timeLeftText);
        _fade.FadeOutInstantly(_resetText);
        _fade.FadeOutInstantly(_bedanktText);
        _fade.FadeOutInstantlyImage(_canvasImage);
    }
    void ResetChangeStateTimer()
    {
       // ChangeStateTimer.StartTimer(ReadData.GetTransferTime());
    }
    void TimeLeft()
    {
        print("1 min left");
        _fade.FadeOutAndIn(_timeLeftText);

        gameTimer.TimerCompleted -= TimeLeft;
        gameTimer.TimerCompleted += GameTimeDone;
        gameTimer.StartTimer(60);
    }
    void GameTimeDone()
    {//hij moet nu kunnen reseten door 1 sec op de trigger te klicken
        print("time up");
        _fade.FadeIn(_resetText);
        _fade.FadeIn(_bedanktText);
        _fade.FadeInImage(_canvasImage);
    }
}
