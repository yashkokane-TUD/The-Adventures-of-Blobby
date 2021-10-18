using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    private levelManager LevelManager;
    
    public int playerHPatCheck;
    // Start is called before the first frame update
    void Start()
    {
        LevelManager = FindObjectOfType<levelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            LevelManager.CurrentCheckpoint = gameObject;
            playerHPatCheck = HealthManager.PlayerHP;
            Debug.Log(playerHPatCheck);
        }
        
    }
}
