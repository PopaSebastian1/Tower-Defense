using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurretStats
{

    public void UpgradeTurret()
    {
        // Increase damage
        // Increase range
        // Increase fire rate
    }
    float GetDamage();

    float GetRange();

    float GetFireRate();

    float GetMoneyPerSecond();

    int GetCost();

}
