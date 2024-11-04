using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Potion : MonoBehaviour
{

    private AudioSource aS;


    void Start(){
        aS = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            aS.Play();
            GameManager.instance.healPlayer();
            GameManager.instance.comprobarVidaJugador();
            Destroy(gameObject);
        }
    }
}
