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
    public float speed;

    public float moveDrag = 1f;
    public float stopDrag = 25f;
    
    private Rigidbody2D rb;

    private SpriteRenderer sp;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
        rb.drag = moveDrag;

      rb.AddForce(Vector2.right * movimientoHorizontal * Time.deltaTime);
      rb.AddForce(Vector2.up * movimientoVertical * Time.deltaTime);

      }else {
        animator.SetFloat("Speed", 0);
        rb.drag = stopDrag;
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
