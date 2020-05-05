using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launcherScript : MonoBehaviour
{

    Vector2 Direction;

    shootProjectile shProScript;

    private Vector2 launchingForce;
    public GameObject launchPointObj;
    private Vector2 launchPoint;

    public int numberOfTrajectoryPoints = 20;
    public GameObject trajectoryDot; // This is the PreFab
    //public GameObject[] trajectoryDotsList;

    [SerializeField] GameObject dotsParent;
    [SerializeField] Transform[] trajectoryDotsList;

    Camera cam;
    private Vector3 startPoint;
    private Vector3 endPoint;
    private Vector3 currentPos;

    public Vector2 min_Power;
    public Vector2 max_Power;

    private Vector3 forceAtPlayer;
    public float forceFactor = 3f;

    [SerializeField]  float dotMinScale = 0.1f; // [Range(0.01f, 0.3f)]
    [SerializeField] float dotMaxScale = 3f; // [Range(0.3f, 3f)]

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        
        
        PrepareTrail();
        //trajectoryDotsList = new GameObject[numberOfTrajectoryPoints];

        launchPoint = launchPointObj.transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        launchPoint = launchPointObj.transform.position;
        //]]forceFactor = shProScript.power;//LaunchForce;

        // Use these to face the mouse
        //Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Vector2 bowPos = transform.position;
        //Direction = MousePos - bowPos; // Caclulate the direction.

        if(Input.GetMouseButtonDown(0)) // Click the mouse down.
        {
            // Set the coordinates of the START of the drag line.
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;     

            showTrail();
        }

        if(Input.GetMouseButton(0)) // Currently Dragging the mouse.
        {
            currentPos = cam.ScreenToWorldPoint(Input.mousePosition);
            currentPos.z = 15;
            
            // Caculate the launching force that will be applied.
            forceAtPlayer = currentPos - startPoint;
            //forceAtPlayer = shArrow.force;
            //forceAtPlayer = new Vector2(Mathf.Clamp((currentPos.x - startPoint.x), min_Power.x, max_Power.x), Mathf.Clamp((currentPos.y - startPoint.y), min_Power.y, max_Power.y));
            forceAtPlayer *= forceFactor;
            
            //rotateLauncher(startPoint - currentPos); //rotateLauncher(startPos - currentPos);//currentPos.z = 15;

            // Set the object coordinates to the current mouse Pos.
            //gameObject.transform.position = currentPos;

            updateDots();
        }

        if(Input.GetMouseButtonUp(0))
        {
            //GetComponent<AudioSource>().Play(); 
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            endPoint.z = 15;
            startPoint = transform.position; // Set the rotation of the shape back to normal since the shot is done.
            //rotateLauncher(new Vector2 (0,0));
            hideTrail();
            //print(gameObject.transform.rotation.eulerAngles.z);
        }
    }

    void rotateLauncher(Vector3 dir)
    {
        transform.right = dir;
        // Vector3 dirr;
        // dirr = currentPos - startPoint;
        
        // if (gameObject.transform.rotation.eulerAngles.z < 351 && gameObject.transform.rotation.eulerAngles.z > 90)
        // {
        //     transform.right = dirr;
        // {
        //print(gameObject.transform.rotation.eulerAngles.z);
        if (gameObject.transform.rotation.eulerAngles.z > 225 && gameObject.transform.rotation.eulerAngles.z < 351) 
        {
            //print(gameObject.transform.rotation.eulerAngles.z);
            gameObject.transform.localRotation = Quaternion.Euler(1,1,351);
            //gameObject.transform.Rotate(1, 1, 1); //gameObject.transform.localEulerAngles.z = 9.2;
            return;
        }
        if (gameObject.transform.rotation.eulerAngles.z > 90 && gameObject.transform.rotation.eulerAngles.z < 225) 
        {
            gameObject.transform.localRotation = Quaternion.Euler(1,1,90);
            return;
            //gameObject.transform.Rotate(0, 0, 90); //gameObject.transform.localEulerAngles.z = 90;
        }
        
    }
   
    public void updateDots()
    {
    	for (int i = 0; i < numberOfTrajectoryPoints; i++)
        {
        	//trajectoryDotsList[i]..trasnform.position
        	trajectoryDotsList[i].position = caclulatePosition(i * 0.1f); // This will display up to 10 second of the trajectory, not 1.	
        }
    }

    private Vector2 caclulatePosition(float elapsedTime)
    {
        // Launch from static postion.
        return launchPoint +
            new Vector2(-forceAtPlayer.x, -forceAtPlayer.y) * elapsedTime + 
            0.5f * Physics2D.gravity * elapsedTime * elapsedTime;

        // // Add ability to move launcher with mouse.
        // return new Vector2(currentPos.x, currentPos.y) +
        //     new Vector2(-forceAtPlayer.x, -forceAtPlayer.y) * elapsedTime + 
        //     0.5f * Physics2D.gravity * elapsedTime * elapsedTime;
    }

    void PrepareTrail()
    {
    	// Instantiate the trajectory Dots.
    	trajectoryDotsList = new Transform[numberOfTrajectoryPoints];
        trajectoryDot.transform.localScale = Vector3.one * dotMaxScale;

        float scale = dotMaxScale;
        float scaleFactor = scale / numberOfTrajectoryPoints;

        for (int i = 0; i < numberOfTrajectoryPoints; i++)
        {
           //trajectoryDotsList[i] = Instantiate(trajectoryDot, gameObject.transform);
		   trajectoryDotsList[i] = Instantiate(trajectoryDot, null).transform;
		   trajectoryDotsList[i].parent = dotsParent.transform;

           trajectoryDotsList[i].localScale = Vector3.one * scale;
           if (scale > dotMinScale)
            {
                scale -= scaleFactor;
            }
        }
        hideTrail();
    }

    public void showTrail()
    {
    	dotsParent.SetActive(true);
        print("SHOW");
    }

    public void hideTrail()
    {
    	dotsParent.SetActive(false);
        //dotsParent.enabled = false;
    }
}

// Credit to: https://www.youtube.com/watch?v=3DUmpVi82q8 (Bow and Arrow system)
// Credit to: https://www.youtube.com/watch?v=9n4nEP8yD0U (Angry Birds)
// Credit to: https://www.youtube.com/watch?v=Tsha7rp58LI (Drag + Shoot)
// Credit to: https://www.youtube.com/watch?v=fOzyXwoLNL4 (Trajectory Line)
// Credit to: https://youtube.com/watch?v=uKWbNWPAZq4 (Fire Projectiles)