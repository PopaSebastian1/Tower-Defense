using System;
using System.Collections;
using System.Collections.Generic;
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
    private void Awake()
    {
        //add a listener to the event for a fucntion EnemyFinish that takes an int as a parameter
        onEnemyFinish.AddListener(EnemyFinish);
    }

    private void EnemyFinish(int hp)
    {
        health = -5;
    }
    public void EnemyDies(int moneyDrop)
    {
        money += moneyDrop;
    }

    void Start()
    {
        
    }
    void Update()
    {
        
    }
}
