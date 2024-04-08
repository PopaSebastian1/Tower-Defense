using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class WaveManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefab;
    [Header("Attributes")]
    [SerializeField] public int baseEnemies = 8;
    [SerializeField] public float enemiesPerSecond = 0.5f;
    [SerializeField] public float timeBetweenWaves = 5;
    [SerializeField] public float enemyMultiplier = 0.75f;
    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeft;
    private bool isSpawning = false;
    public static UnityEvent onEnemyDestroy;
    public void Awake()
    {
        onEnemyDestroy = new UnityEvent();
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }


    private void Start()
    {
        StartCoroutine(StartWave());
    }
    private void Update()
    {
        if (!isSpawning)
            return;
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= (1 / enemiesPerSecond) && enemiesLeft>0)
        {
            SpawnEnemy();
            enemiesLeft--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }
        if(enemiesLeft==0&&enemiesAlive==0)
        {
            EndWave();
        }

    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }

    private IEnumerator StartWave()
    {
        if (currentWave > 1)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
        }
        else
        {
            yield return new WaitForSeconds(0);
        }
        enemiesLeft = CalculateEnemies();
        isSpawning = true;

    }
    private int CalculateEnemies()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, enemyMultiplier));
    }
    private void SpawnEnemy()
    {
        Vector3 spawnPoint = GameObject.FindWithTag("Start Point").transform.position;
        //get the vector 3 from spawnPoint

            GameObject prefabToSpawn = enemyPrefab[0];
        Instantiate(prefabToSpawn, spawnPoint, Quaternion.identity);
    }
    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }
}
