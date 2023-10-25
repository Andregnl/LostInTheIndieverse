using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public SettingsData settingsData = new SettingsData();

    private bool isInstance = false;
    const string settingsSaveDataPath = "/SettingsSaveData.dat";

    // Start is called before the first frame update
    void Awake()
    {
        HandlePersistentSettingsData();
        Debug.Log(settingsData.SFXVolume);
        Debug.Log(settingsData.musicVolume);

        if (Instance != null && Instance != this)
        {
            // There's already an instance, destroy this one
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            isInstance = true;
            DontDestroyOnLoad(gameObject.transform.root.gameObject);
        }
    }

    public void SaveSettingsData()
    {
        Debug.Log("Audio saved!");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream saveFile = new FileStream(Application.persistentDataPath + settingsSaveDataPath, FileMode.Create);
        bf.Serialize(saveFile, settingsData);
        saveFile.Close();
    }

    void HandlePersistentSettingsData()
    {
        if (File.Exists(Application.persistentDataPath + settingsSaveDataPath))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream settingsSaveFile = File.Open(Application.persistentDataPath + settingsSaveDataPath, FileMode.Open);
            settingsData = (SettingsData)bf.Deserialize(settingsSaveFile);
            settingsSaveFile.Close();
        }
        else
        {
            SaveSettingsData();
        }
    }
}