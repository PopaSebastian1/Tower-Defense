using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Atributes")]
    [SerializeField] private int health = 100;
    [SerializeField] private int money = 200;
    [Header("Events")]
    public static UnityEvent<int> onEnemyFinish= new UnityEvent<int>();
    public static UnityEvent<int> addMoney = new UnityEvent<int>();
    [Header("References")]
    private GameObject lifeCanvas, moneyCanvas, waveCanvas;
    private void Awake()
    {
        //add a listener to the event for a fucntion EnemyFinish that takes an int as a parameter
        onEnemyFinish.AddListener(EnemyFinish);
        addMoney.AddListener(EnemyDies);
    }

    private void EnemyFinish(int hp)
    {
        health -=hp;
        lifeCanvas.GetComponent<TextMeshProUGUI>().text ="HP "+ health.ToString();

    }
    private void EnemyDies(int moneyDrop)
    {
        money += moneyDrop;
        moneyCanvas.GetComponent<TextMeshProUGUI>().text ="Money "+ money.ToString();

    }
    public int GetHealth()
    {
        return health;
    }
    public int GetMoney()
    {
        return money;
    }
    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }
    public void SetMoney(int newMoney)
    {
        money = newMoney;
    }
    public void AddMoney(int moneyToAdd)
    {
        money += moneyToAdd;
    }
    public void RemoveMoney(int moneyToRemove)
    {
        money -= moneyToRemove;
        moneyCanvas.GetComponent<TextMeshProUGUI>().text = "Money " + money.ToString();
    }

    void Start()
    {
        lifeCanvas = GameObject.FindWithTag("LifeCanvas");
        moneyCanvas= GameObject.FindWithTag("Money Canvas");
        lifeCanvas.GetComponent<TextMeshProUGUI>().text = "HP "+health.ToString();
        moneyCanvas.GetComponent<TextMeshProUGUI>().text = "Money " + money.ToString();    

    }
    void Update()
    {
        
    }
}
