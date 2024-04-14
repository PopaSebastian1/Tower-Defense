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
    private int health;
    [SerializeField] private int money = 200;
    [Header("Events")]
    public static UnityEvent<int> onEnemyFinish= new UnityEvent<int>();
    public static UnityEvent<int> addMoney = new UnityEvent<int>();
    [Header("References")]
    [SerializeField]
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
        lifeCanvas.GetComponent<TextMeshProUGUI>().text = health.ToString();

    }
    private void EnemyDies(int moneyDrop)
    {
        money += moneyDrop;
        moneyCanvas.GetComponent<TextMeshProUGUI>().text = money.ToString();

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
        moneyCanvas.GetComponent<TextMeshProUGUI>().text = money.ToString();
    }

    void Start()
    {
        
        if(GameType.instance.GetHardMode() == true)
        {
            health = 1;
        }
        else
        {
            health = 100;
        }
        lifeCanvas.GetComponent<TextMeshProUGUI>().text = health.ToString();
        moneyCanvas.GetComponent<TextMeshProUGUI>().text =  money.ToString();


    }
    void Update()
    {
        
    }
}
