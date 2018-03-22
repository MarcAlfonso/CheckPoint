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
        playerPosition = player.transform.position;
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
        if (!Directory.Exists("SaveGame"))
        {
            Directory.CreateDirectory("SaveGame");
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(path);

        Data data = new Data();
        data.pos = playerPosition;

        formatter.Serialize(file, data.pos);
        file.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.persistentDataPath + path);

            Data data = (Data)bf.Deserialize(file);

            playerPosition = data.pos;
            file.Close();
        }
    }


    [Serializable]
    class Data
    {
        public Vector3 pos = new Vector3(1,2,1);
        public int score = 50;
    }
}
