﻿using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class SlotManager : MonoBehaviour
{


    public Button load_1, load_2, load_3, save_1, save_2, save_3;
    public Player pa;
    private Vector3 player_position;
    public GameObject slot_1, slot_2, slot_3;
    public InputField inputfield_1, inputfield_2, inputfield_3;
    private string SlotName;
    void Start()
    {
        save_1 = GetComponent<Button>();
        save_2 = GetComponent<Button>();
        save_3 = GetComponent<Button>();
        load_1 = GetComponent<Button>();
        load_2 = GetComponent<Button>();
        load_3 = GetComponent<Button>();

        inputfield_1 = GetComponent<InputField>();
        inputfield_2 = GetComponent<InputField>();
        inputfield_3 = GetComponent<InputField>();

        /*slot_1 = GameObject.Find("SlotName1");
        inputfield_1 = slot_1.GetComponent<InputField>();

        slot_2 = GameObject.Find("SlotName2");
        inputfield_2 = slot_2.GetComponent<InputField>();

        slot_3 = GameObject.Find("SlotName2");
        inputfield_3 = slot_3.GetComponent<InputField>();*/
    }

    void Update()
    {

    }

    /*********************************************************************************************************************************************************************************************************************/
    /*********************************************************************************************************************************************************************************************************************/
    public void Save_Slot_One()
    {
        player_position = pa.transform.position;

        if (!Directory.Exists("Slot_1"))
        {
            Directory.CreateDirectory("Slot_1");
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create("save_one.sav");

        Position pos = new Position();
        pos.pos.x = player_position.x;
        pos.pos.y = player_position.y;
        pos.pos.z = player_position.z;

        formatter.Serialize(file, pos);
        file.Close();
    }

    public void Save_Slot_Two()
    {
        player_position = pa.transform.position;

        if (!Directory.Exists("Slot_2"))
        {
            Directory.CreateDirectory("Slot_2");
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create("save_two.sav");

        Position pos = new Position();
        pos.pos.x = player_position.x;
        pos.pos.y = player_position.y;
        pos.pos.z = player_position.z;

        formatter.Serialize(file, pos);
        file.Close();
    }


    public void Save_Slot_Three()
    {
        player_position = pa.transform.position;

        if (!Directory.Exists("Slot_3"))
        {
            Directory.CreateDirectory("Slot_3");
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create("save_three.sav");

        Position pos = new Position();
        pos.pos.x = player_position.x;
        pos.pos.y = player_position.y;
        pos.pos.z = player_position.z;

        formatter.Serialize(file, pos);
        file.Close();
    }

    /********************************************************************************************************************************************************************************************************************/
    /********************************************************************************************************************************************************************************************************************/

    public void Load_Slot_One()
    {

        if (File.Exists("save_one.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead("save_one.sav");

            Position data = (Position)bf.Deserialize(file);

            pa.transform.position = new Vector3(data.pos.x, data.pos.y, data.pos.z);
            file.Close();
        }
        else
        {
            slot_1.SetActive(true);
            if(inputfield_1.text != "")  //Si en el inputfield hay texto, quitamos la interactividad
            {
                slot_1.SetActive(false);
            }
        }
    }

    public void Load_Slot_Two()
    {
        if (File.Exists("save_two.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead("save_two.sav");

            Position data = (Position)bf.Deserialize(file);

            pa.transform.position = new Vector3(data.pos.x, data.pos.y, data.pos.z);
            file.Close();
        }
        else
        {
            slot_2.SetActive(true);
            if (inputfield_2.text != "")  //Si en el inputfield hay texto, quitamos la interactividad
            {
                slot_2.SetActive(false);
            }
        }
    }

    public void Load_Slot_Three()
    {
        if (File.Exists("save_three.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead("save_three.sav");

            Position data = (Position)bf.Deserialize(file);

            pa.transform.position = new Vector3(data.pos.x, data.pos.y, data.pos.z);
            file.Close();
        }
        else
        {
            slot_3.SetActive(true);
            if (inputfield_3.text != "")  //Si en el inputfield hay texto, quitamos la interactividad
            {
                slot_3.SetActive(false);
            }
        }
    }

    /********************************************************************************************************************************************************************************************************************/
    /********************************************************************************************************************************************************************************************************************/

    [Serializable]
    class Position
    {
        [Serializable]
        public struct Vector3
        {
            public float x, y, z;

            public Vector3(float _x, float _y, float _z)
            {
                x = _x;
                y = _y;
                z = _z;
            }
        }
        public Vector3 pos = new Vector3(0, 0, 0);
    }
}