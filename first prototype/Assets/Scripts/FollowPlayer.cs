using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 offset;

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
