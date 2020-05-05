using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateWing : MonoBehaviour
{
    private Vector3 startPoint;
	private Vector3 currentPos;
	Camera cam;

	// Start is called before the first frame update
    void Start()
    {
	   cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetMouseButtonDown(0)) // Click the mouse down.
        {
            // Set the coordinates of the START of the drag line.
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;     
        }

        if(Input.GetMouseButton(0)) // Currently Dragging the mouse.
        {
            currentPos = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPos.z = 15;

            rotateTheWing(startPoint - currentPos);
        }

        if(Input.GetMouseButtonUp(0))
        {
            startPoint = transform.position;
             gameObject.transform.localRotation = Quaternion.Euler(0,0,0);//rotateTheWing(new Vector2 (0,0));
        }
    }

    void rotateTheWing(Vector3 dir)
    {
    	//dir += new Vector3(30,0,0);
    	
        transform.right += dir;

        if (gameObject.transform.rotation.eulerAngles.z > 225 && gameObject.transform.rotation.eulerAngles.z < 351) 
        {
           gameObject.transform.localRotation = Quaternion.Euler(1,1,351);
           //sreturn;
        }
        if (gameObject.transform.rotation.eulerAngles.z > 90 && gameObject.transform.rotation.eulerAngles.z < 225) 
        {
            gameObject.transform.localRotation = Quaternion.Euler(1,1,90);
            //return;
        }
        
        //gameObject.transform.localRotation = Quaternion.Euler(1,1,gameObject.transform.rotation.eulerAngles.z+30);

    }
}
