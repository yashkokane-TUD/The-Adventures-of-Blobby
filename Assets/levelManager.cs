using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    private PlayerMovement pM;
    private HealthManager _healthManager;
    
    public GameObject CurrentCheckpoint;
    //[SerializeField] private  GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        pM = FindObjectOfType<PlayerMovement>();
        _healthManager = FindObjectOfType<HealthManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RespawnPlayer()
    {
        _healthManager.isDead = false;
        pM.transform.position = CurrentCheckpoint.transform.position;
        _healthManager.ResetHealth();
        //_healthManager.PlayerHP += 20;

    }
}
