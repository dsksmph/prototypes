using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] garbagePrefabs;
    private float spawnRangeX = 12.0f;
    private float startDelay = 10.0f;
    private float spawnInterval = 10.0f;
    
    void Start()
    {
        for (int i = 0; i < Random.Range(3, 10); i++) SpawnRandomGarbage();
        InvokeRepeating("SpawnRandomGarbage", startDelay, spawnInterval);
    }

    void SpawnRandomGarbage()
    {
        int garbageIndex = Random.Range(0, garbagePrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), -2, 0);
        Instantiate(garbagePrefabs[garbageIndex], spawnPos, garbagePrefabs[garbageIndex].transform.rotation);
    }
}
