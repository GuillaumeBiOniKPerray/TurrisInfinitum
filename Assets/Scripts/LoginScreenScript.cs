using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginScreenScript : MonoBehaviour {

    /*public class newUser
    {
        public string name;
        public int index;

        public newUser (int id, string na)
        {
            index = id;
            name = na;
        }

    }*/

    List<string> userNames = new List<string> { "Fucus Antiqua" };

    public string playerName;

    //public newUser newGameUser;

    public InputField textField;

    public GameObject createNewUser;

    public Dropdown playerSelection;

    private int _playerindex = 0;

    private GameManager gameManager;
    


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Find GameManager
        playerName = userNames[0]; //Set DefaultName
        playerSelection.gameObject.SetActive(true);
        textField.gameObject.SetActive(false);
        createNewUser.SetActive(false);
        PopulateDropdownList();
    }

    public void LaunchGame() //Cliquer sur "JOUER"
    {
        gameObject.SetActive(false);
        gameManager.SetIsPlaying(true);
        //PlayerPrefs.SetString("1", playerName);
        gameManager.playerNameText.text = playerName;
        print("Ur name is " + playerName);
    }

    public void AddUserButton() //Cliquer sur "+"
    {
        textField.gameObject.SetActive(true);
        createNewUser.SetActive(true);
        playerSelection.gameObject.SetActive(false);
    }

    public void CreateNewUser() // Cliquer sur "Créer"
    {
        playerName = textField.text;
        userNames.Add(playerName);
        playerSelection.ClearOptions();
        playerSelection.AddOptions(userNames);
        _playerindex++;
        gameManager.playerNameText.text = playerName;
        //print(_playerindex);
        //PlayerPrefs.SetString(playerName, playerName);
        //newGameUser = new newUser(_playerindex, playerName);
        playerSelection.gameObject.SetActive(true);
        createNewUser.SetActive(false);
        textField.gameObject.SetActive(false);
    }

    void PopulateDropdownList()
    {
        playerSelection.AddOptions(userNames);
    }

}
