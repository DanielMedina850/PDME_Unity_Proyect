using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float speed = 3;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void OnTriggerEnter2D(Collider2D collision) {
        Destroy(gameObject);
    }


    void FixedUpdate(){
        rb.MovePosition(transform.position + transform.right * speed * Time.fixedDeltaTime);
    }
}
