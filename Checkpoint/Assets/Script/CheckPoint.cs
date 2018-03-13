using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float jumpForce = 20f;
    public GameObject CP, player;

    private bool isActivated = false;
    private Vector3 checkPos, playerPos;
    private bool isActive = true;
    private bool cpActived = false;



    // Use this for initialization
    void Start()
    {
        checkPos = CP.transform.position;
        playerPos = player.transform.position;
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
        cpActived = true;
        player.SetActive(false);
        yield return new WaitForSeconds(2f);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "checkpoint")
        {
            StartCoroutine(Wait());
            player.transform.position = Vector3.zero;
            player.SetActive(true);
        }


    }


    void ActivateCheckPoint()
    {

    }
}
   
