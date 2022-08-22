using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameManager gameManager;
    [SerializeField] private float thrustX = 1f;
    [SerializeField] private float thrustY = 2f;
    [SerializeField] private float thrustZ = 0f;
    [SerializeField] private float gravityModifier;
    private float jumpCount = 0;
    private float movementBound = 2;
    private float xBound = 0;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Update()
    {
        if (gameManager.isGameActive) MovePlayer();
        ConstrainPlayerMovement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        jumpCount = 0;

        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameManager.GameOver();
        }
    }

    private void ConstrainPlayerMovement()
    {
        if (transform.position.z < -movementBound) transform.position = new Vector3(transform.position.x, transform.position.y, -movementBound);
        if (transform.position.z > movementBound) transform.position = new Vector3(transform.position.x, transform.position.y, movementBound);
        if (transform.position.x > xBound) transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
    }

    private void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount < 2)
        {
            playerRb.AddForce(thrustX, thrustY, 0, ForceMode.Impulse);
            jumpCount++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && jumpCount < 2)
        {
            playerRb.AddForce(0, thrustY, -thrustZ, ForceMode.Impulse);
            jumpCount++;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) && jumpCount < 2)
        {
            playerRb.AddForce(0, thrustY, thrustZ, ForceMode.Impulse);
            jumpCount++;
        }
    }
}
