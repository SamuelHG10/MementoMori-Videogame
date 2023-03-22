using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAt : MonoBehaviour
{
    public AudioClip SoundM;
    [SerializeField] private float vida; 
    private Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    public void TomarDaño( float daño)
    {
        vida-= daño;
        if(vida<=0 )
        {
            Muerte();
        }

        
    }

    
    private void Muerte()
    {
        animator.SetTrigger("Muerte");
         Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundM);
        
    }
}
