using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    

    private Transform target;
    private Turret turret;
    public void SetTarget(Transform _target){
        target = _target;
    }
    public void SetTurret(Turret _turret)
    {
        turret = _turret;
    }
    private void FixedUpdate()
    {
        if (!target)
            return;

        // Calculate direction to target
        Vector3 direction = (target.position - transform.position).normalized;

        // Rotate bullet to look in the direction of the target
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(Quaternion.Lerp(transform.rotation, lookRotation, Time.fixedDeltaTime * bulletSpeed));

        transform.rotation = Quaternion.LookRotation(direction);
        
        // Move towards the target
        transform.Translate(direction * bulletSpeed * Time.deltaTime, Space.World);

        Debug.DrawRay(transform.position, direction * 5f, Color.red); // Draw a debug ray to visualize the direction
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificăm dacă obiectul cu care s-a ciocnit este un inamic
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Obținem componenta IEnemy și apelăm metoda TakeDamage
            // bullet este un obiect de tip bullet care este copil al obiectului turret cum apelez metoda GetDamage() din Turret
            
            var enemy = other.gameObject.GetComponent<IEnemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(turret.GetDamage());
                var dmg= turret.GetDamage();
            }

            // Distrugem glontul după ce a lovit un inamic
            Destroy(gameObject);
        }
    }
}
