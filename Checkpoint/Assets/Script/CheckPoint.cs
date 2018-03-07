using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {
    public float moveSpeed = 10f;
    public float jumpSpeed = 20f;
    public GameObject check_point;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Movement();
	}

    void Movement()
    {
        if(Input.GetKey(KeyCode.W))
        {
            player.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        else if(Input.GetKey(KeyCode.S))
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
        else if(Input.GetKey(KeyCode.Space))
        {
            player.transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed);
        }
    }
    
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "CheckPoint")
        {
            Debug.Log("Has chocado con el checkpoint!");
        }
    }
}
