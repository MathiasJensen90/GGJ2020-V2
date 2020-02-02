using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
 
public class SaveLoad
{
    public HighscoreVariable Highscores;

    public void Save()
    {
        var bf = new BinaryFormatter();
        using(var file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.OpenOrCreate)) {
            bf.Serialize(file, Highscores.HighscoreList);
        }
    }

    public static bool Load()
    {
        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            var bf = new BinaryFormatter();
            using (var file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open)) {
                var serializableSaveData = (HighscoreList)bf.Deserialize(file);
            }

            return (true);
        }
        else
        {
            return (false);
        }
    }
}
