using UnityEngine;
using System.Collections;
using System;

public class Barrel : MonoBehaviour, IAttackable
{
    public MeshRenderer brokenBarrel;
    private MeshRenderer meshRenderer;

    public void Attack()
    {
        meshRenderer.enabled = false;
        brokenBarrel.enabled = true;
    }

    // Use this for initialization
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        brokenBarrel.enabled = false;
    }
}
