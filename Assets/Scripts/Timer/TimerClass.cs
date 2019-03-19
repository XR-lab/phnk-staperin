using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerClass : MonoBehaviour
{
	public delegate void TimerCompletedEvent();
	public event TimerCompletedEvent TimerCompleted;

	private float _seconds;
	public float GetSeconds()
	{
		return _seconds;
	}

	private float _threshold;
	public float GetThreshold()
	{
		return _threshold;
	}

	public void StartTimer(float sec)
	{
        _threshold = sec;
		StartCoroutine(Timer(sec));
	}

	IEnumerator Timer(float threshold)
	{
        _seconds = 0;
		while (_seconds < threshold)
		{
            _seconds += Time.deltaTime;	
			yield return null;
		}
        if (TimerCompleted != null)
        {
            TimerCompleted();
        }		
	}
}
