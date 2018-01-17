using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour {

    public GameObject mainCamera;
    public CamScript scriptCamera;


    public void OnTriggerEnter(Collider other) //Lorsque le joueur touche un "checkpoint", il tourne de -90° et la camera suit son mouvement
    {
        if (other.gameObject.tag == "Player")
        {
            other.transform.Rotate(0, -90, 0);
            scriptCamera.SetIsRotating(true);
        }
    }
}
