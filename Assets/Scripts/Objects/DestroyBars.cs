using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBars : MonoBehaviour
{
    [SerializeField] private GameObject BrokenDoor;
    [SerializeField] private GameObject Door;
    public static bool DoorOff;

    private void Start()
    {
   
    }
    public void destroyPrison()
    {
        Door.SetActive(false);
        BrokenDoor.SetActive(true);
        DoorOff = true;

    }
}