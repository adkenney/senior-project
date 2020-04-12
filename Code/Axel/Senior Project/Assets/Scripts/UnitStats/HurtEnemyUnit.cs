using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyUnit : TurnManager
{

    static int currentDamage;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

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
            enemy.GetComponent<HealthManager>().HurtUnit(currentDamage);
            Debug.Log("Hit " + enemy.name + " for " + currentDamage + " damage!");
        }
        
    }

}
