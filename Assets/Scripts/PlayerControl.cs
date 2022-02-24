using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    Rigidbody playerRB;
   //assing values for the player speed
    public float forwardVelocity = 30f;
    public float xVelocity = 30f;
    public float jumpVelocity = 800f;
    float horizontal;
    float vertical;
    //get the gun object, this is so we can use its location and attached script
    public GameObject gun;
    Bullet shoot;

    bool onGround;
    // Start is called before the first frame update

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        shoot = gun.GetComponent<Bullet>();
        onGround = true;
    }

    //checks player is on ground before jumping
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
           
            onGround = true;
 
        }
    }

    //detects player is not touch floor
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {

            onGround = false;
          
        }
    }
    private void Update()
    {

        //jump code
        if (Input.GetButtonDown("Jump"))
        {
            if (onGround == true)
            {
                playerRB.AddForce(transform.up * jumpVelocity, ForceMode.Impulse); 
             }
        }
        //shoot bullet, uses code from bullet component on gun
        if (Input.GetKeyDown(KeyCode.Mouse0) && gun.activeInHierarchy == true)
        {
            
            shoot.shooting(gun.transform.right);
        }

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal") * xVelocity;
        vertical = Input.GetAxis("Vertical") * forwardVelocity;
        //add force to the player rigid body using acceleration force mode
        playerRB.AddForce(transform.forward * vertical + transform.right * horizontal, ForceMode.Acceleration);
        //player was falling really slow, add his to speed it up
        if (onGround == false)
        {

            playerRB.AddForce(transform.up * -20, ForceMode.Impulse);

        }
    }
   



}