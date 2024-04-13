using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Tier2Turret : MonoBehaviour, ITurretStats
    {
        [SerializeField] public string name = "Basic Turret";
        [SerializeField] public float damage = 2f;
        [SerializeField] public float range = 10f;
        [SerializeField] public float fireRate = 2f;
        [SerializeField] public float moneyPerSecond = 0f;
        [SerializeField] public int cost = 300;
        [SerializeField] public GameObject prefab;
        public Tier2Turret(float _dmg, float _range, float _fireRate, float _moneyPerSecond, int _cost)
        {
            damage = _dmg;
            range = _range;
            fireRate = _fireRate;
            moneyPerSecond = _moneyPerSecond;
            cost = _cost;
        }
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
