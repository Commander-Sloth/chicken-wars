using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{

	Rigidbody2D rb;

	bool hasHit = false;

    soundEffect sFX; 
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sFX = GetComponent<soundEffect>();
    }

    // Update is called once per frame
    void Update()
    {	
    	if(hasHit == false)
    	{
    		trackMovement();	
    	} 
    }

    void trackMovement()
    {
    	Vector2 direcction = rb.velocity;

    	float angle = Mathf.Atan2(direcction.y, direcction.x) * Mathf.Rad2Deg;
    	transform.rotation = Quaternion.AngleAxis(angle,Vector3.forward);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
    	hasHit = true;
    	rb.velocity = Vector2.zero;
    	rb.isKinematic = true;
        
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //soundEffect.PlaySound("boomSound");
        GetComponent<AudioSource>().Play(); 
        float delay = 1f;


        // Stop the projectile from moving.
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;

        // Hide the projectile, but we cannot delete it YET, until the animation and SFX are complete.
        gameObject.transform.localScale = new Vector3(0,0,0);

        Instantiate(impactEffect, transform.position, Quaternion.identity);

        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject, delay);
        }

        
        Destroy (gameObject, delay);
        //var enemyComponent = GetComponent<EnemyHealth>();
    }
}
