using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Turret : MonoBehaviour
{
    [Header("Attribute")]
    private float damage;
    private float targetingRange;
    private float bps;
    private float moneyPerSecond;
    private int cost;

    [Header("References")]
    [SerializeField] private string enemyTag = "Enemy";
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firingPoint;
    [SerializeField] private GameObject lookAtObj;

    private ITurretStats basicTurret;
    private Transform target;
    private float timeUntilFire;
    public float GetDamage()
    {
        return damage;
    }
    //private void OnDrawGizmosSelected()
    //{
    //    Handles.color = Color.red;
    //    Handles.DrawWireDisc(transform.position, transform.up, targetingRange);
    //}

    // Start is called before the first frame update
    void Start()
    {
        basicTurret = GetComponent<ITurretStats>();
        damage = basicTurret.GetDamage();
        targetingRange = basicTurret.GetRange();
        bps = basicTurret.GetFireRate();
        cost = basicTurret.GetCost();
        moneyPerSecond = basicTurret.GetMoneyPerSecond();


    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            FindTarget();
            return;
        }

        if (!CheckTargetIsInRange())
        {
            target = null;
        }
        else
        {
            
            Vector3 dir = target.transform.position - lookAtObj.transform.position;
            dir.y = 0;
            Quaternion rot = Quaternion.LookRotation(dir);
            lookAtObj.transform.rotation = Quaternion.Slerp(lookAtObj.transform.rotation, rot, 5 * Time.deltaTime);

            timeUntilFire += Time.deltaTime;

            if (timeUntilFire >= 1f / bps)
            {
                Shoot();
                timeUntilFire = 0f;
            }
        }
    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Bullet bulletScript = bulletObj.GetComponent<Bullet>();
        bulletScript.SetTarget(target);
        bulletScript.SetTurret(this);
    }

    private void FindTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null && closestDistance <= targetingRange)
        {
            target = closestEnemy.transform;
            Debug.Log("Target found at: " + target.position);
        }
        else
        {
            target = null;
            Debug.Log("No target found.");
        }
    }

    private bool CheckTargetIsInRange()
    {
        return Vector3.Distance(target.position, transform.position) <= targetingRange;
    }
    public void UpgradeTurret()
    {
        // Verificăm dacă avem o referință validă la obiectul care implementează ITurretStats
        if (basicTurret != null)
        {
            // Apelăm metoda UpgradeTurret() din obiectul care implementează ITurretStats
            basicTurret.UpgradeTurret();
            // Actualizăm valorile din Turret cu noile valori calculate
            damage = basicTurret.GetDamage();
            targetingRange = basicTurret.GetRange();
            bps = basicTurret.GetFireRate();
            cost = basicTurret.GetCost();
            moneyPerSecond = basicTurret.GetMoneyPerSecond();
        }
        else
        {
            Debug.LogError("No ITurretStats component found on turret!");
        }
    }

}
