using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class SlotManager : MonoBehaviour
{


    public Button load_1, load_2, load_3, save_1, save_2, save_3;
    void Start()
    {
        save_1 = GetComponent<Button>();
        save_2 = GetComponent<Button>();
        save_3 = GetComponent<Button>();
        load_1 = GetComponent<Button>();
        load_2 = GetComponent<Button>();
        load_3 = GetComponent<Button>();

    }
    public void Save_Slot_One()
    {

    }

    public void Save_Slot_Two()
    {

    }

    public void Save_Slot_Three()
    {

    }

    public void Load_Slot_One()
    {
       
    }

    public void Load_Slot_Two()
    {

    }

    public void Load_Slot_Three()
    {

    }


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
    }
}
