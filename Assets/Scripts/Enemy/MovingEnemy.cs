using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public GameObject _enemy;
    public GameObject _SJAbility;
    
    //enemy stats
    private float moveSpeed = 3;
    public  int health = 4;

    public Animator anim;
    //enemy patrolling control variables
    public Transform currentPosition;
    public Transform[] points;
    public int pointSelect;
    
    //invoke to check Player dash ability access
    public PlayerMovement Dash; 
    
    private DropMultipleItems DItems;
    private SpriteRenderer mySR;    //Enemy sprite access
    //player movement script Dash ability call
    
    public GameObject roof ;
    
    //camera objects
    public CinemachineVirtualCamera MainCam;

    public CinemachineVirtualCamera Cutscene;
    // Start is called before the first frame update
    void Start()
    {
        mySR = GetComponentInChildren<SpriteRenderer>();
        currentPosition = points[pointSelect];
        
        DItems = FindObjectOfType<DropMultipleItems>();
    }

    // Update is called once per frame
    void Update()
    {
        //patrolling enemy code that checks the patrol points assigned to it and flips sprite as per direction
        _enemy.transform.position = Vector3.MoveTowards(_enemy.transform.position, currentPosition.position,
            moveSpeed * Time.deltaTime);

        if (_enemy.transform.position == currentPosition.position)
        {
            pointSelect++;
            
            mySR.flipX = true;

            if (pointSelect == points.Length)
            {
                pointSelect = 0;
                
                mySR.flipX = false;
            }

            currentPosition = points[pointSelect];
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && Dash.Dashing || other.gameObject.tag == "Bullet")
        {
            Debug.Log(health);
            health = health - 1;
    
            if (health == 0)
            {
                //playCutScene();//destroy enemy object
                Destroy(roof);
                _SJAbility.SetActive(true);
                DItems.dropItemOnDeath2();
            }
        }
    }
    /*public void playCutScene()
    {
        //yield return new WaitForSeconds(6f);
        /*Debug.Log("end cut");#1#
        //StartCoroutine(endCutScene());
        /*Cutscene.enabled = true;
        MainCam.enabled = false;#1#
        MainCam.Priority = 8;
        Cutscene.Priority = 9;
        anim.Play("buff view");
        MainCam.Priority = 9;
        Cutscene.Priority = 8;
        /*MainCam.enabled = true;
        Cutscene.enabled = false;#1#
        Destroy(gameObject); 
        
    }
    /*IEnumerator endCutScene()
    {
        
        Cutscene.enabled = true;
        MainCam.enabled = false;
        MainCam.Priority = 8;
        Cutscene.Priority = 9;
        anim.Play("buff view");
    }#1#*/

}
