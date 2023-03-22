using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtagonistaMovimiento : MonoBehaviour
{
    public AudioClip SoundJ;
    public float Speed;
    public float JumpForce;
    private Rigidbody2D Rigidbody2D; 
    private float Horizontal;
    public bool Grounded;
    private Animator Animator;


    void Start()
    {
    Rigidbody2D = GetComponent<Rigidbody2D>();
    Animator = GetComponent<Animator>();
    }

   
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if(Horizontal<0.0f) transform.localScale = new Vector3(-1.0f,1.0f,1.0f);
        else if (Horizontal>0.0f) transform.localScale = new Vector3(1.0f,1.0f,1.0f);
        

        

        Animator.SetBool("Running",Horizontal != 0.0f);

       Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
       if(Physics2D.Raycast(transform.position, Vector3.down, 0.15f))
       {
       Grounded = true;
       }
       else Grounded = false; 


        if(Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
            Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundJ);
        }
    }

private void Jump(){
    Rigidbody2D.AddForce(Vector2.up*JumpForce);
}

    private void FixedUpdate() {
    Rigidbody2D.velocity = new Vector2(Horizontal*Speed,Rigidbody2D.velocity.y);

    }
}
