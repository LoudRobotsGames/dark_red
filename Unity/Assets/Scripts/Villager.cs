using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Villager : MonoBehaviour
{
    private int ANGRY = Animator.StringToHash("Angry");

    public bool isAngry = false;

    private Animator _animator;
    
    public void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void GetAngry(float offset)
    {
        Invoke("SetIsAngry", offset);
    }

    public void StopBeingAngry()
    {
        ClearIsAngry();
    }

    private void SetIsAngry()
    {
        isAngry = true;
    }

    private void ClearIsAngry()
    {
        isAngry = false;
    }

    public void Update()
    {
        _animator.SetBool(ANGRY, isAngry);
    }
}
