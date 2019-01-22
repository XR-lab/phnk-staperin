using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    private Timer _timer;
    [SerializeField]
    private Text _timerText;
    [SerializeField]
    private GameObject _canvas;

    // Start is called before the first frame update
    void Start()
    {
        _timer = FindObjectOfType<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer.CurrentCountdownTime <= -10)
        {
            _canvas.SetActive(false);
        }
        else
        {
            _canvas.SetActive(true);
            ChangeText("Seconds before reset: " + _timer.CurrentCountdownTime);
        }
    }

    private void ChangeText(string newText)
    {
        _timerText.text = newText;
    }
    
}
