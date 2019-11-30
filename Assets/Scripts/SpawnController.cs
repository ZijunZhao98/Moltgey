using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnController : MonoBehaviour
{

    public static SpawnController instance;

    public Transform[] spawnPoints;

    public GameObject enemyPrefabs;

    public int spawnLimit;
    // Start is called before the first frame update

    public float timeElapsed = 0.0f;
    public float interval = 3.0f;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= interval && spawnLimit<=20)
        {
            spawnEnemy();
            timeElapsed = 0.0f;
        }

        
    }

    void spawnEnemy()
    {

        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(enemyPrefabs, randomSpawnPoint.position, Quaternion.identity);
    }

}
