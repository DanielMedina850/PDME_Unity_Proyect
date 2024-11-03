using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Potion : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            GameManager.instance.healPlayer();
            GameManager.instance.comprobarVidaJugador();
            Destroy(gameObject);
        }
    }
}
