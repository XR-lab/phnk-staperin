using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QualitySetter : MonoBehaviour
{

    [SerializeField]
    private string _defaultQuality = "Ultra";
    void Start() {
        string[] names = QualitySettings.names;
        for (int i = 0; i < names.Length; i++)
        {
            if (names[i] == _defaultQuality)
            {
                QualitySettings.SetQualityLevel(i, true);
                return;
            }
        }        
    }
}
