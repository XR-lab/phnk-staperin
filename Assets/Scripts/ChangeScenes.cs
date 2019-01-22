﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour
{
    public int sceneIndex;

    public void SwitchScenes()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}