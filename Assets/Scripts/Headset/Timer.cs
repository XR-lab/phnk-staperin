using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private int _countdownTime = 10;
    private int _currentDownTime  = -10;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            StartTimer();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            StopTimer();
        }
    }

    public int CurrentCountdownTime
    {
        get
        {
            return _currentDownTime;
        }

        set
        {
            _currentDownTime = value;
        }
    }

    public void StartTimer()
    {
        CurrentCountdownTime = _countdownTime;
        StopAllCoroutines();
        StartCoroutine(CountDown());
    }

    public void StopTimer()
    {
        StopCoroutine(CountDown());
        CurrentCountdownTime = -10;
    }

    private IEnumerator CountDown()
    {
        while (CurrentCountdownTime > 0)
        {
            yield return new WaitForSeconds(1);
            CurrentCountdownTime--;
        }
    }
}
