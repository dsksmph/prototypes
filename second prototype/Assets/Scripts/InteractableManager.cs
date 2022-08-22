using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableManager : MonoBehaviour
{
    public InteractiveObject target;
    public static InteractableManager instance;
    
    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) == false) return;

        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1, 1<<7);
        if (hit)
        {
            var interactiveObject = hit.transform.gameObject.GetComponent<InteractiveObject>();
            target = interactiveObject;
        }
    }
}
