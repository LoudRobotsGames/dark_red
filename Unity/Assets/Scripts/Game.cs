using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public partial class Game : MonoBehaviour
{
    #region Singleton
    private static Game _instance = null;
    public Game Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Game>();
            }
            return _instance;
        }
    }
    #endregion

    #region Types
    public enum State
    {
        Intro,
        Exploration,
        Dialog,
        Combat,
        Boss,
        Win,
        Loss
    }
    #endregion

    public DialogBox dialogBox;
    public BackgroundAmbienceController _ambienceController;

    private State _currentState = State.Intro;

    public void Start()
    {
        EnterIntro();
    }

    private void EnterState(State state)
    {
        ExitState(_currentState);

        switch(state)
        {
            case State.Intro:
                OnEnterIntro();
                break;
            case State.Exploration:
                break;
            case State.Dialog:
                OnEnterDialog();
                break;
        }
    }

    private void ExitState(State state)
    {

    }

    private bool CanEnterState(State state)
    {
        return true;
    }
}
