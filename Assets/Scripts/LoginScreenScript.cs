using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginScreenScript : MonoBehaviour {

    public class newUser
    {
        public string name;
        public int index;

        public newUser (int id, string na)
        {
            index = id;
            name = na;
        }

    }

    List<string> userNames = new List<string> { "Fucus Antiqua" };

    public newUser newGameUser;

    public InputField textField;

    public GameObject createNewUser;

    public Dropdown playerSelection;

    private int _playerindex = 0;

    private string _playerName;

    private GameManager gameManager;
    


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerSelection.gameObject.SetActive(true);
        textField.gameObject.SetActive(false);
        createNewUser.SetActive(false);
        PopulateDropdownList();
    }

    public void LaunchGame() //Cliquer sur "JOUER"
    {
        gameObject.SetActive(false);
        gameManager.SetIsPlaying(true);
        PlayerPrefs.SetString("1", _playerName);
    }

    public void AddUserButton() //Cliquer sur "+"
    {
        textField.gameObject.SetActive(true);
        createNewUser.SetActive(true);
        playerSelection.gameObject.SetActive(false);
    }

    public void CreateNewUser() // Cliquer sur "Créer"
    {
        _playerName = textField.text;
        userNames.Add(_playerName);
        print("Ur name is " + _playerName);
        playerSelection.ClearOptions();
        playerSelection.AddOptions(userNames);
        _playerindex++;
        print(_playerindex);
        PlayerPrefs.SetString(_playerindex.ToString(), _playerName);
        newGameUser = new newUser(_playerindex, _playerName);
        playerSelection.gameObject.SetActive(true);
        createNewUser.SetActive(false);
        textField.gameObject.SetActive(false);
    }

    void PopulateDropdownList()
    {
        playerSelection.AddOptions(userNames);
    }

}
