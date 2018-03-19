using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    //Public variables
    public float moveSpeed = 20f;
    public float jumpForce = 20f;
    public GameObject checkPoint, ObjToRend;

    //Private variables
    private Vector3 checkPos, playerPos;
    private Renderer rend, rend2;
    private Color col;
    private bool isCollidedDeath = false;
    private bool isCollidedCheckP = false;
    private bool cpActivated = false;
    private bool isColorChanged = false;
    private Transform playerTransform;


    void Start()
    {
        checkPos = checkPoint.transform.position;
        playerPos = transform.position;
        rend = checkPoint.GetComponent<Renderer>();
        rend2 = ObjToRend.GetComponent<Renderer>();
    }


    void Update()
    {
        Movement();
    }

    //Movement function
    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * jumpForce);
        }
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