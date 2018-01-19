using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapManager : MonoBehaviour {

	public SceneCommunicationScript menuInfo;

	private int actualMoney;
	public GameObject yellowlocker;
	public GameObject yellowunlocker;
	public GameObject pinklocker;
	public GameObject pinkunlocker;
	public GameObject menuPerso;
	public Material mat_Pink;
	public Material mat_Yellow;
	//public GameObject player;

	private void Start()
	{
		//PlayerPrefs.DeleteKey("Jaune");
		//PlayerPrefs.DeleteKey("Pink");
		PlayerPrefs.SetInt("Money", 60);
		actualMoney = PlayerPrefs.GetInt("Money");
		BuyingChecks();
	}

	public void BuyJaune(GameObject yellowPlayer)
	{
		if (PlayerPrefs.GetInt("Jaune") == 0 && PlayerPrefs.GetInt("Money")>= 30)
		{
			PlayerPrefs.SetInt("Jaune", 1);
			actualMoney -= 30;
			PlayerPrefs.SetInt("Money", actualMoney);
			print("j'ai le skin jaune");
			yellowlocker.SetActive(false);
			yellowunlocker.SetActive (true);

			//menuInfo.UpdatePlayerPrefab(yellowPlayer);
		}
		else if (PlayerPrefs.GetInt("Jaune") == 0 && PlayerPrefs.GetInt("Money") < 30)
		{
			print("Je n'ai pas assez de pièces");
		}

		if(PlayerPrefs.GetInt("Jaune") == 1)
		{
			yellowlocker.SetActive(false);
			yellowunlocker.SetActive (true);

			menuPerso.GetComponent<Renderer>().material = mat_Yellow;
			print("changement de skin pour " + yellowPlayer);
			//player = yellowPlayer;
			SceneCommunicationScript.intance.UpdatePlayerPrefab(yellowPlayer);
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
			pinklocker.SetActive(false);
			pinkunlocker.SetActive (true);
		}
		else if (PlayerPrefs.GetInt("Pink") == 0 && PlayerPrefs.GetInt("Money") < 30)
		{
			print("Je n'ai pas assez de pièces");
		}

		if (PlayerPrefs.GetInt("Pink") == 1)
		{
			//player = yellowPlayer;
			menuPerso.GetComponent<Renderer>().material = mat_Pink;
			SceneCommunicationScript.intance.UpdatePlayerPrefab(pinkPlayer);
			print("changement de skin pour " + pinkPlayer);
			pinklocker.SetActive(false);
			pinkunlocker.SetActive (true);
		}

	}

	public void BuyingChecks()
	{

		if (PlayerPrefs.GetInt("Jaune") != 1)
		{
			PlayerPrefs.SetInt("Jaune", 0);
			print("pas le skin jaune");
			yellowlocker.SetActive(true);
			yellowunlocker.SetActive(false);
		}
		else
		{
			print("j'ai deja le skin jaune");
			yellowlocker.SetActive(false);
			yellowunlocker.SetActive(true);
		}

		if (PlayerPrefs.GetInt("Pink") != 1)
		{
			PlayerPrefs.SetInt("Pink", 0);
			print("pas le skin jaune");
			pinklocker.SetActive(true);
			pinkunlocker.SetActive(false);
		}
		else
		{
			print("j'ai deja le skin pink");
			pinklocker.SetActive(false);
			pinkunlocker.SetActive(true);
		}

	}
}