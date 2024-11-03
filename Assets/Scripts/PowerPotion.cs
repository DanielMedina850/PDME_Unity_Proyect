using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandecyPotion : MonoBehaviour
{
  public int damageIncrease = 2;  
    public float duration = 5f;   
    public float fadeDuration = 1f;

    private bool potionCollect = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player")) 
        {
            
            WeaponController weaponController = other.gameObject.GetComponentInChildren<WeaponController>();
            GameManager.instance.activePowerPotion = true;
            if (weaponController != null && !potionCollect)
            {
                potionCollect = true;
                weaponController.IncreaseBulletDamage(damageIncrease); 
                StartCoroutine(RemoveDamageBoost(weaponController)); 
                StartCoroutine(FadeOutAndDestroy());
            }
        }
    }

    private IEnumerator FadeOutAndDestroy()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Color color = spriteRenderer.color;


        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDuration;
            color.a = Mathf.Lerp(1, 0, normalizedTime); 
            spriteRenderer.color = color;
            yield return null; 
        }

        color.a = 0;
        spriteRenderer.color = color;

    }

    private IEnumerator RemoveDamageBoost(WeaponController weaponController)
    {
        yield return new WaitForSeconds(duration);
        weaponController.ResetBulletDamage();
        GameManager.instance.activePowerPotion = false; 
        Destroy(gameObject);
    }
}
