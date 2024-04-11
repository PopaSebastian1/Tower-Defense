using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    public Transform[] waypoints; // Array cu punctele de pe traseu
    [SerializeField] Animator anim;
    private float speed = 10f; // Viteza de deplasare a obiectului

    private int currentWaypointIndex = 0;
    private void Start()
    {
        //lock the object so it doesn't fall
    }
    void Update()
    {
        // Dacă mai sunt puncte pe traseu
        if (currentWaypointIndex < waypoints.Length)
        {
            //rotate the object to face the next waypoint
            transform.LookAt(waypoints[currentWaypointIndex].position);
            // Calculăm direcția spre punctul următor
            Vector3 direction = waypoints[currentWaypointIndex].position - transform.position;
            direction.Normalize();

            // Deplasăm obiectul către punctul următor
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            // Dacă obiectul a ajuns aproape de punctul curent, trecem la următorul punct
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                currentWaypointIndex++;
            }
            if (currentWaypointIndex == waypoints.Length - 1)
            {
               
            }

        }
        else
        {
            //WaveManager.onEnemyDestroy.Invoke();
            var enemy= GetComponent<IEnemy>();
            enemy.ReachedEnd();
            //GetComponent<IEnemy>().ReachedEnd();
            GetComponent<Animator>().SetTrigger("End");

            //StartCoroutine(Wait());
            if (GetComponent<Animator>())
            {
                Destroy(gameObject);
            }
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
}
