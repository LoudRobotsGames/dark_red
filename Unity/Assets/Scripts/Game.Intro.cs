using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public partial class Game : MonoBehaviour
{
    [Header("Intro")]
    public AudioSource openingStab;
    public TextAsset openingStory;

    public Villager[] villagers;

    public void EnterIntro()
    {
        if (CanEnterState(State.Intro))
        {
            EnterState(State.Intro);
        }
    }
    
    private void UpdateDelegate()
    {

    }

    private void StoryCompleteDelegate()
    {
        EnterExploration();
        dialogBox.gameObject.SetActive(false);
    }

    private void OnEnterIntro()
    {
        if (openingStab != null)
        {
            openingStab.Play();
        }
        dialogBox.gameObject.SetActive(false);
        fadeCurtain.gameObject.SetActive(false);

        for( int i = 0; i < villagers.Length; ++i)
        {
            villagers[i].GetAngry(UnityEngine.Random.Range(0, 0.5f));
        }
        _updateStateCallback = UpdateDelegate;
        dialogBox.finishedCallback = StoryCompleteDelegate;
        StartCoroutine(IntroStory());
    }

    private IEnumerator IntroStory()
    {
        _playerController.BlockInput();
        yield return new WaitForSecondsRealtime(2f);
        dialogBox.gameObject.SetActive(true);
        dialogBox.StartStory(openingStory);
    }

    private void OnExitIntro()
    {
        for (int i = 0; i < villagers.Length; ++i)
        {
            villagers[i].StopBeingAngry();
        }
        _playerController.ReleaseInput();
        _updateStateCallback = null;
        dialogBox.finishedCallback = null;
    }
}
