using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartSC : MonoBehaviour
{
     public AudioClip SoundR;
    private void  OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player"){
            Camera.main.GetComponent<AudioSource>().PlayOneShot(SoundR);
            SceneManager.LoadScene(3);
        }
        
    }


}
