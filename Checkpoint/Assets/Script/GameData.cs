using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


[Serializable]
public class GameData : MonoBehaviour {

    //PUBLIC VARIABLES
    public GameObject player;
    


    //PRIVATE VARIABLES
    private string filename = "/player.dat";



    
    void Start () {
        SaveGame();
        LoadGame();

    }
	

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + filename);

        Player data = new Player();
        
        bf.Serialize(file, data.currentPos);
        file.Close();

    }
    
    private void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + filename))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + filename, FileMode.Open);
            Player data = bf.Deserialize(stream) as Player;
            stream.Close();
        }
    }
}
