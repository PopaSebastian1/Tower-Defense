using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] public float health = 1;
    [SerializeField] public float speed = 5;
    [SerializeField] public int moneyDrop = 10;
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
        PlayerScript.onEnemyDies.Invoke(moneyDrop);
    }
    public void ReachedEnd()
    {
        PlayerScript.onEnemyFinish.Invoke((int)health);
        WaveManager.onEnemyDestroy.Invoke();
        Destroy(gameObject);
    }
}

