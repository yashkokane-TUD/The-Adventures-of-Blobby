using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    private  Vector3 StartPos;
    //public static int score;
    
    private bool gamePaused = false;
    
    public GameObject menu;
    
    private gameManager Gm;
    private HealthManager _healthManager;
    private static gameManager Instance;
    public GameObject introDialogue;

    void Awake ()   
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
    }
    
    private void Start()
    {
        if (!closeDialogue.instance.close)
        {
            introDialogue.SetActive(true);
        }
        
        _healthManager = FindObjectOfType<HealthManager>();
        //Gm = FindObjectOfType<gameManager>();
        DontDestroyOnLoad(gameObject);
    }

    public void TogglePauseState()
    {
        if (gamePaused)
        {
            UnPauseGame();
        }
        else
        { 
            PauseGame();
        }
    }
     public void PauseGame()
     {
         Time.timeScale = 0;
         
     }

     public void UnPauseGame()
     {
         Time.timeScale = 1;
         menu.SetActive(false);
     }

     public void RestartGame()
     {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         _healthManager.ResetHealth();
     }

     public void Quit()
     {
         //If we are running in a standalone build of the game
#if UNITY_STANDALONE
         //Quit the application
         Application.Quit();
#endif

         //If we are running in the editor
#if UNITY_EDITOR
         //Stop playing the scene
         UnityEditor.EditorApplication.isPlaying = false;
#endif
     }
     public void QuitGame()
     {
         SceneManager.LoadScene("Menu_Scene");
     }

         
}
