using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtUnit : MonoBehaviour
{
    public int attackDamageToGive;
    private int currentDamage;

    private UnitStats unitStat;

    // Start is called before the first frame update
    void Start()
    {
        unitStat = FindObjectOfType<UnitStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /* hurt opposing unit when attacked */
    void OnCollisionEnter2D(Collision2D other)
    {
        //replace "" with a player game object name
        if (other.gameObject.name == "") {
            currentDamage = attackDamageToGive - unitStat.unitDefense;
            other.gameObject.GetComponent<HealthManager>().HurtUnit(currentDamage);
        } 
    }
}
