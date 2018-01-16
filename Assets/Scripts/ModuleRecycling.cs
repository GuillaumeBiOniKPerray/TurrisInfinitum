using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleRecycling : MonoBehaviour {

    public GameManager gameManager;

    private void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag =="Recycle")
        {
            print("RECYCLE");
            gameManager.SpawnNewModule(other.transform.parent.gameObject);
        }
    }
}
