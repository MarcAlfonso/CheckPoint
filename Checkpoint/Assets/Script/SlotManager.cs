using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class SlotManager : MonoBehaviour
{

    public GameObject[] enemies;
    public Button load_1, load_2, load_3, save_1, save_2, save_3;
    public Player player;
    private Vector3 player_position;
    public GameObject slot_1, slot_2, slot_3;
    public InputField inputfield_1, inputfield_2, inputfield_3;
    private string SlotName;
    void Start()
    {
        inputfield_1.text = "SLOT 1";
        inputfield_2.text = "SLOT 2";
        inputfield_3.text = "SLOT 3";

        slot_1.GetComponentInChildren<SlotTitle>().input = inputfield_1;
        slot_2.GetComponentInChildren<SlotTitle>().input = inputfield_2;
        slot_3.GetComponentInChildren<SlotTitle>().input = inputfield_3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            inputfield_1.gameObject.SetActive(false);
            inputfield_2.gameObject.SetActive(false);
            inputfield_3.gameObject.SetActive(false);
        }
    }

    /*********************************************************************************************************************************************************************************************************************/
    /*********************************************************************************************************************************************************************************************************************/

    void Save(string filename)
    {
        player_position = player.transform.position;
        FileStream file = File.Open(filename, FileMode.Create);
        BinaryFormatter formatter = new BinaryFormatter();

        Position pos = new Position();
        pos.posPlayer.x = player_position.x;
        pos.posPlayer.y = player_position.y;
        pos.posPlayer.z = player_position.z;
        pos.playerIsAlive = true;

        pos.enemyIsAlive = new bool[enemies.Length];
        pos.posEnemies = new Position.Vector3[enemies.Length];

        int i = 0;
        foreach (GameObject enemy in enemies)
        {
            pos.posEnemies[i].x = enemy.transform.position.x;
            pos.posEnemies[i].y = enemy.transform.position.y;
            pos.posEnemies[i].z = enemy.transform.position.z;
            pos.enemyIsAlive[i] = enemy.activeInHierarchy;
            i++;
        }

        formatter.Serialize(file, pos);

        file.Close();
    }


    public void Save_Slot_One()
    {
        if (!File.Exists("save_one.sav"))
        {
            Debug.Log("Activating input");
            inputfield_1.gameObject.SetActive(true);
            inputfield_1.ActivateInputField();
        }
        Save("save_one.sav");
    }

    public void Save_Slot_Two()
    {
        if (!File.Exists("save_two.sav"))
        {
            Debug.Log("Activating input");
            inputfield_2.gameObject.SetActive(true);
            inputfield_2.ActivateInputField();
        }
        Save("save_two.sav");
    }


    public void Save_Slot_Three()
    {
        if (!File.Exists("save_three.sav"))
        {
            Debug.Log("Activating input");
            inputfield_3.gameObject.SetActive(true);
            inputfield_3.ActivateInputField();
        }
        Save("save_three.sav");
    }

    /********************************************************************************************************************************************************************************************************************/
    /********************************************************************************************************************************************************************************************************************/

     void Load(string filename)
    {
        if (File.Exists(filename))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(filename);

            Position data = (Position)bf.Deserialize(file);
            //Debug.Log("Vector pos: " + data.posPlayer.x + ", " + data.posPlayer.y + ", " + data.posPlayer.z);
            player.transform.position = new Vector3(data.posPlayer.x, data.posPlayer.y, data.posPlayer.z);

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].transform.position = new Vector3(data.posEnemies[i].x, data.posEnemies[i].y, data.posEnemies[i].z);
                enemies[i].SetActive(data.enemyIsAlive[i]);
            }

            file.Close();
        }else Debug.Log("File " + filename + "doesn't exist!");
    }

    public void Load_Slot_One()
    {
        Load("save_one.sav");
    }

    public void Load_Slot_Two()
    {
        Load("save_two.sav");
    }

    public void Load_Slot_Three()
    {
        Load("save_three.sav");
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
        public bool playerIsAlive = true;
        public Vector3 posPlayer = new Vector3(0, 0, 0);

        public Vector3[] posEnemies;
        public bool[] enemyIsAlive;
    }
}
