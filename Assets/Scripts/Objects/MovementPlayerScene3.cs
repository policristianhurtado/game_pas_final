using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WindowsInput;

public class MovementPlayerScene3 : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private Vector2 direccion;
    [SerializeField] private float jump_force;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float horizontal;
    private float vertical;
    private bool grounded;

    void Start()
    {
        Rigidbody2D = transform.GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }
    
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        // InputSimulator inputSimulator = new InputSimulator();
        // inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_D);

        // transform.localScale = new Vector3(1.0f,);
        if (horizontal == 0.0f)
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
        
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(horizontal * velocidadMovimiento, Rigidbody2D.velocity.y);
    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * jump_force);
    }
}
