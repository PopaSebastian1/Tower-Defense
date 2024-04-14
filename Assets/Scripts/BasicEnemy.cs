using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BasicEnemy : MonoBehaviour, IEnemy
{
    [SerializeField] public float health = 1;
    [SerializeField] public float speed = 5;
    [SerializeField] public int moneyDrop = 10;
    public static UnityEvent<float> bulletHit = new UnityEvent<float>();
    public ParticleSystem deathParticles;
    public float particleDuration = 2f; // Duration for how long the particle system will play
    public float particleSpeedMultiplier = 1f; // Multiplier for the particle system's start speed


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
        PlayDeathParticles(); // Play particle effect when enemy dies
    }

    private void PlayDeathParticles()
    {
        if (deathParticles != null)
        {
            ParticleSystem particleSystemInstance = Instantiate(deathParticles, transform.position, Quaternion.identity);
            
            // Access the main module of the particle system and adjust the start speed
            ParticleSystem.MainModule mainModule = particleSystemInstance.main;
            mainModule.startSpeedMultiplier *= particleSpeedMultiplier;
            
            Destroy(particleSystemInstance.gameObject, particleDuration); // Destroy the particle system after a certain duration
        }
    }
}

