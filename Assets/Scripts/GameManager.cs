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

    public Sprite VidaMediaLlena;
    public Sprite VidaMitad;
    public Sprite VidaMediaVacia;
    public Sprite VidaVacia;

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


    public void quitarVidaJugador(){
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
        Debug.Log("hola");
        actualizarBarraVida();
        if(vidaJugador <= 0){
            Debug.Log("Game Over");
        }
    }
}
