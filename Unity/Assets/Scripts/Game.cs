using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class Game : MonoBehaviour
{
    #region Singleton
    private static Game _instance = null;
    public static Game Instance
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
        Setup,
        Intro,
        Exploration,
        Dialog,
        Cellar,
        Combat,
        Boss,
        Win,
        Loss
    }
    public delegate void UpdateState();
    #endregion

    [Header("Default")]
    public GameObject town;
    public DialogBox dialogBox;
    public Image fadeCurtain;
    public BackgroundAmbienceController _ambienceController;
    public PlayerController _playerController;

    private State _currentState = State.Setup;
    private UpdateState _updateStateCallback;
    private int _trust = 20;

    public int Trust
    {
        get
        {
            return _trust;
        }
        set
        {
            _trust = value;
        }
    }

    public void Update()
    {
        if (_updateStateCallback != null)
        {
            _updateStateCallback();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            torchCount = 1;
            EnterCellar();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            torchCount = 2;
            EnterCellar();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            torchCount = 3;
            EnterCellar();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            torchCount = 4;
            EnterCellar();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            torchCount = 5;
            EnterCellar();
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            if (_currentState == State.Cellar)
                EnterExploration();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Splash");
        }
    }

    public void Start()
    {
        EnterIntro();
    }

    private void EnterState(State state)
    {
        ExitState(_currentState);

        switch (state)
        {
            case State.Intro:
                OnEnterIntro();
                break;
            case State.Exploration:
                OnEnterExploration();
                break;
            case State.Dialog:
                OnEnterDialog();
                break;
            case State.Cellar:
                OnEnterCellar();
                break;
        }
        _currentState = state;
    }

    private void ExitState(State state)
    {
        switch (state)
        {
            case State.Intro:
                OnExitIntro();
                break;
            case State.Cellar:
                OnExitCellar();
                break;
        }
    }

    private bool CanEnterState(State state)
    {
        return true;
    }
}
