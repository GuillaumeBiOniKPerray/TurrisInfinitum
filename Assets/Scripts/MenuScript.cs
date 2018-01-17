using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public Text moneyAmount;

    private void Update()
    {
        moneyAmount.text = PlayerPrefs.GetInt("Money").ToString();

        if(PlayerPrefs.GetInt("Money")<1)
        {
            moneyAmount.text = 0.ToString();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

}
