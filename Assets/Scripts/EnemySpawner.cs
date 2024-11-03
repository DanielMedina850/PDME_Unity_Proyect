using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Scripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    private float pointX, pointY;
    public GameObject player;

    public Transform[] puntos;
    public GameObject[] enemigos;
    public float tiempoEnemigos;
    private float tiempoSiguienteEnemigo;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int puntoRandom = Random.Range(0, puntos.Length);


        pointX = puntos[puntoRandom].transform.position.x;
        pointY = puntos[puntoRandom].transform.position.y;

        tiempoSiguienteEnemigo += Time.deltaTime;

        if(tiempoSiguienteEnemigo >= tiempoEnemigos){
            tiempoSiguienteEnemigo = 0;
            CrearEnemigo();
        }
    }


    private void CrearEnemigo(){
        int numeroEnemigo = Random.Range(0, enemigos.Length);
        Vector2 posicionAleatoria = new Vector2(pointX, pointY);

        GameObject enemy = Instantiate(enemigos[numeroEnemigo], posicionAleatoria, Quaternion.identity);
        enemy.GetComponent<EnemyController>().player = this.player;
    }
}
