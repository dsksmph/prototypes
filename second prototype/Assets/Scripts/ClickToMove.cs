using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToMove : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f;
    public Animator animator;
    public bool isMoving;
    private bool needToFlip;
    private SpriteRenderer spriteRenderer;
    private bool isOnScreen;
    Coroutine moveToPositionCoroutine;
    
    void Start()
    {
        isMoving = false;
        needToFlip = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FollowCamera());
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 targetPosition;
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1, 1 << 6);
            if (hit)
            {
                targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                targetPosition.z = transform.position.z;
                targetPosition.y = transform.position.y;
                if (moveToPositionCoroutine != null) StopCoroutine(moveToPositionCoroutine);
                moveToPositionCoroutine = StartCoroutine(MoveToPosition(targetPosition));
            }
        }
        
    }

    IEnumerator MoveToPosition(Vector3 destination)
    {
        float distanceToTarget = 1000f;
        isMoving = true;
        animator.SetBool("IsMoving", isMoving);

        if (transform.position.x > destination.x && needToFlip == false)
        {
            spriteRenderer.flipX = true;
            needToFlip = true;
        }
        else if (transform.position.x < destination.x && needToFlip == true)
        {
            spriteRenderer.flipX = false;
            needToFlip = false;
        }

        while (distanceToTarget > 0.2f)
        {
            distanceToTarget = Vector3.Distance(transform.position, destination);
            transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * speed);
            yield return null;
        }
        isMoving = false;
        animator.SetBool("IsMoving", isMoving);
    }

    IEnumerator FollowCamera()
    {
        while (true)
        {
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
            isOnScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
            if (!isOnScreen)
            {
                RaycastHit2D hit = Physics2D.Raycast(new Vector3(Camera.main.transform.position.x, transform.position.y, transform.position.z), Vector2.zero, 1, 1 << 6);
                if (hit)
                {
                    if (moveToPositionCoroutine != null) StopCoroutine(moveToPositionCoroutine);
                    moveToPositionCoroutine = StartCoroutine(MoveToPosition(hit.point));
                }
            }
            yield return new WaitForSeconds(1);
        }
    }
}
