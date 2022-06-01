using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
public float fuerzaSalto;
private float Horizontal;
private Rigidbody2D rigidbody2D;

    private Animator animator;
  
    void Start()
    {

        animator = GetComponent<Animator>();
        rigidbody2D =GetComponent<Rigidbody2D>();
           }

   
    void Update()
    {


Horizontal = Input.GetAxisRaw("Horizontal");

if(Horizontal<0.0f) transform.localScale = new Vector3(-105.0f, 105.0f,105.0f );
else if (Horizontal > 0.0f) transform.localScale = new Vector3(105.0f, 105.0f,105.0f );

animator.SetBool("running",Horizontal != 0.0f);

     if (Input.GetKeyDown(KeyCode.Space))
     {
      animator.SetBool("Esta Saltando", true);  
      rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));    
     }   
    }
private void FixedUpdate()
{
    rigidbody2D.velocity = new Vector3(Horizontal*300, rigidbody2D.velocity.y );
}
}
