using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinCondition : MonoBehaviour
{
    // variables that indicate what the player has achived and if they have collided with relevant game objects
    public bool isPurpleShip = false;
    public bool collectedData = false;
    public bool isControlDesk = false;
    public GameObject Enemys;
    public EnemyDeaths EnemyDeaths;


    private void Start()
    {
        //find the enemys gameobject - this is a parent of all the individual enemys
        Enemys = GameObject.Find("Enemys");
        //script that tracks enemy deaths
        EnemyDeaths = Enemys.GetComponent<EnemyDeaths>();
    }
    private void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.tag == "PurpleShip")
        {
            isPurpleShip = true;
            
        }
        if (collision.gameObject.tag == "ControlDesk")
        {
            isControlDesk = true;
            Debug.Log(isControlDesk);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "PurpleShip")
        {
            isPurpleShip = false;
        }
        if (collision.gameObject.tag == "ControlDesk")
            isControlDesk = false;
    }

    void Update()
    {
        //if all the enemys are dead player can collect the data 
        if (EnemyDeaths.allDead == true && isControlDesk == true && Input.GetKeyDown("e"))
        {
            
            collectedData = true;
        }
        //if data collected player can escape on ship
        if (isPurpleShip == true && Input.GetKeyDown("e") && collectedData == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }
  

  
}
