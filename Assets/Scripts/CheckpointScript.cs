using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour {

    public GameObject mainCamera;
    public CamScript scriptCamera;

    //public bool _isRotating;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.Rotate(0, -45, 0);
            //mainCamera.transform.position = Vector3.Lerp
            scriptCamera.SetIsRotating(true);
        }
    }
}
