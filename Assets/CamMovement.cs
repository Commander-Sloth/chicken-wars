using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{	

    private Vector3 pos;

    private float speed;

    private Camera cam;
    
    // Start is called before the first frame update
    void Start()
    {
        pos.z = -10;
        speed = 15;
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = pos;
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            pos.y += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            pos.y -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            pos.x -= speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W))
        {
            cam.orthographicSize -= speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (cam.orthographicSize > 0)
            {
                cam.orthographicSize += speed * Time.deltaTime;
            }          
        }
    }
}
