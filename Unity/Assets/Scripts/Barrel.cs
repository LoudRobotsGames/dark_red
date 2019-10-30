using UnityEngine;
using System.Collections;
using System;

public class Barrel : MonoBehaviour, IAttackable
{
    public MeshRenderer brokenBarrel;
    private MeshRenderer meshRenderer;
    private BoxCollider2D boxCollider;

    public void Attack()
    {
        meshRenderer.enabled = false;
        brokenBarrel.enabled = true;
        boxCollider.enabled = false;
    }

    // Use this for initialization
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        brokenBarrel.enabled = false;
    }
}
