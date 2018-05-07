using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateModel : MonoBehaviour {

    public GameObject terminal;
    public float rotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        terminal.transform.Rotate(0, -15 * Time.deltaTime * rotationSpeed, 0);

    }
}
