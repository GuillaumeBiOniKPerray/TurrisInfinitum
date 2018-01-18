using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPlayer : MonoBehaviour {

	public Swipe swipeControls;

	public float speed;
	public float jumpForce;
	public float jumpLenght;

	private bool _isGrounded = true;

	void Update () 
	{

			transform.Translate(transform.InverseTransformDirection(transform.forward) * speed * Time.deltaTime);
			Jump();
			/*if (swipeControls.SwipeDown && _isGrounded)
            {
                transform.Translate(0, -2 * jumpforce * Time.deltaTime, -2 * speed * Time.deltaTime);
                _isGrounded = false;
            }*/

	}

	void Jump() // Fonction de saut régler sur le swipe vers le haut (ou click and drag avec la souris)
	{
		if (swipeControls.SwipeUp && _isGrounded)
		{
			GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, -jumpLenght), ForceMode.Impulse);
			_isGrounded = false;
			GetComponent<Rigidbody>().useGravity = true;
		}
	}

	private void OnCollisionEnter(Collision collision) //Fonction vérifiant que le joueur soit sur le sol (empêche le double saut)
	{
		if(collision.gameObject.tag =="Ground")
		{
			_isGrounded = true;
		}
	}
}
