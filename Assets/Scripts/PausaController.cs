using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausa : MonoBehaviour
{

    public GameObject botonPausa;
    public GameObject menuPausa;
    public GameObject damageIcon;
    public void pause(){
        
        GameManager.instance.gamePause = true;
        Time.timeScale = 0f;
            
        botonPausa.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void reanudar(){
        GameManager.instance.gamePause = false;
        Time.timeScale = 1f;
        botonPausa.SetActive(true);
        menuPausa.SetActive(false);
    }
}
