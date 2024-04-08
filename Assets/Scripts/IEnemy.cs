using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{
 
    public void TakeDamage(float damage)
    {
       
    }
    public void Die()
    {
        // Drop money
        // Play death animation
        // Destroy object
    }
    public void ReachedEnd()
    {
        // Remove health from player
        // Destroy object
    }
}
