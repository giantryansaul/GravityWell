using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	private Rigidbody2D _playerController;
	public float thrustVelocity = 5.0f;
	public float turnSpeed = 2.0f;

	// Use this for initialization
	void Start () {
		_playerController = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (0, 0, - Input.GetAxis ("Horizontal") * turnSpeed);

		if (Input.GetAxisRaw ("Jump") != 0) {
			_playerController.AddRelativeForce (new Vector2 (0, thrustVelocity));
		}
	}
}
