using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 20f;
    public GameObject checkP, player;

    private bool isActivated = false;
    private Vector3 checkPos, playerPos;
    private bool cpActived = false;
    private bool isColorChanged = false;
    private Renderer rend;
    private Color col;
    private bool isColliderCheckP = false, isCollidedDeath = false;

    // Use this for initialization
    void Start()
    {
        checkPos = checkP.transform.position;
        playerPos = player.transform.position;
        rend = checkP.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        //Debug.Log(playerPos);
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            player.transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            player.transform.Translate(Vector3.up * Time.deltaTime * jumpForce);
        }
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "checkpoint")
        {
            rend.material.color = Color.cyan;
            isColliderCheckP = true;
        }
        else if(other.gameObject.tag == "death")
        {
            isCollidedDeath = true;
        }
        if(isCollidedDeath && isColliderCheckP)
        {
            isColliderCheckP = false;
            isCollidedDeath = false;
            ActivateCheckPoint();
            DieAndSpawn();
        }

        //NO DEJA METER UN IF DENTRO DE OTRO IF Y QUE EL SEGUNDO IF MIRE UNA COLISION

    }
    /*void OnCollisionExit(Collision coll)
    {
        if (coll.gameObject.tag == "death")
            isCollidedDeath = false;
        else if (coll.gameObject.tag == "checkpoint")
            isColliderCheckP = false;
    }*/

    void ActivateCheckPoint()
    {
        cpActived = true;
        isColorChanged = true;
    }

    void DieAndSpawn()
    {
        player.SetActive(true);
        player.transform.position = checkP.transform.position;
    }
}

