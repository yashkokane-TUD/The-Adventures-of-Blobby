using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropItems : MonoBehaviour
{
    public  GameObject item1;
    // public GameObject item2;

    //public static GameObject enemy;
    //public Transform Epos;
    //public GameObject enemy_bot;
    
    // Start is called before the first frame update
    void Start()
    {
        //Epos = GetComponent<Transform>();
    }

    private void Update()
    {
        //item1.transform.position = Epos.position;
    }

    public  void dropItemOnDeath()
    {
        Debug.Log("drop");
        item1.SetActive(true);
    }
}
