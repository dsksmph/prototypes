using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private Rigidbody enemyRb;
    GameObject player;
    [SerializeField] private float speed = 1.0f;
    private float xDestroy = 0.5f;
    private GameManager gameManager;
    
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    
    void Update()
    {
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);

        if (transform.position.x > player.transform.position.x + xDestroy)
        {
            if(gameManager.isGameActive) gameManager.UpdateScore(1);
            Destroy(gameObject);
        }
    }
}
