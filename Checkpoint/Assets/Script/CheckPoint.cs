using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //Public variables
    public GameObject checkPoint, ObjToRend;
    public GameObject deadMenu;

    //Private variables
    private Vector3 checkPos, playerPos;
    private Renderer rend, rend2;
    private Color col;
    private bool isCollidedDeath = false;
    private bool cpActivated = false;
    private bool isColorChanged = false;
    private GameData gd;
    private bool isCollidedCheckP = false;
    private bool isDeadMenuActive;



    void Start()
    {
        checkPos = checkPoint.transform.position;
        playerPos = transform.position;
        rend = checkPoint.GetComponent<Renderer>();
        rend2 = ObjToRend.GetComponent<Renderer>();
        gd = FindObjectOfType<GameData>();
    }
    
    //Function to detect the collisions between the Player and the Checkpoint / Death
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "checkpoint")
        {
            col.gameObject.GetComponent<Renderer>().material.color = Color.white;  //Cambiamos el color del objeto con el que hemos chocadoi
            isCollidedCheckP = true;
            gd.SaveGame();
            //DieAndSpawn();
        }
        if (col.tag == "death")
        {
            isCollidedDeath = true;
            transform.position = Vector3.zero;
            deadMenu.SetActive(true);
            isDeadMenuActive = true;
        }
        if (isCollidedDeath && isCollidedCheckP)
        {
            isCollidedCheckP = false;
            isCollidedDeath = false;
            ActivateCheckPoint();
            //transform.position = Vector3.zero;

            gd.LoadGame();
        }

    }

    //Function to activate the checkpoint
    void ActivateCheckPoint()
    {
        cpActivated = true;
        isColorChanged = true;
    }

    void DieAndSpawn()
    {
        transform.position = checkPoint.transform.position;
    }

    public void ChangeColor()
    {
        rend.material.color = Color.cyan;
        rend2.material.color = Color.cyan;
    }
}