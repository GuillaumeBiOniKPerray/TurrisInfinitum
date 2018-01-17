using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapManager : MonoBehaviour {



	public void BuyJaune()
	{
		PlayerPrefs.SetInt ("Jaune", 1);
		print ("j'ai le skin jaune");
	}

	private void Start()
	{
		if (PlayerPrefs.GetInt ("Jaune") != 1) 
		{
			PlayerPrefs.SetInt ("Jaune", 0);
			print ("pas le skin jaune");
		} 
		else 
		{
			print ("j'ai deja le skin jaune");
		}
	}
}
