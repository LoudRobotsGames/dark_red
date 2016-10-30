using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public partial class Game : MonoBehaviour
{
    public AudioSource openingStab;

    public void EnterIntro()
    {
        if (CanEnterState(State.Intro))
        {
            EnterState(State.Intro);
        }
    }

    private void OnEnterIntro()
    {
        if (openingStab != null)
        {
            openingStab.Play();
        }
        dialogBox.gameObject.SetActive(false);
    }
}
