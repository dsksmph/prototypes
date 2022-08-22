using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsManager : MonoBehaviour
{
    public List<Transform> stairs;
    public float stairsSpeed = 1.0f;
    [SerializeField] private Vector3 moveDir;
    [SerializeField] private float yBound = -10.0f;
    [SerializeField] private float xBound = 5;
    [SerializeField] private Vector3 startPos;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Update()
    {
        MoveStairs();
        RepeatStairs();
    }

    void MoveStairs()
    {
        if (gameManager.isGameActive)
        {
            for (int i = 0; i < stairs.Count; i++)
            {
                stairs[i].transform.position += moveDir * stairsSpeed * Time.deltaTime;
            }
        }
    }

    void RepeatStairs()
    {
        for (int i = 0; i < stairs.Count; i++)
          {
              if (stairs[i].position.y < yBound || stairs[i].position.x > xBound)
              {
                    stairs[i].position = startPos;
              }
          }
        
    }
}
