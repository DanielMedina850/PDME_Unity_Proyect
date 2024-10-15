using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;


public class PlayerController : MonoBehaviour
{

    private Animator animator;
    public float speed = 10f;
    public float acceleration = 2;

    public float moveDrag = 2f;

    public float maxSpeed = 3f;
    
    private Rigidbody2D rb;

    private SpriteRenderer sp;
    public new Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();

         rb.drag = moveDrag;
        
    }

    // Update is called once per frame
    void Update()
    {
      float movimientoHorizontal =  Input.GetAxisRaw("Horizontal");
      float movimientoVertical =  Input.GetAxisRaw("Vertical");
      
        // if(movimientoHorizontal >= 0) {
        //     managementOrientation(false);
        // }else {
        //     managementOrientation(true);
        // }

        managementOrientation();

      

      if(movimientoHorizontal != 0 || movimientoVertical != 0){
       animator.SetFloat("Speed", 1);
      

      }else {
        animator.SetFloat("Speed", 0);
      }

    }


        void FixedUpdate()
    {
        // Obtener input del usuario
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        float movimientoVertical = Input.GetAxisRaw("Vertical");

        // Crear un vector de movimiento
        Vector2 movimiento = new Vector2(movimientoHorizontal, movimientoVertical).normalized;

        // Aplicar fuerza para movimiento con aceleración
        rb.AddForce(movimiento * acceleration);

        // Limitar la velocidad máxima del personaje
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
    }


    void managementOrientation(){
        // if(movimiento){
        //     sp.flipX = true;
        // }else {
        //     sp.flipX = false;
        // }

        
        float angle = GetAngleTowardsMouse();
        
        if(angle >= 90 && angle <= 270){
        sp.flipX = true;
        sp.sortingOrder = 0;
        }else {
            sp.flipX = false;
            sp.sortingOrder = 1;
        }
    }

    private float GetAngleTowardsMouse() {

        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 mouseDirection = mousePosition - transform.position;
        mouseDirection.z = 0;

        float angle = (Vector3.SignedAngle(Vector3.right, mouseDirection, Vector3.forward) + 360) % 360;

        return angle;
    }
}
