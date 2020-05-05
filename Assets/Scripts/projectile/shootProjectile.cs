using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootProjectile : MonoBehaviour
{
    
    //public float LaunchForce;

    public GameObject projectileObj;
    public GameObject launchPointObj;

    private float power;
    //public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;

    dragLineScript tl;

    Camera cam;
    public Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    Vector3 currentPoint;

    launcherScript launcherScript;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        tl = GetComponent<dragLineScript>();
        //endOfWeapon = gameObject.transform.position;
        launcherScript = GetComponent<launcherScript>();
        power = launcherScript.forceFactor;
    }

    // Update is called once per frame
    void Update()
    {
        power = launcherScript.forceFactor;//LaunchForce;
        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     Shoot();
        // }

        if(Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
            //Shoot();
        }
        if(Input.GetMouseButton(0))
        {
            Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPoint.z = 15;
            //tl.RenderLine(startPoint, currentPoint);
            //force = new Vector2(Mathf.Clamp(currentPoint.x - startPoint.x, minPower.x, maxPower.x), Mathf.Clamp(currentPoint.y - startPoint.y , minPower.y, maxPower.y));
            
        }
        if(Input.GetMouseButtonUp(0))
        {
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;
            //tl.EndLine();

            //force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
        	force = startPoint - endPoint;
            GameObject projectileObjIns = Instantiate(projectileObj,  launchPointObj.transform.position, transform.rotation);

			projectileObjIns.GetComponent<Rigidbody2D>().AddForce(force * power, ForceMode2D.Impulse);
        }
        
    }

    // void Shoot() 
    // {
    //     GameObject projectileObjIns = Instantiate(projectileObj, transform.position, transform.rotation);

    //     projectileObjIns.GetComponent<Rigidbody2D>().velocity = (transform.right * LaunchForce); // AddForce(transform.right * LaunchForce);
    // }
}