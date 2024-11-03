using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TextMEshPRo : MonoBehaviour
{
    public void cambiarEscena(string nombre){
        SceneManager.LoadScene(nombre);
    }

    public void exit(){
        Application.Quit();
    }
}
