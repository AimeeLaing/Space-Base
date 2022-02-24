using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGun : MonoBehaviour
{   //this destroys the gun after the player has killed all the enemys cause it is no longer needed
    // Start is called before the first frame update
    public GameObject Enemys;
    public EnemyDeaths EnemyDeaths;
  
    void Start()
    {
        Enemys = GameObject.Find("Enemys");
        EnemyDeaths = Enemys.GetComponent<EnemyDeaths>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyDeaths.allDead)
        {
            gameObject.SetActive(false);
            Debug.Log(gameObject.activeSelf);
        }
    }
}
