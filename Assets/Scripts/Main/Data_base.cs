using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine;
using System.Collections.Generic;

public class Data_base : MonoBehaviour
{
    private static string test_path;
    public static WorldsData worlds_data;
    public static WorldData current_world_data;

    private void Start()
    {
        test_path = Application.persistentDataPath + "/playerData.dat";
        LoadData();
    }

    public static void SaveData()
    {
        BinaryFormatter formatter = new();
        FileStream stream = new(test_path, FileMode.Create);

        formatter.Serialize(stream, worlds_data);
        stream.Close();
    }

    public static void LoadData()
    {
        if (File.Exists(test_path))
        {
            BinaryFormatter formatter = new();
            FileStream stream = new(test_path, FileMode.Open);

            worlds_data = formatter.Deserialize(stream) as WorldsData;
            stream.Close();
        }
        else
        {
            worlds_data = new WorldsData();
            worlds_data.world_data = new List<WorldData>();
        }
    }
}


[Serializable]
public class WorldsData
{
    public List<WorldData> world_data;
}

[Serializable]
public class WorldData
{
    public string world_name;
    public string creation_date_world;
    public int time_in_game;
    public MyVector3 player_position;
}

[Serializable]
public class MyVector3
{
    public float x, y, z;

    public MyVector3(Vector3 vector)
    { 
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }

    public Vector3 Convert()
    {
        return new Vector3(x, y, z);
    }
}