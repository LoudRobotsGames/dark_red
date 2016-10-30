using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    public Image fadeCurtain;
    
    public void Start()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSecondsRealtime(1f);
        fadeCurtain.CrossFadeAlpha(0f, 2f, true);
        yield return new WaitForSecondsRealtime(4f);
        fadeCurtain.CrossFadeAlpha(1f, 2f, true);
        yield return new WaitForSecondsRealtime(2.5f);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
