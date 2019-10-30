using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class Game : MonoBehaviour
{
    [Header("Intro")]
    public AudioSource openingStab;
    public TextAsset openingStory;
    public TextAsset priestEncounterIntro;

    public Villager[] lynchmob;
    public Priest priest;
    public Transform priestPosition2;

    public Text gameOverText;
    public bool skipDialog = false;

    public void EnterIntro()
    {
        if (CanEnterState(State.Intro))
        {
            EnterState(State.Intro);
        }
    }
    
    private void IntroUpdateDelegate()
    {

    }

    private void OnEnterIntro()
    {
        if (openingStab != null)
        {
            openingStab.Play();
        }
        dialogBox.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);

        if (skipDialog)
        {
            EnterExploration();
            fadeCurtain.gameObject.SetActive(false);
            return;
        }

        for ( int i = 0; i < lynchmob.Length; ++i)
        {
            lynchmob[i].GetAngry(UnityEngine.Random.Range(0, 0.5f));
        }
        _updateStateCallback = IntroUpdateDelegate;
        dialogBox.finishedCallback = StoryCompleteDelegate;
        StartCoroutine(IntroStory());

    }

    private IEnumerator IntroStory()
    {
        _playerController.BlockInput();
        yield return new WaitForSecondsRealtime(3f);
        fadeCurtain.gameObject.SetActive(false);

        dialogBox.gameObject.SetActive(true);
        dialogBox.StartStory(openingStory);
    }

    private IEnumerator PriestEncounter()
    {
        _playerController.BlockInput();
        fadeCurtain.CrossFadeAlpha(0, 0.01f, true);
        yield return new WaitForSeconds(0.01f);
        fadeCurtain.gameObject.SetActive(true);
        // Fade up curtain
        fadeCurtain.CrossFadeAlpha(1, 0.5f, true);
        yield return new WaitForSecondsRealtime(0.5f);
        for( int i = 0; i < lynchmob.Length; ++i)
        {
            lynchmob[i].StopBeingAngry();
            lynchmob[i].gameObject.SetActive(false);
        }
        priest.transform.position = priestPosition2.position;
        priest.transform.localScale = priestPosition2.localScale;
        // Fade down curtain
        fadeCurtain.CrossFadeAlpha(0, 0.5f, true);
        yield return new WaitForSecondsRealtime(0.5f);
        fadeCurtain.gameObject.SetActive(false);

        dialogBox.gameObject.SetActive(true);
        dialogBox.StartStory(priestEncounterIntro);
    }

    private IEnumerator YouDied()
    {
        float FADE_TIME = 2f;

        _playerController.BlockInput();
        gameOverText.CrossFadeAlpha(0, 0.01f, true);
        fadeCurtain.CrossFadeAlpha(0, 0.01f, true);
        yield return new WaitForSecondsRealtime(0.01f);
        fadeCurtain.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        // Fade up curtain
        fadeCurtain.CrossFadeAlpha(1, FADE_TIME, true);
        yield return new WaitForSecondsRealtime(FADE_TIME);

        // Hide Everything
        Camera.main.backgroundColor = Color.black;
        town.SetActive(false);
        priest.gameObject.SetActive(false);
        for (int i = 0; i < lynchmob.Length; ++i)
        {
            lynchmob[i].gameObject.SetActive(false);
        }
        dialogBox.gameObject.SetActive(false);

        fadeCurtain.CrossFadeAlpha(0, FADE_TIME, true);
        yield return new WaitForSecondsRealtime(FADE_TIME);

        gameOverText.text = "You Died";
        gameOverText.CrossFadeAlpha(1, 0.5f, true);
        string died = "You Died";
        float pauseTime = 0.5f;
        for (int i = 0; i < 3; i++)
        {
            gameOverText.text = died;
            yield return new WaitForSecondsRealtime(pauseTime);
            gameOverText.text = died + ".";
            yield return new WaitForSecondsRealtime(pauseTime);
            gameOverText.text = died + "..";
            yield return new WaitForSecondsRealtime(pauseTime);
            gameOverText.text = died + "...";
        }
        SceneManager.LoadScene("Splash");
    }

    private IEnumerator GoExploring()
    {
        float FADE_TIME = 0.5f;

        _playerController.BlockInput();
        fadeCurtain.CrossFadeAlpha(0, 0.01f, true);
        yield return new WaitForSecondsRealtime(0.01f);
        fadeCurtain.gameObject.SetActive(true);
        // Fade up curtain
        fadeCurtain.CrossFadeAlpha(1, FADE_TIME, true);
        yield return new WaitForSecondsRealtime(FADE_TIME);

        EnterExploration();

        // Fade down curtain
        fadeCurtain.CrossFadeAlpha(0, FADE_TIME, true);
        yield return new WaitForSecondsRealtime(FADE_TIME);
        fadeCurtain.gameObject.SetActive(false);

    }

    private void StoryCompleteDelegate()
    {
        if (dialogBox.IsOnStory(openingStory))
        {
            if (dialogBox.GetBoolVariable("was_hung", false))
            {
                StartCoroutine(YouDied());
            }
            else
            {
                StartCoroutine(PriestEncounter());
            }
        }
        else
        {
            StartCoroutine(GoExploring());
            dialogBox.gameObject.SetActive(false);
        }
    }

    private void OnExitIntro()
    {
        for (int i = 0; i < lynchmob.Length; ++i)
        {
            lynchmob[i].StopBeingAngry();
            lynchmob[i].gameObject.SetActive(false);
        }
        priest.gameObject.SetActive(false);
        _playerController.ReleaseInput();
        _updateStateCallback = null;
        dialogBox.finishedCallback = null;
    }
}
