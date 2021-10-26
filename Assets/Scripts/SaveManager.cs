using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public SaveData activeSave;
    public static SaveManager instance;
    public bool hasloaded;
    public Vector3 resPt;
    public bool saveExists = false;
    public GameObject[] saveobjects;
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        //Load();
    }

    private void Start()
    {
        /*saveobjects = GameObject.FindGameObjectsWithTag("SaveManager");
        if (saveobjects.Length > 1)
        {
            Destroy(saveobjects[1]);
        }*/
    }

    public void Save()
    {
        string datapath = Application.persistentDataPath;
        var serializer = new XmlSerializer(typeof(SaveData));
        var stream = new FileStream(datapath + "/" + activeSave.saveName+".save",FileMode.Create);
        serializer.Serialize(stream,activeSave);
        stream.Close();
        Debug.Log("save created");
        saveExists = true;
    }

    public void Load()
    {
        string dataPath = Application.persistentDataPath;
        if (System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
            var serializer = new XmlSerializer(typeof(SaveData));
            var stream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Open);
            activeSave = serializer.Deserialize(stream) as SaveData;
            stream.Close();
            
            Debug.Log("File Loaded");
            hasloaded = true;
        }
        //resPt = player.transform.position;
        if (SaveManager.instance.hasloaded)
        {
            Debug.Log("file loaded");
            PlayerMovement.pMovement.transform.position = SaveManager.instance.activeSave.resPos;
            //lives = SaveManager.instance.activeSave.lives;
            HealthManager.PlayerHP = SaveManager.instance.activeSave.HP;
            Debug.Log("health mang" +HealthManager.PlayerHP);
            Debug.Log("save hp"+SaveManager.instance.activeSave.HP);
        }

    }

    public void DeleteSave()
    {
        string dataPath = Application.persistentDataPath;
        if (System.IO.File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
            File.Delete(dataPath + "/" + activeSave.saveName + ".save");
        }
    }
}

[System.Serializable]
public class SaveData
{
    public string saveName;
    public Vector3 resPos;
    //public bool doorOpen;
    public int lives;
    public int HP;
    public int potionsR;
    public int potionsB;
}
