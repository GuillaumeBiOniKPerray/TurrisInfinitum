using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {

    public Transform camTarget;

    public float camSpeed;

    private float actualAngle;
    private float _delay;

    private bool _isRotating;

    void Start () {

        actualAngle = transform.rotation.eulerAngles.y;
        transform.LookAt(camTarget);
	}
	
	// Update is called once per frame
	void Update () {

        if (_isRotating)
        {
            CameraRotation();
            print("actualAngle: " + actualAngle);
            print("Y: " + transform.rotation.eulerAngles.y);
            _delay += Time.deltaTime;
            if (_delay >= .5f)
            {
                print("ROTATE");
                _isRotating = false;
                _delay = 0;
            }
        }

    }

    public void CameraRotation ()
    {
        Vector3 targetPos = camTarget.transform.position;
        transform.RotateAround(targetPos, new Vector3(0, 1, 0), -45 * Time.deltaTime * camSpeed);
    }

    public bool SetIsRotating (bool isRotating)
    {
        _isRotating = isRotating;
        return isRotating;
    }
}
