using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jefe : MonoBehaviour
{
    public AudioClip SoundM;
    private Animator animator;
    public Rigidbody2D rb2D;
    public Transform jugador;
    private bool mirandoDerecha = true;
    
    [Header("Vida")]
    [Header("Ataque")]
    [SerializeField] private Transform controladorAtaqueJ; 
    [SerializeField] private float radioAtaque; 
     [SerializeField] private float dañoAtaque; 

    [SerializeField] private float vida; 
    [SerializeField] private BarraDeVida barraDeVida; 
     

    



    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        barraDeVida.InicializarBarraDeVida(vida);
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        float distanciaJugador = Vector2.Distance(transform.position, jugador.position);
        animator.SetFloat("distanciaJugador", distanciaJugador);
    }

    public void TomarDaño( float daño)
    {
        vida-= daño;
        barraDeVida.CambiarVidaActual(vida);
        
        if(vida<=0 )
        {
            animator.SetTrigger("Muerte");
            Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundM);
        }

        
    }

    private void Muerte()
    {
        //Destroy(gameObject);
         Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundM);
    }

    public void MirarJugador(){
      if((jugador.position.x > transform.position.x && !mirandoDerecha) || (jugador.position.x < transform.position.x && mirandoDerecha ))
        {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
      }

    }
   private void Ataque()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaqueJ.position, radioAtaque);

        foreach(Collider2D colision in objetos){
            if(colision.CompareTag("Player")){
                colision.GetComponent<CombateJugador>().TomarDaño(dañoAtaque);
            }
        }

       }


    private void  OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorAtaqueJ.position, radioAtaque);
        
    }

}

