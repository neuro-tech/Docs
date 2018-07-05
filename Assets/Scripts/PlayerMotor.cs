using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {
   
    [SerializeField]
    private Camera cam;

    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 tilt = Vector3.zero;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
      rb =  GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        PerformMovement();
        PerformRotation();
	}

    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void Rotate(Vector3 _rotation)
    {
        rotation = _rotation;
    }

    public void Tilt(Vector3 _tilt)
    {
        tilt = _tilt;
    }

    void PerformMovement()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam)
            cam.transform.Rotate(-tilt);
    }

}
