using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
 
public class SaveLoad
{
    public HighscoreVariable Highscores;

    public static string PathString;

    public SaveLoad() {
        PathString = Path.Combine(Application.persistentDataPath, "save.dat");
    }

    public void Save()
    {
        var bf = new BinaryFormatter();
        using(var file = File.Open(PathString, FileMode.OpenOrCreate)) {
            bf.Serialize(file, Highscores.HighscoreList);
        }
    }

    public static bool Load()
    {
        if (File.Exists(PathString))
        {
            Debug.Log("IT EXISTS");
            var bf = new BinaryFormatter();
            using (var file = File.Open(PathString, FileMode.Open)) {
                var serializableSaveData = (HighscoreList) bf.Deserialize(file);
            }

            return (true);
        }
        else
        {
            return (false);
        }
    }
}
