using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ScreenShotCamera : MonoBehaviour
{

    private Camera _screenCapCam;

    private int _resWidth = 256;
    private int _resHeight = 256;

    void Awake()
    {
        _screenCapCam = GetComponent<Camera>();

        if (_screenCapCam.targetTexture == null)
        {
            _screenCapCam.targetTexture = new RenderTexture(_resWidth, _resHeight, 24);
        } else {
            _resWidth = _screenCapCam.targetTexture.width;
            _resHeight = _screenCapCam.targetTexture.height;
        }
        _screenCapCam.gameObject.SetActive(false);
    }

    public void CallShot()
    {
        _screenCapCam.gameObject.SetActive(true);
    }

    void LateUpdate()
    {
        if (_screenCapCam.gameObject.activeInHierarchy)
        {
            Texture2D snapshot = new Texture2D(_resWidth, _resHeight, TextureFormat.RGB24, false);
            _screenCapCam.Render();
            RenderTexture.active = _screenCapCam.targetTexture;
            snapshot.ReadPixels(new Rect(0, 0, _resWidth, _resHeight), 0, 0);
            byte[] bytes = snapshot.EncodeToPNG();
            string filename = SnapshotName();
            System.IO.File.WriteAllBytes(filename, bytes);
            Debug.Log("Pic taken");
            _screenCapCam.gameObject.SetActive(false);
        }
    }

    string SnapshotName()
    {
        return string.Format("{0}/ScreenShots/snap_{1}x{2}_{3}.png",
            Application.dataPath,
            _resWidth,
            _resHeight,
            System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    }
}
