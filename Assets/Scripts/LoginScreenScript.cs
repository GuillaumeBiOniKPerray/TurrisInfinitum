using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginScreenScript : MonoBehaviour {

    public string playerName;

    public InputField textField;

    private GameManager gameManager;
    


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Find 
    }

    public void LaunchGame() //Cliquer sur "JOUER"
    {
        if (playerName == "")
        {
            textField.GetComponent<Image>().color = Color.red;
            //textField.GetComponent<Image>().color = Color.
            print("you must register your name first");
        }
        else
        {
            gameObject.SetActive(false);
            gameManager.SetIsPlaying(true);
            gameManager.playerNameText.text = playerName;
            print("Ur name is " + playerName);
        }
        
    }

    public void AddUserName ()
    {
        playerName = textField.text;
    }

}
