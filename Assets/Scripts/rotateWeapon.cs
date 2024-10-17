using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateWeapon : MonoBehaviour
{

    public Transform    target;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  
    }

    // Update is called once per frame
    void Update()
    {
        gestionarSprite();
    }


    void gestionarSprite(){
        Vector3 currentEuler = transform.rotation.eulerAngles;
        float angle = currentEuler.z;
        Debug.Log(angle);

        /* Gestiono el posicionamiento de capas con el arma */
        if(angle >= 0 && angle <= 180){
            spriteRenderer.sortingOrder = 0;
        }else {
            spriteRenderer.sortingOrder = 1;
        }

        /* Gestiono el posicionamiento correcto del arma en Y*/
        if(angle >= 90 && angle <= 270){
        spriteRenderer.flipY = true;
        
        }else{
            spriteRenderer.flipY = false;   
            
        }
    }
}
