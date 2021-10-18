using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropItems : MonoBehaviour
{
    public  GameObject item1;
   // public GameObject item2;

    //public static GameObject enemy;
    private Transform Epos;
    //public GameObject enemy_bot;
    
    // Start is called before the first frame update
    void Start()
    {
        Epos = GetComponent<Transform>();
        //item1.transform.position = enemy.transform.position;
        //item2.transform.position = enemy_bot.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void dropItemOnDeath()
    {
            Instantiate(item1, Epos.position, Quaternion.identity);
    }
}
