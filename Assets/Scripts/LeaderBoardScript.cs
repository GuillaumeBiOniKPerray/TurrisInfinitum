using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoardScript : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject scoreTable;

    public List<LeaderBoardLine> Lines;

    [System.Serializable]
    public class LeaderBoardLine
    {
        int score;
        string name;
    }

    public void AddScore(string name, int score)
    {
        int newScore;
        string newName;
        int oldScore;
        string oldName;

        newScore = score;
        newName = name;

        for (int i = 0; i < 5; ++i)
        {
            if (PlayerPrefs.HasKey(i + "HScore"))
            {
                if (PlayerPrefs.GetInt(i + "HScore") < newScore)
                {
                    oldScore = PlayerPrefs.GetInt(i + "HScore");
                    oldName = PlayerPrefs.GetString(i + "HScoreName");
                    PlayerPrefs.SetInt(i + "HScore", newScore);
                    PlayerPrefs.SetString(i + "HScoreName", newName);
                    newScore = oldScore;
                    newName = oldName;
                }
                
            }
            else
            {
                PlayerPrefs.SetInt(i + "HScore", newScore);
                PlayerPrefs.SetString(i + "HScoreName", newName);
                newScore = 0;
                newName = "";
            }
            print("PlayerName: " + PlayerPrefs.GetString(i + "HScoreName"));
            print("PlayerScore: " + PlayerPrefs.GetInt(i + "HScore"));
        }

        
    }

    private void Start()
    {

        //AddScore(gameManager.playerNameText.text, gameManager.GetPlayerScore());

        for (int i=0; i < 5; i++)
        {
            GameObject sb = (GameObject)Instantiate(scoreTable);
            sb.transform.SetParent(this.transform);
        }
    }

    /*public void TableContent()
    {

        string actualFirst = PlayerPrefs.GetString("1");
        string actualSecond = PlayerPrefs.GetString("2");
        string actualThird = PlayerPrefs.GetString("3");

        int playerScore = PlayerPrefs.GetInt(gameManager.playerNameText.text);

        if (actualFirst == null)
        {
            PlayerPrefs.SetInt(gameManager.playerNameText.text, gameManager.GetPlayerScore());
        }
        else
        {
            if(PlayerPrefs.GetInt(gameManager.playerNameText.text) > PlayerPrefs.GetInt(actualFirst))
            {
                
            }
        }

        if (actualSecond == null)
        {
            PlayerPrefs.SetInt(gameManager.playerNameText.text, gameManager.GetPlayerScore());
        }

        if (actualThird == null)
        {
            PlayerPrefs.SetInt(gameManager.playerNameText.text, gameManager.GetPlayerScore());
        }

    }*/
}
