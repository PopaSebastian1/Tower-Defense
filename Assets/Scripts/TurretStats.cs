using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicTurret : MonoBehaviour, ITurretStats
{
    [SerializeField] private float damage = 1f;
    [SerializeField] private float range = 7f;
    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float moneyPerSecond = 0f;
    [SerializeField] private int cost = 100;
    public void UpgradeTurret()
    {
        damage += 1f;
        range += 1f;
        fireRate += 1f;
        cost += 50;
    }
    public float GetDamage()
    {
        return damage;
    }
    public float GetRange()
    {
        return range;
    }
    public float GetFireRate()
    {
        return fireRate;
    }
    public float GetMoneyPerSecond()
    {
        return moneyPerSecond;
    }
    public int GetCost()
    {
        return cost;
    }
}