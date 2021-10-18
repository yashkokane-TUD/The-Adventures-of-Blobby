using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TransformationManager : MonoBehaviour
{
    private potionCollection PC;
    private PlayerMovement pM;
    
    public GameObject transformWheel;
    public GameObject HSmall;
    public GameObject HBig;
    public GameObject H_E1;
    public GameObject H_E2;
    public bool canTransform;
    public static int TransformID = 0;
    public bool show;
    // Start is called before the first frame update
    void Start()
    {
        pM = FindObjectOfType<PlayerMovement>();
        PC = FindObjectOfType<potionCollection>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthManager.PlayerHP < 50)
        {
            canTransform = false;
            transformCheck();
        }
        else
        {
            canTransform = true;
        }
    }

    public void transformCheck()
    {
        if (!canTransform)
        {
            HSmall.SetActive(true);
            HBig.SetActive(false);
            pM.moveForce = 25;
            PlayerMovement.p_level1 = true;
            PlayerMovement.p_level2 = false;
        }
    }
    public void TranformWheel()
    {
        show = !show;
        if (show)
        {
            transformWheel.SetActive(true);
            
            TransformID = 0;

        }
        else
        {
            transformWheel.SetActive(false);
        }
    }
    
    public void TransformationData(){
        //Debug.Log(TransformID);
        switch (TransformID)
        {
            case 0: //nothing selected
                break;
            case 1:
                //Debug.Log("small");
                pM.Jump();
                HSmall.SetActive(true);
                HBig.SetActive(false);
                H_E1.SetActive(false);
                H_E2.SetActive(false);
                pM.moveForce = 25;
                PlayerMovement.p_level1 = true;
                PlayerMovement.p_level2 = false;
                PlayerMovement.p_E1 = false;
                PlayerMovement.p_E2 = false;
                //pM.sizeupdate();
                break;
            case 2:
                if (canTransform)
                {
                    HBig.SetActive(true);
                    HSmall.SetActive(false);
                    H_E1.SetActive(false);
                    H_E2.SetActive(false);
                    pM.Jump();
                    pM.moveForce = 35;
                    PlayerMovement.p_level1 = false;
                    PlayerMovement.p_level2 = true;
                    PlayerMovement.p_E1 = false;
                    PlayerMovement.p_E2 = false;
                }
                //Debug.Log("big");
                //pM.sizeupdate();
                
                break;
            case 3:
                
                //PotionUsage(25);
                HSmall.SetActive(false);
                HBig.SetActive(false);
                H_E1.SetActive(true);
                H_E2.SetActive(false);
                pM.Jump();
                pM.moveForce = 30;
                //Debug.Log("E1");
                gameObject.tag = "Player";
                PlayerMovement.p_level1 = false;
                PlayerMovement.p_level2 = false;
                PlayerMovement.p_E1 = true;
                PlayerMovement.p_E2 = false;
                potionCollection.RReduceCount();
                
                
                /*pM.canDash = false;
                pM.canJump = false;
                pM._superJump = false;*/
                break;
            case 4:
                //Debug.Log("E2");
                //PotionUsage(50);
                H_E1.SetActive(true);
                H_E2.SetActive(false);
                HBig.SetActive(false);
                HSmall.SetActive(false);
                pM.Jump();
                
                gameObject.tag = "Player";
                PlayerMovement.p_level1 = false;
                PlayerMovement.p_level2 = false;
                PlayerMovement.p_E1 = false;
                PlayerMovement.p_E2 = true;
                potionCollection.RReduceCount();
                break;
        }
    }

   
}
