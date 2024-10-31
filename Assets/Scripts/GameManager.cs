using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private int vidasJugador = 3;

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

    public int getVidasJugador { get {return vidasJugador;}}


    public void quitarVidaJugador(){
        vidasJugador--;
    }

    public void comprobarVidaJugador(){
        if(vidasJugador <= 0){
            Debug.Log("Game Over");
        }
    }
}
