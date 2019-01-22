using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneResetter : MonoBehaviour
{
    private ChangeScenes _sceneChanger;
    private Timer _timer;

    // Start is called before the first frame update
    void Start()
    {
        _sceneChanger = GetComponent<ChangeScenes>();
        _timer = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer.CurrentCountdownTime == 0)
        {
            _sceneChanger.sceneIndex = 0;
            _sceneChanger.SwitchScenes();
        }
    }
}
