using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour {

    //PUBLIC VARIABLES
    public GameObject player;
    public Button save, load;
    //public CheckPoint cp;
    


    //PRIVATE VARIABLES
    private string path = "/player.dat";



    
    void Start ()
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
        /*Debug.Log("you clicked the load button!!!");
        LoadGame();*/
    }


    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/test.dat");

        /*Data data = new Data();
        data.pos = player.transform.position;  */
        bf.Serialize(file, transform.position);
        file.Close();

   
    
}
    
    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/player.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenWrite(Application.persistentDataPath + path);

            Data data = (Data)bf.Deserialize(file);

            player.transform.position = data.pos;
            file.Close();
        }
    }
    

    [Serializable]
    class Data
    {
        public Vector3 pos;
    }
}
