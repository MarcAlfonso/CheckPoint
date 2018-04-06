using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{

    //PUBLIC VARIABLES
    public GameObject player;
    public Button save, load;
    
    //public CheckPoint cp;



    //PRIVATE VARIABLES
    private string path = "SaveGame/save.sav";
    private Player pa;
    private Vector3 playerPosition;


    void Start()
    {
        save = GetComponent<Button>();
        load = GetComponent<Button>();
    }

    void Update()
    {

    }

    public void OnClickSave()
    {
        Debug.Log("you clicked the save button!!");
        SaveGame();
    }

    public void OnClickLoad()
    {
        Debug.Log("you clicked the load button!!!");
        LoadGame();
    }


    public void SaveGame()
    {
        playerPosition = player.transform.position;
        if (!Directory.Exists("SaveGame"))
        {
            Directory.CreateDirectory("SaveGame");
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(path);

        Data data = new Data();
        data.pos.x = playerPosition.x;
        data.pos.y = playerPosition.y;
        data.pos.z = playerPosition.z;

        formatter.Serialize(file, data);
        file.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(path);

            Data data = (Data)bf.Deserialize(file);

            player.transform.position = new Vector3(data.pos.x, data.pos.y, data.pos.z);
            file.Close();
        }
    }


    [Serializable]
    class Data
    {
        [Serializable]
        public struct Vector3 {
            public float x, y, z;

            public Vector3(float _x, float _y, float _z)
            {
                x = _x;
                y = _y;
                z = _z;
            }
        }
        public Vector3 pos = new Vector3(1,2,1);
        public int score = 50;
    }
}
