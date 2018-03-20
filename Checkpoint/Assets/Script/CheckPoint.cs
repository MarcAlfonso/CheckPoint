using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //Public variables
    public GameObject checkPoint, ObjToRend;

    //Private variables
    private Vector3 checkPos, playerPos;
    private Renderer rend, rend2;
    private Color col;
    private bool isCollidedDeath = false;
    private bool isCollidedCheckP = false;
    private bool cpActivated = false;
    private bool isColorChanged = false;


    void Start()
    {
        checkPos = checkPoint.transform.position;
        playerPos = transform.position;
        rend = checkPoint.GetComponent<Renderer>();
        rend2 = ObjToRend.GetComponent<Renderer>();
    }
    
    //Function to detect the collisions between the Player and the Checkpoint / Death
    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Collider>().tag == "checkpoint")
        {
            rend.material.color = Color.cyan;
            rend2.material.color = Color.cyan;
            
            isCollidedCheckP = true;
        }
        if (col.GetComponent<Collider>().tag == "death")
        {
            isCollidedDeath = true;
            transform.position = Vector3.zero;
        }
        if (isCollidedDeath && isCollidedCheckP)
        {
            isCollidedCheckP = false;
            isCollidedDeath = false;
            ActivateCheckPoint();
            DieAndSpawn();
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
}