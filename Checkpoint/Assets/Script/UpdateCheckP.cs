using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//THIS SCRIPT GOES INTO PLAYER'S GAMEOBJECT
public class UpdateCheckP : MonoBehaviour {

    private GameObject[] checkPoints;
    private bool lastCheck = false;
    private Vector3 playerPosition, checkPosition;

	// Use this for initialization
	void Start () {
        playerPosition = transform.position;
        for (int i = 0; i < checkPoints.Length; i++)
        {

        }
            //checkPosition = checkPosition[i].transform.position;        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
