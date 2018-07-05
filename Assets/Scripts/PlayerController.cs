using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
    
    [SerializeField]
    float speed = 5f;

    [SerializeField]
    float rotationSpeed = 3f;

    PlayerMotor motor;

	// Use this for initialization
	void Start () {
       motor = GetComponent<PlayerMotor>();
    }
	
	// Update is called once per frame
	void Update () {

            
        
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");
        Vector3 xMovement = transform.right * xMov;
        Vector3 zMovement = transform.forward * zMov;

        Vector3 velocity = (xMovement + zMovement).normalized * speed;
        motor.Move(velocity);

        Vector3 rotVelocity = new Vector3(0, Input.GetAxisRaw("Mouse X"), 0)*rotationSpeed;
        motor.Rotate(rotVelocity);

        Vector3 tiltVelocity = new Vector3(Input.GetAxisRaw("Mouse Y"), 0, 0)*rotationSpeed;
        motor.Tilt(tiltVelocity);

	}
}
