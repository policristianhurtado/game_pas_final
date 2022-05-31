using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{

    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Vector2 direccion;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float horizontal;
    private float vertical;
    
    
    void Start()
    {
        Rigidbody2D = transform.GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // Debug.Log("h: " + horizontal + ", v: " + vertical);
        
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        if (horizontal == 0.0f && vertical == 0.0f)
        {
            Animator.SetBool("Left", false);
            Animator.SetBool("Right", false);
            Animator.SetBool("Down", false);
            Animator.SetBool("Up", false);
        }
        
        if (horizontal < 0.0f)
        {
            Animator.SetBool("Down", false);
            Animator.SetBool("Up", false);
            Animator.SetBool("Left", true);
            Animator.SetBool("Right", false);
        }
        else if (horizontal > 0.0f)
        {
            Animator.SetBool("Down", false);
            Animator.SetBool("Up", false);
            Animator.SetBool("Left", false);
            Animator.SetBool("Right", true);
        }

        if (vertical < 0.0f)
        {
            Animator.SetBool("Down", true);
            Animator.SetBool("Up", false);
            Animator.SetBool("Left", false);
            Animator.SetBool("Right", false);
        }
        else if (vertical > 0.0f)
        {
            Animator.SetBool("Down", false);
            Animator.SetBool("Up", true);
            Animator.SetBool("Left", false);
            Animator.SetBool("Right", false);
        }
        
        // direccion = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        
        
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal * velocidadMovimiento, vertical * velocidadMovimiento);
    }
}
