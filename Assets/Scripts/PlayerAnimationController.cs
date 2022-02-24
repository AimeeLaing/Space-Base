using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    //runs through animations for idle and running on player
    Animator animator;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("isIdle", true);
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        vertical = Input.GetAxis("Vertical");
        if (vertical == 1 || vertical == -1)
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isIdle", false);
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isIdle", true);
        }
       



    }
}
