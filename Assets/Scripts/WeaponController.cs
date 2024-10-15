using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

using Vector3 = UnityEngine.Vector3;

public class WeaponController : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;

    public new Camera camera;

    // Start is called before the first frame update
    void Start()
    {
     spriteRenderer = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        rotateWeapon();
    }


    private void rotateWeapon(){

        float angle = GetAngleTowardsMouse();
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if(angle >= 90 && angle <= 270){
        spriteRenderer.flipY = true;
        spriteRenderer.sortingOrder = 1;
        }else {
            spriteRenderer.flipY = false;
            spriteRenderer.sortingOrder = 0;
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
