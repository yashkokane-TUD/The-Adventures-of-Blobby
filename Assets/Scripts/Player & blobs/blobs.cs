using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobs : MonoBehaviour
{
    private HealthManager _healthManager;
    // Start is called before the first frame update
    void Start()
    {
        _healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            _healthManager.updateHealth();
            Destroy(gameObject);
            /*Destroy(gameObject);*/
        }
    }

    
}
