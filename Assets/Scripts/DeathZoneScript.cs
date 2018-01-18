using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneScript : MonoBehaviour {

    
    public GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update() //Right Click to kill (Testing Purposes)
    {
        if(Input.GetMouseButtonUp(1))
        {
            GameOver();
        }
    }

    private void OnTriggerEnter(Collider other) //Mort du player lorsqu'il franchi cette zone
    {
        if(other.gameObject.tag == "Player")
        {
            GameOver();
            other.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            other.GetComponent<MeshRenderer>().enabled = false;
            other.transform.GetChild(1).GetComponent<ParticleSystem>().Stop();
        }
    }

    public void GameOver () // Apparition de l'écran GameOver
    {
        gameManager.SetIsPlaying(false);
        gameManager.GameOverPanel();
    }
}
