using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class HighScore : MonoBehaviour
{
    public static HighScore Instance;
    public int highScore;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }


    /// <summary>
    /// Saves the Highscore to a Json string and file 
    /// </summary>

    public void SaveHighScore()
    {
        SaveData saveData = new SaveData();
        saveData.highScore  = highScore;
        string json = JsonUtility.ToJson(saveData);


        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    /// <summary>
    /// Loads the saved high score from a json file
    /// </summary>
    public void LoadHighScore()
    {
        // Load the JSON string from the player prefs
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);
                        
            highScore = saveData.highScore;


        }
    }

    /// <summary>
    /// Class to hold data for saving high scores.
    /// </summary>

    [Serializable]
    public class SaveData
    {
         /// <summary>
        /// The highest score achieved.
        /// </summary>
        public int highScore;
    }

}



