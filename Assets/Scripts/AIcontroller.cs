using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIcontroller : MonoBehaviour
{
 
    public GameObject goal;
    NavMeshAgent agent;
    Animator animator;
    float playerDistance;
    public GameObject gun;
    Bullet shoot;
    float shootTime = 1f;
    public GameObject gamePoints;
    Transform[] points;
    private int destPoint = 0;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        shoot = gun.GetComponent<Bullet>();
        animator.SetBool("isIdle", true);
        //stops the agent from stopping
        agent.autoBraking = false;
        //gets the transform of compents that are children of the object
        points = gamePoints.GetComponentsInChildren<Transform>();
        GotoNextPoint();
    }

    //This code was taken from https://docs.unity3d.com/Manual/nav-AgentPatrol.html
    void GotoNextPoint()
    {
        //checks that there is points to go to
        if (points.Length == 0)
          
            return;

        //sets the destination point the desired location
        agent.destination = points[destPoint].position;
        //selects a new point to go to
        destPoint = (destPoint + 1) % points.Length;
    }

    // Update is called once per frame
    void Update()
    {
        //calculates the distance from the player
        playerDistance = Vector3.Distance(agent.transform.position, goal.transform.position);

        //if the distance is less than 15 execute case 1, false execute case 2
        switch (playerDistance <= 15)
        {
            case true:
                agent.destination = goal.transform.position;
              
              
                //stops the enemy from shooting constantly
                if (shootTime > 0){
                    shootTime -= Time.deltaTime;
                }
                else
                {
                    shoot.shooting(gun.transform.forward);
                    shootTime = 1f;
                }
                break;
            case false:
         
            
                //if the agent is not searching for a path and the distance between the destination is less than 0.5
                if (!agent.pathPending && agent.remainingDistance < 0.5f)
                    GotoNextPoint();
                break;
        }
    
    
    }
}
