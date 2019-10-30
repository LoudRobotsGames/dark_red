using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Vector2 velocity;
    public GameObject player;

    private Animator _animator;
    private Rigidbody2D _rb;
    private Vector3 _start;

    public void Start()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
        _start = transform.position;
    }

    [ContextMenu("Reset")]
    public void Reset()
    {
        _animator.SetBool("hit", false);
        transform.position = _start;
        this.enabled = true;
    }

    public void Update()
    {
        _rb.velocity = velocity;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        _animator.SetBool("hit", true);
        this.enabled = false;
        if (collision.gameObject == player)
        {
            
        }
        else
        {

        }
    }
}
