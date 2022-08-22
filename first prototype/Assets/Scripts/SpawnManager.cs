using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float spawnRange = 1.5f;
    GameObject player;
    private float boundX = -10f;
    private float boundY = 5f;
    private GameManager gameManager;
    private float enemySpawnTime = 5.0f;
    
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        
    }

    
    void Update()
    {
        if (!gameManager.isGameActive) StopCoroutine(SpawnEnemies());
    }

    public void StartSpawningEnemies(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }

    public IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemySpawnTime);
            SpawnEnemy();

        }
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        return new Vector3(player.transform.position.x + boundX, player.transform.position.y + boundY, Random.Range(-spawnRange, spawnRange));
    }
}
