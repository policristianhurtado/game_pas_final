using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    // Velocidad de movimiento horizontal
    public float moveSpeed;

    // entrada horizontal
    private float inputHorizontal;

    // ¿El personaje mira a la derecha?
    private bool faceRight = true;

    private Rigidbody2D rb;
    private Animator anim;
	
	// Velocidad de salto
    public float jumpUpSpeed;
    // Si presionar la tecla de salto
    private bool jumpPressed = false;
	
	// Determina si tocar el suelo
    private bool isGrounded;
    // posición inferior del personaje
    public Transform groundCheck;
    // Radio de detección de toma de contacto
    private float checkRadius = 0.15f;
    // La máscara de capa del suelo
    public LayerMask whatIsGround;
	
	
	 // número de saltos permitidos
    public int allowJumpTimes;
    // Conteo de saltos aéreos
    private int airJumpCount;
	
	// Aceleración descendente múltiple
    public float fallGravityMultiplier = 2;
	
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		 airJumpCount = 0;
    }

    private void Update()
    {
        // Obtener entrada horizontal
        inputHorizontal = Input.GetAxisRaw("Horizontal");
		
		if(Input.GetButtonDown("Jump"))
		{
			jumpPressed = true;
		}
	
    }

    private void FixedUpdate()
    {
        // moverse horizontalmente
        Move();

        // Interruptor de estado de animación
        SwitchAnimState();
		
		//Saltar
		  Jump();
		  
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
		
		 if(isGrounded)
		{
			airJumpCount = 0;
		}
		
		// acelerar
        if (rb.velocity.y < 0)
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallGravityMultiplier - 1) * Time.fixedDeltaTime;

    }

    // Control de movimiento horizontal
    private void Move()
    {
        // moverse horizontalmente
        rb.velocity = new Vector2(inputHorizontal * moveSpeed, rb.velocity.y);
        // Control de orientación
        if (inputHorizontal > 0 && !faceRight || inputHorizontal < 0 && faceRight)
            Flip();
    }

    // Control de orientación
    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Control de conmutación de estado de animación
    private void SwitchAnimState()
    {
        anim.SetFloat("SpeedH", Mathf.Abs(rb.velocity.x));
        anim.SetBool("IsGrounded", isGrounded);
        anim.SetFloat("SpeedV", rb.velocity.y);
    }
	
	private void Jump()
    {
         if (jumpPressed)
        {
            jumpPressed = false;
            // No se permite saltar
            if (allowJumpTimes <= 0)
                return;
            // saltar del suelo
            else if (isGrounded && airJumpCount == 0)
            {
                rb.velocity = Vector2.up * jumpUpSpeed;
            }
            // Salta en el aire
            else if (airJumpCount < allowJumpTimes - 1)
            {
                rb.velocity = Vector2.up * jumpUpSpeed;
                airJumpCount++;
            }
        }
    }
}