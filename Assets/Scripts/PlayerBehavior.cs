using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    public GameManager gameManager;
    public Swipe swipeControls;
    public float speed;
    public float jumpForce;
    public float jumpLenght;

    private bool _isGrounded = true;

    void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
	
	void Update () {

        if (gameManager.GetIsPlaying())
        {
            transform.Translate(-transform.forward * speed * Time.deltaTime);

            Jump();
            /*if (swipeControls.SwipeDown && _isGrounded)
            {
                transform.Translate(0, -2 * jumpforce * Time.deltaTime, -2 * speed * Time.deltaTime);
                _isGrounded = false;
            }*/
        }
       
    }

    void Jump()
    {
        if (swipeControls.SwipeUp && _isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpForce, -jumpLenght), ForceMode.Impulse);
            _isGrounded = false;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Ground")
        {
            _isGrounded = true;
        }
    }
}
