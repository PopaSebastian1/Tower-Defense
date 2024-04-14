using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class MoneyTurret : MonoBehaviour, ITurretStats
    {
        [SerializeField] public string name = "Money Turret";
        [SerializeField] public float damage = 0f;
        [SerializeField] public float range = 0f;
        [SerializeField] public float fireRate = 0f;
        [SerializeField] public float moneyPerSecond = 50f;
        [SerializeField] public int cost = 200;
        [SerializeField] public GameObject prefab;
        public MoneyTurret(float _dmg, float _range, float _fireRate, float _moneyPerSecond, int _cost)
        {
            damage = _dmg;
            range = _range;
            fireRate = _fireRate;
            moneyPerSecond = _moneyPerSecond;
            cost = _cost;
        }
        public void UpgradeTurret()
        {
            moneyPerSecond += 5f;
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
        public GameObject GetPrefab()
        {
            return prefab;
        }
        public void SetPrefab(GameObject _prefab)
        {
            prefab = _prefab;
        }
    }
}

