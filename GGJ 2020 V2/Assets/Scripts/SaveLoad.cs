using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
 
public class SaveLoad
{
    void Sart()
    {

    }

    public static void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.OpenOrCreate);
        HighscoreList hsList = new HighscoreList();
        bf.Serialize(file, hsList);
        file.Close();
    }

    public static bool Load()
    {
        if (File.Exists(Application.persistentDataPath + "/save.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/save.dat", FileMode.Open);
            HighscoreList serializableSaveData = (HighscoreList)bf.Deserialize(file);
            file.Close();
            //serializableSaveData.RestoreSaveData();
            return (true);
        }
        else
        {
            return (false);
        }
    }
}
