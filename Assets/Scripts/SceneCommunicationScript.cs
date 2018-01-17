using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneCommunicationScript : MonoBehaviour {

    public GameObject player;

    private void Start()
    {
        DontDestroyOnLoad(gameObject); // Empeche ce script d'être détruit entre les scènes
        //UpdatePlayerPrefab();
    }

    public void UpdatePlayerPrefab(GameObject newPlayerColor)
    {
        player = newPlayerColor;
    }
}
