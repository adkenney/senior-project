using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyUnit : TurnManager
{
    static int currentDamage;
  
    public static void Attack(RaycastHit2D other)
    {
        if(currentUnit.tag == "Player")
        {
            UnitStats player = currentUnit.GetComponent<UnitStats>();
            EnemyUnitStats enemy = other.collider.GetComponent<EnemyUnitStats>();

            if (player.unitAttack <= enemy.unitDefense)
            {
                currentDamage = 1;
            }
            else
            {
                currentDamage = player.unitAttack - enemy.unitDefense;
            }
            enemy.GetComponent<PlayerHealth>().TakeDamage(currentDamage);
        }
        
    }

    public void Attack2(RaycastHit2D other)
    {

    }

}
