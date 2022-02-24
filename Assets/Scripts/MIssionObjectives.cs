using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MIssionObjectives : MonoBehaviour
{
    // Start is called before the first frame update
    public float targetTime = 1.0f;
    //store the text meshes that are in the canvas
    public TextMeshProUGUI firstMessage;
    public TextMeshProUGUI firstMission;
    public TextMeshProUGUI secondMission;
    public TextMeshProUGUI thirdMission;
    public TextMeshProUGUI PressE;
    //get components from other game objects
    public GameObject player;
    public GameObject enemys;
    EnemyDeaths enemyDeaths;
    WinCondition winCondition;
    
    void Start()
    {
        //initlise the components from the other gameobjects
        winCondition = player.GetComponent<WinCondition>();
        enemyDeaths = enemys.GetComponent<EnemyDeaths>();

        PressE.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //These if statements chnage the active state of the text meshes based on which stage the player is in the game.
        targetTime -= Time.deltaTime;
        if (targetTime <= 0.0f && winCondition.EnemyDeaths.allDead == false)
        {
            firstMessage.enabled = false;
            firstMission.enabled = true;
            
           
        }
        firstMission.SetText("Eliminate all hostiles {0} / {1}", enemyDeaths.stillAlive, enemyDeaths.totalEnemys);
        if (enemyDeaths.allDead == true)
        {

            firstMission.enabled = false;
            secondMission.enabled = true;
        }
        if (enemyDeaths.allDead == true && winCondition.collectedData == true)
        {

            secondMission.enabled = false;
            thirdMission.enabled = true;
        }
        if (winCondition.isPurpleShip == true && winCondition.collectedData == true)
        {
            PressE.enabled = true;
        }
        else if (winCondition.isControlDesk == true && winCondition.EnemyDeaths.allDead == true)
        {
            PressE.enabled = true;
        }
        else
        {
            PressE.enabled = false;
        }
    }
}
