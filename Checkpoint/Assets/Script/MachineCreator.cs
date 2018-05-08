using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineCreator : MonoBehaviour {

    public GameObject machine;
    public int numberMachines = 200;
    private Vector3 machinePosition;


    void Awake()
    {
        StartCoroutine(Wait());
        for (int i = 0; i < numberMachines; i++)
        {
            machinePosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10, 10), Random.Range(-10f, 10f));
            Instantiate(machine, machinePosition, Quaternion.identity);
        }
        Debug.Log("Finished");
    }
    // Use this for initialization
    void Start ()
    {

        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
    }
    
}
