using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeaths : MonoBehaviour
{
    // this script tracks which enemys are dead and which ones are alive
    public List<GameObject> allEnemys;
    EnemyHealth enemyHealth;
    public int stillAlive;
    public bool allDead;
    public int totalEnemys;
    // Update is called once per frame
    
    private void Start()
    {
        totalEnemys = new int();
        allEnemys = new List<GameObject>();
        //store objects with enemy tags in a list
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            allEnemys.Add(enemy);
            totalEnemys += 1;
        }

        
        allDead = false;
        stillAlive = allEnemys.Count;
    }
    void Update()
    {
        for (int i = 0; i < allEnemys.Count; i++)
        {
            //get enemy health component to get dead or alive boolean
            enemyHealth = allEnemys[i].GetComponent<EnemyHealth>();
            if (enemyHealth.dead)
            {
                stillAlive -= 1;
                allEnemys.Remove(allEnemys[i]);
        
            }
        }

        if (stillAlive <= 0)
        {
            allDead = true;
         
        }
    }
}
