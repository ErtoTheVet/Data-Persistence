using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DataPersistance : MonoBehaviour
{
   public TMP_InputField NameField;
   
   public static DataPersistance Instance;
   
   public string userName;

   public int bestScore;

   private void Awake()
   {
      if (Instance != null)
      {
         Destroy(gameObject);
         return;
      }
      Instance = this;
      DontDestroyOnLoad(gameObject);
      
      LoadBestScore();
   }

   public void GetUserName()
   {
      userName = NameField.text;
   }
   public void SaveBestScore(string name, int score)
   {
      SaveName data = new SaveName();
      data.nameField = name;
      data.score = score;

      string Json = JsonUtility.ToJson(data);
                
      File.WriteAllText(Application.persistentDataPath + "/savefile.json", Json);
      Debug.Log(Application.persistentDataPath + "/savefile.json");
   }

   public void LoadBestScore()
   {
      string path = Application.persistentDataPath + "/savefile.json";
      if (File.Exists(path))
      {
         string Json = File.ReadAllText(path);
         SaveName data = JsonUtility.FromJson<SaveName>(Json);

         userName = data.nameField;
         bestScore = data.score;
      }
      else
      {
         bestScore = 0;
      }
   }
}
[Serializable]
public class SaveName
{
   public string nameField;
   public int score;
}
