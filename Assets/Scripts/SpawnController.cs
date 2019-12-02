using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;


public class SpawnController : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public GameObject win;

    //public GameObject enemyPrefabs;
    // Start is called before the first frame update

    public float timeElapsed = 0.0f;

    // configuration
    public float spawnDelay;
    public int enemyCounter;
    public int spawnCounter;
    public int killCounter;
    public bool isPaused = true;



    private void Start()
    {

         StartCoroutine("enemySpawnTimer");
    }

    // Update is called once per frame
    void Update()
    {
        
        timeElapsed += Time.deltaTime;


        if (killCounter >= enemyCounter)
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

        if (spawnCounter > 0)
        {
            StartCoroutine("enemySpawnTimer");
        }
        
    }

    void spawnEnemy()
    {

        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject enemy = enemyPrefabs[Random.Range(0, spawnPoints.Length)];

        Instantiate(enemy, randomSpawnPoint.position, Quaternion.identity);
    }

    public void killIncrement()
    {
        killCounter++;
    }

    public void Win()
    {
        win.SetActive(true);
    }
}
