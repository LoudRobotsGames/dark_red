using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public partial class Game : MonoBehaviour
{
    public void EnterCombat()
    {
        if (CanEnterState(State.Combat))
        {
            EnterState(State.Combat);
        }
    }

    private void OnEnterDialog()
    {
        dialogBox.gameObject.SetActive(true);
    }
}
