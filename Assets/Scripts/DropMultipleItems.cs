using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMultipleItems : MonoBehaviour
{
    public  GameObject[] items;



    public  void dropItemOnDeath2()
    {
        Debug.Log("drop");
        for (int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(true);
        }
    }
}
