using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ataque : MonoBehaviour
{
    public AudioClip SoundA;
    [SerializeField] private Transform controladorGolpe;

    [SerializeField] private float radioGolpe;
    
    [SerializeField] private float dañoGolpe;
    [SerializeField] private float tiempoEntre;
    [SerializeField] private float tiempoSiguiente;
    private Animator animator;


   private void Start(){
      animator = GetComponent<Animator>();
    }
    private void Update(){

        if (tiempoSiguiente>0)
        {
            tiempoSiguiente -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Fire1") && tiempoSiguiente<=0)
        {
            golpe();
            tiempoSiguiente = tiempoEntre;
             Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundA);
        }
    }

    private void golpe(){
        animator.SetTrigger("Ataque");
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);

        foreach (Collider2D colisionador in objetos)
        {
            if(colisionador.CompareTag("Enemigo"))
            {
                colisionador.transform.GetComponent<EnemigoAt>().TomarDaño(dañoGolpe);
            }
        }
    }   


private void OnDrawGizmos() {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
}
}