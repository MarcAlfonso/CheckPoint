using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class GameData : MonoBehaviour
{

    //PUBLIC VARIABLES
    public GameObject player;
    public Button load;


    //PRIVATE VARIABLES
    private string path = "save.sav";
    private Player pa;
    private Vector3 playerPosition;
    private bool isEnemyAlive = true;

    //INICIALIZAMOS EL LOAD AL COMPONENTE BOTON
    void Start()
    {
        load = GetComponent<Button>();
    }

    //AL PRESIONAR EL BOTON LOAD LLAMAMOS A LA FUNCION QUE CARGA EL FICHERO CON LA NUEVA POSICION
    public void OnClickLoad()
    {
        LoadGame();
    }


    //FUNCIÓN PARA GUARDAR LA POSICIÓN DEL PLAYER
    public void SaveGame()
    {
        playerPosition = player.transform.position;
        //isEnemyAlive = pa.isAlive;
        //SI LA CARPETA NO EXISTE LA CREAMOS
        if (!Directory.Exists("SaveGame"))
        {
            Directory.CreateDirectory("SaveGame");
        }

        //CREAMOS EL FICHERO QUE CONTENDRA LOS DATOS
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file = File.Create(path); //PATH = "SAVE.SAV"
         
        Data data = new Data();
        //GUARDAMOS LOS DATOS DEL PLAYER
        data.pos.x = playerPosition.x;
        data.pos.y = playerPosition.y;
        data.pos.z = playerPosition.z;
        /*data.isAlive = isEnemyAlive;*/

        formatter.Serialize(file, data);
        file.Close();
    }

    //FUNCIÓN PARA CARGAR LA POSICION DEL PLAYER QUE PREVIAMENTE HEMOS GUARDADO EN 3 VARIABLES (DATA.POS)
    public void LoadGame()
    {
        //SI EL FICHERO EXISTE LO ABRIMOS Y LO LEEMOS
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(path);

            Data data = (Data)bf.Deserialize(file);

            //CAMBIAMOS LA POSICION DEL PLAYER POR LA POSICION GUARDADA
            player.transform.position = new Vector3(data.pos.x, data.pos.y, data.pos.z);
            /**/
            file.Close();
        }
    }


    //SERIALIZAMOS LA CLASE PARA PODER GUARDAR LOS DATOS
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
        public bool isAlive = true;
    }
}
