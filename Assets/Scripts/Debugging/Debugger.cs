using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debugger : MonoBehaviour
{
    [SerializeField] private Text _debugText;
    //[SerializeField] private string tempText;

    /* Start is called before the first frame update
    void Start()
    {
        _debugText.text = "";
    }*/

    public void ChangeDebugText(string newText)
    {
        _debugText.text = newText;
    }

    public void AddDebugText(string newText)
    {
        _debugText.text += newText;
    }

    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ChangeDebugText(tempText);
        }
    }*/
}
