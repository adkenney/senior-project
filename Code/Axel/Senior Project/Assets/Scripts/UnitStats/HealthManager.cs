using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public int unitMaxHealth;
    public int unitCurrentHealth;
    public GameObject floatingDamage;

    // Start is called before the first frame update
    void Start()
    {
        unitCurrentHealth = unitMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(unitCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            gameObject.GetComponent<TacticsMove>().dead = true;
        }
    }

    public void HurtUnit(int damage)
    {
        unitCurrentHealth -= damage;
        Instantiate(floatingDamage, gameObject.transform.position, Quaternion.identity);      
    }

    public void SetMaxHealth()
    {
        unitCurrentHealth = unitMaxHealth;
    }
}
