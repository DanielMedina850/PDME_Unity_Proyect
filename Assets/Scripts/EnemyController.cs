using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public GameObject player;
    public float speed;
    private float knockbackForce = 0.02f;
    private float knockbackDuration = 0.5f;
    public int vidaEnemigo = 3;

    public bool moreDamage = false;

    public AudioSource aS;



    private float distance;

    private SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        aS = GetComponent<AudioSource>();

    }


    void Update()
    {
        movimientoEnemigo();
    }

    void gestionarGiro(Vector2 direction){
        if(direction.x > 0){
            sp.flipX = false;
        }else if (direction.x < 0){
            sp.flipX = true;
        }
    }

    
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Player") && !GameManager.instance.playerIsDeath){
            Rigidbody2D playerRb = other.gameObject.GetComponent<Rigidbody2D>();

            Vector2 collisionNormal = other.contacts[0].normal;

            Vector2 knockbackDirection =- collisionNormal;

            playerRb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
            aS.Play();

            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            playerController.DesactivarMovimiento(knockbackDuration);
            GameManager.instance.quitarVidaJugador();
            GameManager.instance.comprobarVidaJugador();

        }


        if(other.gameObject.CompareTag("Bullet")){
            
            BulletController damageBullet = other.gameObject.GetComponent<BulletController>();

            Debug.Log("enemy: " + damageBullet.damage);
            vidaEnemigo-=damageBullet.damage;
            if(vidaEnemigo <= 0){
                Destroy(gameObject);
                GameManager.instance.incrementarCantidadEnemigos();
            }
        }
    }

    public void quitarVida(){
        vidaEnemigo--;
    }
    
    private void movimientoEnemigo(){
        if(!GameManager.instance.playerIsDeath){
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x);
        
        gestionarGiro(direction);

        
        
        
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        
        }

    }

    public int quitarVidaEnemigo{get { return this.vidaEnemigo; }}

}
