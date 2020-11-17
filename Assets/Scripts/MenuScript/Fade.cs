using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image SpriteObj;
    public Button StartButton;
    public float FadeSeconds;

    private Coroutine coroutine;
    private bool FadeEnd;

    private void Start()
    {
        FadeEnd = false;
        FadeOut();
    }

    private void Update()
    {
        if(FadeEnd)
        {
            StartButton.gameObject.SetActive(true);
            FadeEnd = false;
        }
    }

    void FadeIn()
    {
        StartCoroutine(EnFadeIn());
    }

    void FadeOut()
    {
        StartCoroutine(EnFadeOut());
    }

    IEnumerator EnFadeIn()
    {
        Color TempColor = SpriteObj.color;

        while (TempColor.a < 1f)
        {
            TempColor.a += Time.deltaTime / FadeSeconds;
            SpriteObj.color = TempColor;

            //if(TempColor.a <= 0.01f)
            //{
            //    TempColor.a = 0f;
            //}
            yield return null;
        }
        SpriteObj.color = TempColor;
    }

    IEnumerator EnFadeOut()
    {
        Color TempColor = SpriteObj.color;

        while (TempColor.a > 0f)
        {
            TempColor.a -= Time.deltaTime / FadeSeconds;
            SpriteObj.color = TempColor;

            if (TempColor.a <= 0.01f)
            {
                //TempColor.a = 1f;

                FadeEnd = true;
            }
            yield return null;
        }
        SpriteObj.color = TempColor;
    }
}
