using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] private float _fadeTime;
    public void FadeOutInstantlyImage(Image image)
    {
        image.CrossFadeAlpha(0, 0f, false);
    }
    public void FadeInImage(Image image)
    {
        image.CrossFadeAlpha(1, _fadeTime, false);
    }

    public void FadeIn(Text text)
    {
        text.CrossFadeAlpha(1, _fadeTime, false);
    }
    public void FadeOut(Text text)
    {
        text.CrossFadeAlpha(0, _fadeTime, false);
    }
    public void FadeOutInstantly(Text text)
    {
        text.CrossFadeAlpha(0, _fadeTime, false);
    }
    public void FadeOutAndIn(Text text)
    {
        StartCoroutine(FadeInAndOut(text));
    }
    IEnumerator FadeInAndOut(Text text)
    {
        text.CrossFadeAlpha(1, _fadeTime, false);
        yield return new WaitForSeconds(_fadeTime);
        text.CrossFadeAlpha(0, _fadeTime, false);
    }
}

