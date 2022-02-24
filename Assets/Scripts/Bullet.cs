using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
 
    public GameObject bullet;
   
    // Start is called before the first frame update
    void Start()
    {
       
     
    }
  

    // Update is called once per frame


    public void shooting(Vector3 direction)

    {
            //inilise a bullet object and add force to its rigidbody
            GameObject currentbullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            Rigidbody rb = currentbullet.GetComponent<Rigidbody>();
            rb.AddForce(direction * 800);
            //destroy the bullet after 2 seconds
            Destroy(currentbullet, 2f);
       

    }
          
}
