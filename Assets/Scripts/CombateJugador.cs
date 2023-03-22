using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CombateJugador : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;
    [SerializeField] private BarraDeVida barraDeVida;

    public static bool vivo = true;

    void Start()
    {
    vida = maximoVida;    
    barraDeVida.InicializarBarraDeVida(vida);
    }

    public void TomarDaño(float daño){
        vida -= daño;
        barraDeVida.CambiarVidaActual(vida);
        if(vida<=0){
            SceneManager.LoadScene("MenuFinal");
            Destroy(gameObject);
            vivo = false;
            

        }
    }

    public void Curar(float curacion){
        if (vida + curacion> maximoVida)
        {
            vida = maximoVida;
        }else{
            vida += curacion;
        }
    }
}
