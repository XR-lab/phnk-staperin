using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveButton : MonoBehaviour
{
    public ScreenShotCamera shotCam;

    public void Click()
    {
        shotCam.CallShot();
    }
}
