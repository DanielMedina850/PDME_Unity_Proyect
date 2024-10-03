using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using Vector2 = UnityEngine.Vector2;


public class PlayerController : MonoBehaviour
{

    private Animator animator;
    Transform transform;
    public float speed;

    private SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
      float movimientoHorizontal =  Input.GetAxisRaw("Horizontal");
      
        if(movimientoHorizontal >= 0) {
            managementOrientation(false);
        }else {
            managementOrientation(true);
        }



      float movimientoVertical =  Input.GetAxisRaw("Vertical");

      if(movimientoHorizontal != 0 || movimientoVertical != 0){
       animator.SetFloat("Horizontal", movimientoHorizontal);
       animator.SetFloat("Vertical", movimientoVertical);
       animator.SetFloat("Speed", 1);


       Vector2 direction = transform.position;
       direction.x = direction.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime;
       direction.y = direction.y + Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position = direction;

      }else {
        animator.SetFloat("Speed", 0);
      }

    }


    void managementOrientation(Boolean movimiento){
        if(movimiento){
            sp.flipX = true;
        }else {
            sp.flipX = false;
        }
    }
}
