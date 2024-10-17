using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

using Vector3 = UnityEngine.Vector3;

public class WeaponController : MonoBehaviour
{


    public new Camera camera;

    public GameObject bulletPrefab;
    public Transform spawner;

     private Boolean canShoot = true;
    
    void Update()
    {
        rotateWeapon();
        CheckFiring();
    }


    private void rotateWeapon(){

        float angle = GetAngleTowardsMouse();
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }   

    private float GetAngleTowardsMouse() {

        Vector3 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePosition - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        return rotZ;
    }

    private void CheckFiring() {
        if(Input.GetMouseButtonDown(0) && canShoot == true){
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.transform.position = spawner.position;
            bullet.transform.rotation = transform.rotation;
            canShoot = false;
            Destroy(bullet, 2f);
            StartCoroutine(ShootDelay());
        }
    }


      IEnumerator ShootDelay()
  {
    yield return new WaitForSeconds(0.250F);
    canShoot = true;
  }
}
