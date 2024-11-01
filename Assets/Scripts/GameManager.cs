using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private int VIDAS_JUGADOR = 5;
    private int vidaJugador;
    public Image barraDeVidas;
    private bool isDeath = false;

    public Sprite VidaMediaLlena;
    public Sprite VidaMitad;
    public Sprite VidaMediaVacia;
    public Sprite VidaVacia;
    public Animator animator;
    public GameObject player;

    public static GameManager instance;

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    void Start(){
         vidaJugador = VIDAS_JUGADOR;
    }

    public int getVidasJugador { get {return VIDAS_JUGADOR;}}
    public bool playerIsDeath { get {return isDeath;}}


    public void quitarVidaJugador(){
        if(!isDeath) 
        vidaJugador--;
    }

    void actualizarBarraVida(){
        switch (vidaJugador) {
            case 4: 
            barraDeVidas.sprite = VidaMediaLlena;
            break;
            case 3: 
            barraDeVidas.sprite = VidaMitad;
            break;
            case 2:
            barraDeVidas.sprite = VidaMediaVacia;
            break;
            case 1:
            barraDeVidas.sprite = VidaVacia;
            break;
        }
    }

    public void comprobarVidaJugador(){
        actualizarBarraVida();
        if(vidaJugador <= 0 && !isDeath){
            isDeath = true;
            StartCoroutine(animationDeath());
        }
    }


    IEnumerator animationDeath(){
        animator.SetBool("isDeath", true);
        yield return new WaitForSeconds(0.01f);
        animator.SetBool("isDeath", false);
    } 
}
