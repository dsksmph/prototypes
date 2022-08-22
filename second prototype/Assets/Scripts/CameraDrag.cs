using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    private Vector3 dragOrigin;
    private Vector3 difference;
    private bool isDragging;
    private float xBound = 8;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            difference = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if (!isDragging)
            {
                isDragging = true;
                dragOrigin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else isDragging = false;

        if (isDragging)
        {
            Camera.main.transform.position = dragOrigin - difference;
        }

        ConstrainMovement();
    }

    void ConstrainMovement()
    {
        if (Camera.main.transform.position.x < -xBound) 
        { 
            Camera.main.transform.position = new Vector3(-xBound, transform.position.y, transform.position.z); 
        }

        if (Camera.main.transform.position.x > xBound)
        {
            Camera.main.transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }

        if ((Camera.main.transform.position.y < 0) || (Camera.main.transform.position.y > 0))
        {
            Camera.main.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
