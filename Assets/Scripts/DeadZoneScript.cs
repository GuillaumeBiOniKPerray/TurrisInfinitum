using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZoneScript : MonoBehaviour {

    public GameObject player;
    public GameManager gameManager;

    private int _offset = 10;

    private void Start()
    {
        player = gameManager.player;
    }

    private void Update()
    {
        /*print("playerpos: " + player.transform.position.y);
        print("deadzonepos: " + transform.position.y);*/

        if (player.transform.position.y > transform.position.y)
        {
            enabled = true;
            transform.position = new Vector3(transform.position.x, player.transform.position.y-_offset, transform.position.z);
        }
        else
        {
            enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag =="Player")
        {
            gameManager.SetIsPlaying(false);
            gameManager.GameOverPanel();
        }
    }
}
