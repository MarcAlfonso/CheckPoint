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
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.Space))
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
