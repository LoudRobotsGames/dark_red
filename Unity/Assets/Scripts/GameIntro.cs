using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GameIntro :MonoBehaviour
{
    public Image fadeCurtain;

    public void Start()
    {
        fadeCurtain.gameObject.SetActive(true);
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSecondsRealtime(1f);
        fadeCurtain.CrossFadeAlpha(0f, 2f, true);

        // Game intro logic!
    }
}

