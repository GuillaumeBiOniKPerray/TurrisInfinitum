using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins_Script : MonoBehaviour 
{
	void OnTriggerEnter(Collider player)
	{
		if (player.gameObject.tag == "Player") 
		{
			int i = PlayerPrefs.GetInt ("Money");
			i++;
			PlayerPrefs.SetInt ("Money", i);
			Destroy (gameObject);
		}
	}
}
