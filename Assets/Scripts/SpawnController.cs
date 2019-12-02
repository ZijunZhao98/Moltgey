using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public class SpawnController : MonoBehaviour
{
    public Transform[] spawnPoints;

    public GameObject enemyPrefabs;
    // Start is called before the first frame update

    public float timeElapsed = 0.0f;

    // configuration
    public float spawnDelay;
    public int enemyCounter;
    public int spawnCounter;
    public int killCounter;

    void Start()
    {
        StartCoroutine("enemySpawnTimer");
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(killCounter >= enemyCounter)
        {
            Win();
        }
        
    }

    IEnumerator enemySpawnTimer()
    {
        yield return new WaitForSeconds(spawnDelay);
        //spawn
        spawnEnemy();
        spawnCounter--;

        //repeat
        if(spawnCounter > 0)
        {
            StartCoroutine("enemySpawnTimer");
        }
        
    }

    void spawnEnemy()
    {

        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(enemyPrefabs, randomSpawnPoint.position, Quaternion.identity);
    }

    public void killIncrement()
    {
        killCounter++;
    }

    public void Win()
    {
        SceneManager.LoadScene("First_floor");
    }
}
