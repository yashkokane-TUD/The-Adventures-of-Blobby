using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    //private levelManager LevelManager;
    private gameManager gM;
    
    public int playerHPatCheck;
    // Start is called before the first frame update
    void Start()
    {
        gM = FindObjectOfType<gameManager>();
        //LevelManager = FindObjectOfType<levelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gM.CurrentCheckpoint = gameObject;
            playerHPatCheck = HealthManager.PlayerHP;
            Debug.Log(playerHPatCheck);
            /*SaveManager.instance.activeSave.resPos = transform.position;
            SaveManager.instance.Save();*/
        }
        
    }
}
