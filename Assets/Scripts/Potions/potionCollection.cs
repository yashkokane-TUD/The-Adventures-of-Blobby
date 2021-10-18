using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class potionCollection : MonoBehaviour
{
     public static int potion_B_Count;
     public static int potion_R_Count;
    
    //public int potion_G_Count;

    public static int maxRpotions = 100;
    //public int maxGpotions = 100;
    private static int maxBpotions = 100;
    

    //private PotionRManager PM_R;
    //private static PotionBManager PM_B;
    //private PotionGManager PM_G;
    private PlayerMovement pM;
    
    //private int BluePotionCount;
    void Awake()    
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        //PM_R = FindObjectOfType<PotionRManager>();
        //PM_B = FindObjectOfType<PotionBManager>();
        pM = FindObjectOfType<PlayerMovement>();
        PotionBManager.SetPotionB(potion_B_Count);
    }
  
    
    // Update is called once per frame
    public  static void UpdateRedCount()
    {
        potion_R_Count = potion_R_Count + 10;
        if (potion_R_Count >= maxRpotions)
        {
            potion_R_Count = maxRpotions;
        }
        PotionRManager.SetPotionR(potion_R_Count);

    }
    public static void UpdateBlueCount()
    {
        potion_B_Count = potion_B_Count + 10;
        
        if (potion_B_Count >= maxBpotions)
        {
            potion_B_Count = maxBpotions;
        }
        PotionBManager.SetPotionB(potion_B_Count);
    }

    public static void BReduceCount()
    {
        potion_B_Count = potion_B_Count - 2;
        PotionBManager.SetPotionB(potion_B_Count);
        //Debug.Log(potion_B_Count);
    }
    
    public static void RReduceCount()
    {
        if (PlayerMovement.p_E1)
        {
            
            potion_R_Count = potion_R_Count - 35;
            //Debug.Log(potion_R_Count);
            PotionRManager.SetPotionR(potion_R_Count);
            
        }
        else if (PlayerMovement.p_level2)
        {
            //Debug.Log("E2 hit");
            potion_B_Count = potion_R_Count - 75;
            PotionRManager.SetPotionR(potion_R_Count);
        }
        
        //Debug.Log(potion_B_Count);
    }
    
}
