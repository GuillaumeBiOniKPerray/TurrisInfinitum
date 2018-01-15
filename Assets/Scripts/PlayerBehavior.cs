using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    public Swipe swipeControls;
    public float speed;
    public float jumpforce;

    private bool _isGrounded = true;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(-transform.forward * speed *Time.deltaTime);

        if (swipeControls.SwipeUp && _isGrounded)
        {
            print("JUMP");
            transform.Translate(0, 2 *jumpforce * Time.deltaTime ,-2 * speed * Time.deltaTime);
            _isGrounded = false;
        }

        if (swipeControls.SwipeDown && _isGrounded)
        {
            print("Crouch");
            transform.Translate(0, -2 * jumpforce * Time.deltaTime, -2 * speed * Time.deltaTime);
            _isGrounded = false;
        }

    }

    void Jump()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Ground")
        {
            _isGrounded = true;
        }
    }
}
