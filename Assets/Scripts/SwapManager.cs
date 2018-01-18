using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapManager : MonoBehaviour {

    public SceneCommunicationScript menuInfo;

    private int actualMoney;
    //public GameObject player;

    private void Start()
    {
        /*PlayerPrefs.DeleteKey("Jaune");
        PlayerPrefs.DeleteKey("Pink");
        PlayerPrefs.SetInt("Money", 30);*/
        actualMoney = PlayerPrefs.GetInt("Money");

        if (PlayerPrefs.GetInt("Jaune") != 1)
        {
            PlayerPrefs.SetInt("Jaune", 0);
            print("pas le skin jaune");
        }
        else
        {
            print("j'ai deja le skin jaune");
        }
    }

    public void BuyJaune(GameObject yellowPlayer)
	{
        if (PlayerPrefs.GetInt("Jaune") == 0 && PlayerPrefs.GetInt("Money")>= 30)
        {
            PlayerPrefs.SetInt("Jaune", 1);
            actualMoney -= 30;
            PlayerPrefs.SetInt("Money", actualMoney);
            print("j'ai le skin jaune");
            //menuInfo.UpdatePlayerPrefab(yellowPlayer);
        }
        else if (PlayerPrefs.GetInt("Jaune") == 0 && PlayerPrefs.GetInt("Money") < 30)
        {
            print("Je n'ai pas assez de pièces");
        }

        if(PlayerPrefs.GetInt("Jaune") == 1)
        {
            print("changement de skin pour " + yellowPlayer);
            //player = yellowPlayer;
            menuInfo.UpdatePlayerPrefab(yellowPlayer);
        }

	}

    public void BuyPink(GameObject pinkPlayer)
    {
        if (PlayerPrefs.GetInt("Pink") == 0 && PlayerPrefs.GetInt("Money") >= 30)
        {
            PlayerPrefs.SetInt("Pink", 1);
            actualMoney -= 30;
            PlayerPrefs.SetInt("Money", actualMoney);
            print("j'ai le skin rose");
        }
        else if (PlayerPrefs.GetInt("Pink") == 0 && PlayerPrefs.GetInt("Money") < 30)
        {
            print("Je n'ai pas assez de pièces");
        }

        if (PlayerPrefs.GetInt("Pink") == 1)
        {
            print("changement de skin pour " + pinkPlayer);
            //player = yellowPlayer;
            menuInfo.UpdatePlayerPrefab(pinkPlayer);
        }

    }
}
