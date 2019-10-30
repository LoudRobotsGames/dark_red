using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Priest : MonoBehaviour
{
    public Fireball fireball;

    public void Start()
    {
        if (fireball)
        {
            fireball.gameObject.SetActive(false);
        }
    }    

    public void ThrowFireball()
    {
        if( fireball != null)
        {
            fireball.gameObject.SetActive(true);
            fireball.Reset();
        }
    }
}
