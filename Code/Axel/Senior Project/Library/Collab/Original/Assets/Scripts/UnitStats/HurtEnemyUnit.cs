using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyUnit : TurnManager
{
    static int currentDamage;
    static UnitStats currentPlayerUnit;
    static EnemyUnitStats enemy;
    static bool attackingTurn;
    private TurnManager currentUnit;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerUnit = FindObjectOfType<UnitStats>();
        enemy = FindObjectOfType<EnemyUnitStats>();
        currentUnit = FindObjectOfType<TurnManager>();
        Debug.Log(currentUnit);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void Attack()
    {
        if (Input.GetMouseButtonUp(0))
        {

            Vector2 ray2dOrigin;
            Vector2 ray2dDirection;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ray2dOrigin = ray.origin;
            ray2dDirection = ray.direction;
            RaycastHit2D hit = Physics2D.Raycast(ray2dOrigin, ray2dDirection);

            if (hit.collider)
            {
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    enemy = hit.collider.gameObject.GetComponent<EnemyUnitStats>();
                    if (currentPlayerUnit.unitAttack <= enemy.unitDefense)
                    {
                        currentDamage = 1;
                    }
                    else
                    {
                        currentDamage = currentPlayerUnit.unitAttack - enemy.unitDefense;
                    }
                    hit.collider.gameObject.GetComponent<HealthManager>().HurtUnit(currentDamage);
                    Debug.Log("Hit " + hit.collider.gameObject.name + " for " + currentDamage + " damage!");
                }
            }
          
        }

    }

}
