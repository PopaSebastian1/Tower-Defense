using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SecondEnemy : MonoBehaviour, IEnemy
{
    public float health = 1;
    public float speed = 5;
    public int moneyDrop = 20;
    public static UnityEvent<float> bulletHit = new UnityEvent<float>();
    public void Start()
    {
        bulletHit.AddListener(TakeDamage);
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
        PlayerScript.addMoney.Invoke(moneyDrop);
        WaveManager.onEnemyDestroy.Invoke();
    }
    public void ReachedEnd()
    {
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlayEnemyFinish();
        PlayerScript.onEnemyFinish.Invoke((int)health);
        WaveManager.onEnemyDestroy.Invoke();
        Destroy(gameObject);
    }
}

