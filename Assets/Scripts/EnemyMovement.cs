using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    public Transform[] waypoints; // Array cu punctele de pe traseu
    private float speed = 5f; // Viteza de deplasare a obiectului

    private int currentWaypointIndex = 0;

    void Update()
    {
        // Dacă mai sunt puncte pe traseu
        if (currentWaypointIndex < waypoints.Length)
        {
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
        }
        else
        {
            // Dacă obiectul a ajuns la ultimul punct, îl distrugem sau îi oprim mișcarea, în funcție de necesități
            // Exemplu: Destroy(gameObject);
        }
    }
}
