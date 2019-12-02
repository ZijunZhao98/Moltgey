using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public float speed = 0.125f;
    public Vector3 offset = new Vector3(0, 0, -10);

    private void LateUpdate()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if(players.Length != 0)
        {
            transform.position = GameObject.FindWithTag("Player").transform.position + offset;
        }
    }
}
