using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public partial class Game : MonoBehaviour
{
    public void EnterExploration()
    {
        if (CanEnterState(State.Exploration))
        {
            EnterState(State.Exploration);
        }
    }

    private void OnEnterExploration()
    {

    }
}
