using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCommunicationScript : MonoBehaviour {

    public GameObject player;
	public static SceneCommunicationScript intance;


    private void Start()
    {
		if (intance == null) {
			intance = this;
			DontDestroyOnLoad (gameObject); // Empeche ce script d'être détruit entre les scènes
			//UpdatePlayerPrefab();
		} 
		else 
		{
			Destroy (gameObject);
		}

    }
		

    public void UpdatePlayerPrefab(GameObject newPlayerColor)
    {
        player = newPlayerColor;
    }
		
}
