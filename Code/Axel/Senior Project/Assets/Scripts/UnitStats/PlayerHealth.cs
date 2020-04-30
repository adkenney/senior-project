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
            Debug.Log(gameObject);
            gameObject.GetComponent<TacticsMove>().dead = true;
            gameObject.SetActive(false);

        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // damage pop up
        if(damageTextPrefab) 
        {
            StartCoroutine(MainCoroutine(damage));
        }
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log(gameObject);
            gameObject.GetComponent<TacticsMove>().dead = true;
            gameObject.SetActive(false);

        }
    }

    IEnumerator MainCoroutine(int damage)
    {
        GameObject gameObj = (GameObject)Instantiate(damageTextPrefab, transform.position, Quaternion.identity, transform);
        gameObj.GetComponent<TextMeshPro>().text = "-" + damage.ToString();
        //yield on a new YieldInstruction that waits for .5 seconds.
        yield return new WaitForSecondsRealtime(1f);
        

    }

}
