using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UIElements;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;


public class PlayerController : MonoBehaviour
{

    private Animator animator;

    public float acceleration = 2;

    public float moveDrag = 2f;

    public float maxSpeed = 3f;

    public ParticleSystem particulas;
    
    private Rigidbody2D rb;

    private SpriteRenderer sp;
    public new Camera camera;


    private  Vector3 mousePosition;
    private  Vector3 mouseDirection;
    private Vector2 movimiento;

    private float dashTime = 0.2f;  // Un dash más corto
    public float dashForce = 900;  // Aumentar la fuerza del dash

    private float timeCanDash = 1f;
    private bool isDashing = false;
    private bool canDash = true;
    private bool canMove = true;




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

        if(GameManager.instance.playerIsDeath){
            canMove = false;
        }

        if(!isDashing && canMove){
        particulas.Pause();
        }

        float movimientoHorizontal =  Input.GetAxisRaw("Horizontal");
        float movimientoVertical =  Input.GetAxisRaw("Vertical");

        managementOrientation();

        if(movimientoHorizontal != 0 || movimientoVertical != 0){
                animator.SetFloat("Speed", 1);
        }else {
                animator.SetFloat("Speed", 0);
        } 

        if (Input.GetMouseButtonDown(1) && canDash) {
            StartCoroutine(Dash());   
        }
    }


        void FixedUpdate()
    {
         if(!isDashing && canMove){
        // Obtener input del usuario
        float movimientoHorizontal = Input.GetAxisRaw("Horizontal");
        float movimientoVertical = Input.GetAxisRaw("Vertical");


        // Crear un vector de movimiento
        movimiento = new Vector2(movimientoHorizontal, movimientoVertical).normalized;

        // Aplicar fuerza para movimiento con aceleración
        // rb.AddForce(movimiento * acceleration);
        rb.velocity = new Vector2(movimiento.x * 350, movimiento.y * 350);


        // Limitar la velocidad máxima del personaje
        // rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxSpeed);
        
         }
    }


    void managementOrientation(){

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

        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

        mouseDirection = mousePosition - transform.position;
        mouseDirection.z = 0;

        float angle = (Vector3.SignedAngle(Vector3.right, mouseDirection, Vector3.forward) + 360) % 360;

        return angle;
    }


    private IEnumerator Dash() {

        
        isDashing = true;
        canDash = false;
        rb.velocity = new Vector2(movimiento.x * dashForce, movimiento.y * dashForce);
        particulas.Play();
        yield return new WaitForSeconds(dashTime);
        isDashing = false;
        particulas.Clear();
        particulas.Pause();
        yield return new WaitForSeconds(timeCanDash);
        canDash = true;
    }

    public void DesactivarMovimiento(float duration){
        StartCoroutine(DisableMovementCoroutine(duration));
    }

    private IEnumerator DisableMovementCoroutine(float duration){
        canMove = false;
        yield return new WaitForSeconds(duration);
        canMove = true;
    }


}
