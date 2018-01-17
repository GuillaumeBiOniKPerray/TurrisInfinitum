using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour {

    public Transform camTarget;

    public float camSpeed; //Vitesse de rotation de la caméra

    private float actualAngle;
    private float _delay;

    private bool _isRotating;

    void Start () {

        actualAngle = transform.rotation.eulerAngles.y;
        transform.LookAt(camTarget);
	}
	
	void Update () {

        if (_isRotating) 
        {
            CameraRotation();
            _delay += Time.deltaTime;
            if (_delay >= .5f)
            {
                _isRotating = false;
                _delay = 0;
            }
        }

    }

    public void CameraRotation () //Fonction de rotation de la camera
    {
        Vector3 targetPos = camTarget.transform.position;
        transform.RotateAround(targetPos, new Vector3(0, 1, 0), -45 * Time.deltaTime * camSpeed);
    }

    public bool SetIsRotating (bool isRotating) //SETTER
    {
        _isRotating = isRotating;
        return isRotating;
    }
}
