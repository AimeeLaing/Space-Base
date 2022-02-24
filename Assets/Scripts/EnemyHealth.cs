using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{   //works the same as player health, but collision on bullet only lose 1 value to health
    // Start is called before the first frame update
    
    public int enemyHealth;
    public bool dead;

    public Slider slider;

    

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            enemyHealth -= 1;
            other.gameObject.SetActive(false);
            SetHealth(enemyHealth);
            if (enemyHealth <= 0)
            {
                dead = true;
                gameObject.SetActive(false);
            }

            
        }
    }
    void Start()
    {
        enemyHealth = 10;
        dead = false;
    }

   
}
