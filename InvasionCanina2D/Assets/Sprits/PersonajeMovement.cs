using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeMovement : MonoBehaviour
{

    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded = true;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if(Horizontal<0.0f) transform.localScale = new Vector3 (-2.0f, 2.0f, 1.0f);
        else if(Horizontal>0.0f) transform.localScale = new Vector3(2.0f, 2.0f, 1.0f);
        Animator.SetBool("running", Horizontal != 0.0f);

        Debug.DrawRay(transform.position, Vector3.down * 1f, Color.cyan);

        if (Physics2D.Raycast(transform.position, Vector3.down, 1f))
        {
            Grounded = true;
        }
        else { 
            Grounded = false;
        }

        // Salto
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))&& Grounded)
        {
            Jump();
        }

    }

    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2 (Horizontal * Speed, Rigidbody2D.velocity.y );
    }
}
