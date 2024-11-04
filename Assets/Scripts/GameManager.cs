using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    private int VIDAS_JUGADOR = 5;
    private int ENEMIGOS_ELIMINADOS_lvl1 = 30;
    private int ENEMIGOS_ELIMINADOS_lvl2 = 60;
    private int cantidadEnemigos;
    private int vidaJugador;
    public Image barraDeVidas;
    private bool isDeath = false;

    private bool lvlSuperado = false;

    public Sprite VidaLlena;
    public Sprite VidaMediaLlena;
    public Sprite VidaMitad;
    public Sprite VidaMediaVacia;
    public Sprite VidaVacia;
    public Animator animator;

    public GameObject powerPotionIcon;


    public bool gamePause = false;
    public bool activePowerPotion = false;

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

    void Update(){
        gameOver();
        changePowerPotionIcon();
        nivelSuperado();
    }

    public int getVidasJugador { get {return VIDAS_JUGADOR;}}
    public bool playerIsDeath { get {return isDeath;}}


    public void quitarVidaJugador(){
        if(!isDeath) 
        vidaJugador--;
    }

    void actualizarBarraVida(){
        switch (vidaJugador) {
            case 5:
            barraDeVidas.sprite = VidaLlena;
            break;
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

    public void healPlayer(){
        vidaJugador = VIDAS_JUGADOR;
    } 

    private void changePowerPotionIcon(){
        if(powerPotionIcon != null){
            if(activePowerPotion){
                powerPotionIcon.SetActive(true);
            }else{
                powerPotionIcon.SetActive(false);
            }
        }
    }

    public void nivelSuperado(){
        if(cantidadEnemigos == ENEMIGOS_ELIMINADOS_lvl1 && !lvlSuperado){
            SceneManager.LoadScene("Level_2");
            cantidadEnemigos = 0;
            lvlSuperado = true;
        }else if( cantidadEnemigos == ENEMIGOS_ELIMINADOS_lvl2 && lvlSuperado){
            SceneManager.LoadScene("Winner");
        }
    }

    
    public void incrementarCantidadEnemigos(){
        cantidadEnemigos++;
    }

    private void gameOver(){
        if(vidaJugador <= 0){
            StartCoroutine(delayDeathAnimation());
        }
    }

    IEnumerator delayDeathAnimation(){
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene("Game_over");
        vidaJugador = VIDAS_JUGADOR;
    }


}
