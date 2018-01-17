using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneScript : MonoBehaviour {

    
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other) //Mort du player lorsqu'il franchi cette zone
    {
        if(other.gameObject.tag == "Player")
        {
            GameOver();
        }
    }

    public void GameOver () // Apparition de l'écran GameOver
    {
        gameManager.SetIsPlaying(false);
        gameManager.GameOverPanel();
    }
}
