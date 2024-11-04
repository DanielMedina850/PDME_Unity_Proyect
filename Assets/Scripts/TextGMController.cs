using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextMEshPRo : MonoBehaviour
{
    public void cambiarEscena(string nombre){
        SceneManager.LoadScene(nombre);
        if(GameManager.instance != null){
        GameManager.instance.gamePause = false;
        }
        Time.timeScale = 1f;
    }


    public void exit(){
        Application.Quit();
    }
}
