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
    private LifeManager _lifeManager;
    private static gameManager Instance;
    public GameObject introDialogue;
    public closeDialogue cD;

    private SaveManager _saveManager;
    public GameObject player;
    public int lives;
    public Vector3 resPt;
    private PlayerMovement pM;
    
    public GameObject CurrentCheckpoint;
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
        pM = FindObjectOfType<PlayerMovement>();
        _healthManager = FindObjectOfType<HealthManager>();
        _lifeManager = FindObjectOfType<LifeManager>();
        cD = FindObjectOfType<closeDialogue>();
        _saveManager = FindObjectOfType<SaveManager>();
        if (!cD.close)
        {
            introDialogue.SetActive(true);
        }
        SaveManager.instance.Load();
        //resPt = player.transform.position;
        if (MainMenu.LoadedGame = true)
        {
            if (SaveManager.instance.hasloaded)
            {
                player.transform.position = SaveManager.instance.activeSave.resPos;
                lives = SaveManager.instance.activeSave.lives;
            }
            else
            {
                SaveManager.instance.activeSave.lives = lives;
            }
        }
        
        
        DontDestroyOnLoad(gameObject);
    }
    public void RespawnPlayer()
    {
        pM.transform.position = CurrentCheckpoint.transform.position;
        _healthManager.ResetHealth();
        //SaveManager.instance.Save();
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
         SaveManager.instance.activeSave.resPos = transform.position;
         SaveManager.instance.activeSave.lives = _lifeManager.LifeCounter;
         SaveManager.instance.activeSave.HP = HealthManager.PlayerHP;
         SaveManager.instance.activeSave.potionsB = potionCollection.potion_B_Count;
         SaveManager.instance.activeSave.potionsR = potionCollection.potion_R_Count;
         SaveManager.instance.Save();
         SceneManager.LoadScene("Menu_Scene");
     }

         
}
