using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnController : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject enemyPrefabs;

    public int spawnLimit;
    // Start is called before the first frame update

    public float timeElapsed = 0.0f;

    // configuration
    public float spawnDelay = 5.0f;
    public int enemyCounter = 10;

    void Start()
    {
        StartCoroutine("enemySpawnTimer");
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        
    }

    IEnumerator enemySpawnTimer()
    {
        yield return new WaitForSeconds(spawnDelay);
        //spawn
        spawnEnemy();
        enemyCounter--;
        //repeat
        if(enemyCounter > 0)
        {
            StartCoroutine("enemySpawnTimer");
        }
        
    }

    void spawnEnemy()
    {

        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(enemyPrefabs, randomSpawnPoint.position, Quaternion.identity);
    }

}
