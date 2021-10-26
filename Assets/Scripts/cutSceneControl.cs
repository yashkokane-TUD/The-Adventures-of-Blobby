using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class cutSceneControl : MonoBehaviour
{
    [SerializeField] private GameObject vCam1;

    [SerializeField] private GameObject vCam2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            vCam1.SetActive(false);
            vCam2.SetActive(true);
            MyMethod();
            vCam1.SetActive(true);
            vCam2.SetActive(false);
            gameObject.SetActive(false);
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        
    }
    IEnumerator MyMethod() 
    {
        yield return new WaitForSeconds(3f);
        
    }
}
