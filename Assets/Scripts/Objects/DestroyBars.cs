using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBars : MonoBehaviour
{
    public SpriteRenderer DestBars;

    public Sprite broken;

    private void Start()
    {
        DestBars = GetComponentInChildren<SpriteRenderer>();
    }
    public void destroyPrison()
    {

        DestBars.sprite = broken;
   
       //GameObject destructable = (GameObject) Instantiate(DestBars);
       //destructable.transform.position = Bars.transform.position;
     
   }
}