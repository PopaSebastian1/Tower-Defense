using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;


public class Turret2 : MonoBehaviour
{
    [Header("Attribute")]
    private float damage;
    private float targetingRange;
    private float bps;
    private float moneyPerSecond;
    private int cost;

    [Header("References")]
    [SerializeField] private string enemyTag = "Enemy";
    [SerializeField] private Transform firingPoint;

    private ITurretStats basicTurret;
    public float GetDamage()
    {
        return damage;
    }
    // Start is called before the first frame update
    void Start()
    {
        basicTurret = GetComponent<ITurretStats>();
        damage = basicTurret.GetDamage();
        targetingRange = basicTurret.GetRange();
        bps = basicTurret.GetFireRate();
        cost = basicTurret.GetCost();
        moneyPerSecond = basicTurret.GetMoneyPerSecond();
        transform.Rotate(-90, 0, 90);


    }

    void Update()
    {
       
    }

    public void UpgradeTurret()
    {
        // Verificăm dacă avem o referință validă la obiectul care implementează ITurretStats
        
    }
}

