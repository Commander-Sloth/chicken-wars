using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{

	Rigidbody2D rb;

	bool hasHit = false;

    public GameObject impactEffect;

    public float weaponRadius;
    //public float weaponDelay;

    public AudioClip soundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Invoke("explodeMe", weaponDelay);//this will happen after 2 seconds
        Destroy(gameObject, 7f); // Automatically get rid of this projectile if it flew off the screen and has nothing to collide with.
    }

    // Update is called once per frame
    void Update()
    {	
    	if(hasHit == false)
    	{
    		rotateToMovement();	
    	}
        //AreaDamageEnemies(transform.position, 700, 30);
    }

    void rotateToMovement()
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
        explodeMe();  
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // { 
    //     // explodeMe();
    // }

    private void explodeMe()
    {
        SoundManager.instance.PlayClip(soundEffect);

        float delay = 1f;
        
        // Stop the projectile from moving.
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;

        // Hide the projectile, but we cannot delete it YET, until the animation and SFX are complete.
        gameObject.transform.localScale = new Vector3(0,0,0);

        Instantiate(impactEffect, transform.position, Quaternion.identity);

        AreaDamageEnemies(transform.position, 3, 10); // make float radius, float damage)


        Destroy (gameObject, delay);
    }

    private void AreaDamageEnemies(Vector3 location, float radius, float damage)
    {
        Debug.Log("hitColliders[i].name");
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);
        
        for (int i = 0;  i < hitColliders.Length; i++)
        {
             Debug.Log(hitColliders[i].name);
             float distance = Vector2.Distance(hitColliders[i].transform.position, transform.position);
             if (distance <= radius)
             {
                Debug.Log(hitColliders[i].name);
                hitColliders[i].SendMessage("ApplyDamage", damage * 1/distance, SendMessageOptions.DontRequireReceiver); //send message damage + damage variable
             }
        }
    
            // Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            // float force = 100f;
            // if (rb != null)
            // {
            //     rb.AddExplosionForce(force, transform.position, radius);
            // }

        // Get some coins based off of the damage dealt
    }

    //     // Original: https://answers.unity.com/questions/14207/how-to-apply-explosionmagicgrenade-damage-to-detec.html
    //     // Detect a wall?: https://answers.unity.com/questions/15838/how-can-i-apply-damage-based-on-a-grenade-explosio.html?_ga=2.196159084.194902545.1588331220-189399078.1588009198
}
