using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject GameOver;
    CombateJugador combateJugador;
    public static GameOverManager gameOverManager;

    // Start is called before the first frame update
    void Start()
    {
        gameOverManager = this;
        combateJugador = GameObject.FindObjectOfType<CombateJugador>();
    }

    public void CallGameOver () {
        GameOver.SetActive(true);
    }

    public void Reiniciar () {
        
        SceneManager.LoadScene("PrimerNivel");
        CombateJugador.vivo = true;
        
        
    }

      public void Salir(){
        Debug.Log("Salir...");
        Application.Quit();
    }
}
