using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
	private Animator anim;

    public float maxHealth = 100;
    private float currentHealth;
    
    public healthBarScript healthBar;

    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator>();
       currentHealth = maxHealth;
       healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //TakeDamage(10);
            anim.SetBool("isAiming", true);
			anim.enabled = false;
        }
        if(Input.GetMouseButtonUp(0))
        {
            anim.SetBool("isAiming", false);
            anim.enabled = true;
        }
    }

    void TakeDamage(float dam)
    {
        currentHealth -= dam;

        healthBar.setHealth(currentHealth);
    }

    public void ApplyDamage(float damage)
    {
        //SoundManager.instance.PlayClip(hurtSoundEffect);
        damage = Mathf.Round(damage);
        currentHealth -= damage;
        healthBar.setHealth(currentHealth);

      // if (currentHealth <= 0)
      // {
      //   
      // }
    }
}
