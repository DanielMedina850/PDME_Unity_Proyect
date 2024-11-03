using System;
using System.Collections;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class WeaponController : MonoBehaviour
{


    public new Camera camera;

    public GameObject bulletPrefab;
    public Transform spawner;

     private Boolean canShoot = true;

     public int bulletDamage = 1;

     public float delayShoting = 0.180F;
     private int originalBulletDamage;

    

    void Start()
    {
        originalBulletDamage = bulletDamage; 
    }

    void Update()
    {
        if(!GameManager.instance.gamePause){
        rotateWeapon();
        CheckFiring();
        }
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

            bullet.GetComponent<BulletController>().IncreaseDamage(bulletDamage);
            
            bullet.transform.position = spawner.position;
            bullet.transform.rotation = transform.rotation;
            canShoot = false;
            Destroy(bullet, 2f);
            StartCoroutine(ShootDelay());
        }
    }



      IEnumerator ShootDelay()
  {

    yield return new WaitForSeconds(delayShoting);
    canShoot = true;
  }

      public void IncreaseBulletDamage(int amount)
    {
        bulletDamage += amount; // Método para aumentar el daño de la bala
    }

        public void ResetBulletDamage()
    {
        bulletDamage = originalBulletDamage; 
    }
}
