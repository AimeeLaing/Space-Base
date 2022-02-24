using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHeath : MonoBehaviour
{
    // Start is called before the first frame update
    //slider object
    public Slider slider;

    int playerHealth;

    public void SetHealth(int health)
    {
        //set slider value to health
        slider.value = health;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //if player hits bullet then reduce health by 2
        if (collision.gameObject.tag == "Bullet")
        {
            playerHealth -= 1;
            //update slider value
            SetHealth(playerHealth);
        }
    }
    void Start()
    {
        playerHealth = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            //no health, load gameover scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
