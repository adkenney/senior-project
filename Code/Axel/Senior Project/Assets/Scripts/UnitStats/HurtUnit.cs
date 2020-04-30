using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtUnit : MonoBehaviour
{
    //public int attackDamageToGive;
    private int currentDamage;
    private UnitStats unitStat;
    private EnemyUnitStats enemyUnitStat;

    // Start is called before the first frame update
    void Start()
    {
        unitStat = FindObjectOfType<UnitStats>();
        enemyUnitStat = FindObjectOfType<EnemyUnitStats>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void onTriggerEnter(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (enemyUnitStat.unitAttack <= unitStat.unitDefense)
            {
                currentDamage = 1;
            }
            else
            {
                currentDamage = enemyUnitStat.unitAttack - unitStat.unitDefense;
            }
            other.gameObject.GetComponent<HealthManager>().HurtUnit(currentDamage);
        }
    }
    /* hurt opposing unit when attacked */
    /*void OnCollisionEnter2D(Collision2D other)
    {
        // can use gameObject.name or gameObject.tag
        if (other.gameObject.tag == "Player")
        {
            if (enemyUnitStat.unitAttack <= unitStat.unitDefense)
            {
                currentDamage = 1;
            }
            else
            {
                currentDamage = enemyUnitStat.unitAttack - unitStat.unitDefense;
            }
            other.gameObject.GetComponent<HealthManager>().HurtUnit(currentDamage);
        }
    }*/

    public void Attack(Tiles tile)
    {
        LayerMask mask = LayerMask.GetMask("character");
        RaycastHit hit;
        if(Physics.Raycast(tile.transform.position, Vector3.up, out hit, 1,mask))
        {
            /*if (hit.collider.tag == "Player")
            {
                UnitStats player = hit.collider.GetComponent<UnitStats>();
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
                Debug.Log("Hit " + enemy.name + " for " + currentDamage + " damage!");
            }*/

            Debug.Log(hit.collider.tag);
        }
        
    }
}
