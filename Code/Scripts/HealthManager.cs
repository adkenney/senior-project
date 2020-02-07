using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int unitMaxHealth;
    public int unitCurrentHealth;

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
        }
    }

    public void HurtUnit(int damage)
    {
        unitCurrentHealth -= damage;
    }

    public void SetMaxHealth()
    {
        unitCurrentHealth = unitMaxHealth;
    }
}
