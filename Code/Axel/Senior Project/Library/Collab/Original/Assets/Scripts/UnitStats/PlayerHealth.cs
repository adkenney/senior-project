using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject damageTextPrefab;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
            gameObject.GetComponent<TacticsMove>().dead = true;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // damage pop up
        if(damageTextPrefab) 
        {
            GameObject gameObj = (GameObject) Instantiate(damageTextPrefab, transform.position, Quaternion.identity, transform);
            gameObj.GetComponent<TextMeshPro>().text = "-" + damage.ToString();
        }
        healthBar.SetHealth(currentHealth);
    }

}
