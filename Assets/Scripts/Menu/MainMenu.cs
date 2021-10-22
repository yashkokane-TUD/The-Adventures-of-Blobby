using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject LoadButton;
    public static bool LoadedGame;
    public void PlayGame()
    {
        SceneManager.LoadScene("Introduction");
    }

    public void LoadGame()
    {
        string dataPath = Application.persistentDataPath;
        if (System.IO.File.Exists(dataPath + "/" + SaveManager.instance.activeSave.saveName + ".save"))
        {
            LoadedGame = true;
            LoadButton.SetActive(true);
            SceneManager.LoadScene("Introduction");
            /*var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + SaveManager.instance.activeSave.saveName + ".save", FileMode.Open);
            SaveManager.instance.activeSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();
            SaveManager.instance.hasloaded = true;*/
        }
        else
        {
            LoadButton.SetActive(false);
            LoadedGame = false;
        }
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
}
