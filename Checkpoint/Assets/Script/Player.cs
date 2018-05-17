using UnityEngine;
using System;



[Serializable]
public class Player : MonoBehaviour {

    public float speed = 20f;
    public float force = 20f;
    [HideInInspector]public int score = 0;
    private GameObject[] enemies;

    [HideInInspector]public bool isAlive = true; //Miramos si el enemigo está vivo
    	
	void Update ()
    {
        Movement();
        enemies = GameObject.FindGameObjectsWithTag("enemy");
	}

    void Movement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * force);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemy" && isAlive)
        {
            other.gameObject.SetActive(false);
            isAlive = false;
        }
        isAlive = true;
    }
}
