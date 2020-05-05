using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
    public float maxHealth = 100;
    private float currentHealth;
    
    public healthBarScript healthBar;
    
    public GameObject impactEffect;

    public AudioClip hurtSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
    	currentHealth = maxHealth;
      healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //pplyDamage(10);
        }
    }

   	public void ApplyDamage(float damage)
   	{
      SoundManager.instance.PlayClip(hurtSoundEffect);
   		damage = Mathf.Round(damage);
   		currentHealth -= damage;
   		healthBar.setHealth(currentHealth);

      if (currentHealth <= 0)
      {
        
        gameObject.transform.localScale = new Vector3(0,0,0);
        //Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject, 1f);
      }
   	}
}
