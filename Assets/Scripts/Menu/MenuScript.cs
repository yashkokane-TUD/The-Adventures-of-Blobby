using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
   
    public void PlayGame()
    {
        HealthManager.PlayerHP = 12;
        potionCollection.potion_B_Count = 0;
        potionCollection.potion_R_Count = 0;
        SceneManager.LoadScene("level-1");
    }

    public void RestartGame()
    {
        HealthManager.PlayerHP = 15;
        SceneManager.LoadScene("level-1");  
    }
    public void Quit()
    {
        SceneManager.LoadScene("Menu_Scene");
    }
}
