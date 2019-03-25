using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class HoldToReset : MonoBehaviour
{
    [SerializeField] private float _holdTime;
    private float _startTime;
    private SteamVR_ActionSet _ActionSet;
    private bool _reset = false;
    public bool _setReset
    {
        set
        {
            _reset = value;
        }
    }

    private void Start()
    {
        _ActionSet.Activate(SteamVR_Input_Sources.Any, 0, true);
    }
    void Update()
    {
        if (_reset)
        {   
            if (SteamVR_Actions._default.GrabPinch.GetStateDown(SteamVR_Input_Sources.Any))
            {
                _startTime = Time.time;
                print("trigger down");
            }
            if (SteamVR_Actions._default.GrabPinch.GetStateUp(SteamVR_Input_Sources.Any) && _startTime + _holdTime >= Time.time)
            {
                SceneUtils.Reset();
                print("reset");
            }
        }      
    }
}
