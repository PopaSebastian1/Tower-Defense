using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class WaveManager : MonoBehaviour
        
{
    [Header("References")]
    [SerializeField] private List<GameObject> enemyPrefab;
    [SerializeField] private GameObject soundManager;
    [Header("Attributes")]
    [SerializeField] public int baseEnemies = 8;
    [SerializeField] public float enemiesPerSecond = 1f;
    [SerializeField] public float timeBetweenWaves = 5;
    [SerializeField] public float enemyMultiplier = 0.75f;
    [SerializeField] public float enemiesPerSecondCap = 15f;
    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeft;
    private float eps;
    private bool isSpawning = false;
    public static UnityEvent onEnemyDestroy;
    [SerializeField] private GameObject waveText;
    public void Awake()
    {
        onEnemyDestroy = new UnityEvent();
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }


    private void Start()
    {
        StartCoroutine(StartWave());
        waveText.GetComponent<TextMeshProUGUI>().text = "Wave " + currentWave.ToString();

    }
    private void Update()
    {
        if (!isSpawning)
            return;
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= (1 / eps) && enemiesLeft>0)
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
        GameObject[] moneyTurrets= GameObject.FindGameObjectsWithTag("MoneyTurret");
        int moneyToAdd = 0;
        moneyToAdd += moneyTurrets.Length * 50;
        PlayerScript.addMoney.Invoke(moneyToAdd+100);
        waveText.GetComponent<TextMeshProUGUI>().text = "Wave " + currentWave.ToString();
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
        soundManager.GetComponent<SoundManager>().PlayStartSound();
        if (currentWave % 3 == 0 && currentWave != 0)
        {
            enemyPrefab.Add(enemyPrefab[0]);
        }
            
        isSpawning = true;
        enemiesLeft = CalculateEnemies();
        eps =CalculateEnemiesPerSecond();

    }
    private int CalculateEnemies()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, enemyMultiplier));
    } 
    private float CalculateEnemiesPerSecond()
    {
        return Mathf.Clamp((enemiesPerSecond * Mathf.Pow(currentWave, enemyMultiplier)), 0f, enemiesPerSecondCap);
    }
    private void SpawnEnemy()
    {

        Vector3 spawnPoint = GameObject.FindWithTag("Start Point").transform.position;
        //get the vector 3 from spawnPoint
        int index=UnityEngine.Random.Range(0, enemyPrefab.Count);
        GameObject prefabToSpawn = enemyPrefab[index];
        Instantiate(prefabToSpawn, spawnPoint, Quaternion.identity);
    }
    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }
}
