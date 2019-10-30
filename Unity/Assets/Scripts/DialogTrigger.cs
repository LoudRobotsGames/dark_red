using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public DialogBox dialogBox;
    public Villager villager;
    public TextAsset firstEncounter;
    public TextAsset repeatEncounter;
    
    private PlayerController _player;
    private bool _gainedTrust = false;
    private bool _encountered = false;

    public void Start()
    {

    }

    public bool AttemptDialog(PlayerController player)
    {
        Transform t = player.transform;
        int playerDir = (int)Mathf.Sign(t.localScale.x);
        int villagerDir = (int)Mathf.Sign(villager.transform.localScale.x);

        if (playerDir == villagerDir)
            return false;

        dialogBox.gameObject.SetActive(true);
        TextAsset inkStory = firstEncounter;
        if (_encountered)
        {
            inkStory = repeatEncounter;
        }
        if (_gainedTrust)
        {
            return true;
        }

        _encountered = true;
        if (inkStory == null)
        {
            return false;
        }
        dialogBox.StartStory(inkStory);
        player.BlockInput();
        dialogBox.finishedCallback = OnStoryComplete;
        _player = player;

        return true;
    }

    private void OnStoryComplete()
    {
        dialogBox.gameObject.SetActive(false);

        _gainedTrust = dialogBox.GetBoolVariable("gain_trust", false);
        if (_gainedTrust)
            Game.Instance.torchCount++;

        _player.ReleaseInput();   
    }
}
