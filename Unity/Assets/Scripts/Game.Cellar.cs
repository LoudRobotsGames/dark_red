using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public partial class Game : MonoBehaviour
{
    [Header("Cellar")]
    public Transform startPoint;
    public Transform cellarEntrance;
    public Priest cellarPriest;
    public int torchCount = 0;
    public GameObject cellar;
    public GameObject[] torches;
    public GameObject emptyCage;
    public GameObject fullCage;

    public void EnterCellar()
    {
        if (CanEnterState(State.Cellar))
        {
            EnterState(State.Cellar);
        }
    }

    private void CellarUpdateDelegate()
    {
        for (int i = 0; i < torchCount; ++i)
        {
            if (i < torches.Length)
            {
                torches[i].SetActive(false);
            }
        }
    }

	private IEnumerator BossFight()
    {
        cellarPriest.gameObject.SetActive(true);
		yield return null;
    }

	private IEnumerator GoIntoTheCellar()
    {
        float FADE_TIME = 0.5f;

        _playerController.BlockInput();
        fadeCurtain.CrossFadeAlpha(0, 0.01f, true);
        yield return new WaitForSecondsRealtime(0.01f);
        fadeCurtain.gameObject.SetActive(true);
        // Fade up curtain
        fadeCurtain.CrossFadeAlpha(1, FADE_TIME, true);
        yield return new WaitForSecondsRealtime(FADE_TIME);

        cellar.SetActive(true);
        town.SetActive(false);
        _updateStateCallback = CellarUpdateDelegate;
        _playerController.transform.position = startPoint.position;
       // _playerController.transform.localScale = startPoint.localScale;

        cellarPriest.gameObject.SetActive(false);
        if (torchCount >= torches.Length)
        {
            emptyCage.SetActive(false);
            fullCage.SetActive(true);
            StartCoroutine(BossFight());
        }
        else if (torchCount >= 2)
        {
            emptyCage.SetActive(true);
            fullCage.SetActive(false);
        }
        else
        {
            emptyCage.SetActive(false);
            fullCage.SetActive(false);
        }

        _playerController.ReleaseInput();

        // Fade down curtain
        fadeCurtain.CrossFadeAlpha(0, FADE_TIME, true);
        yield return new WaitForSecondsRealtime(FADE_TIME);
        fadeCurtain.gameObject.SetActive(false);
    }

    public void OnEnterCellar()
    {
        StartCoroutine(GoIntoTheCellar());
    }

    private void OnExitCellar()
    {
        town.gameObject.SetActive(true);
        cellar.gameObject.SetActive(false);
        _playerController.transform.position = cellarEntrance.position;
    }
}
