using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

	private Rigidbody2D _playerController;

	// Use this for initialization
	void Start () {
		_playerController = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 gravityWell = new Vector2 (0, 0);
		Vector2 playerPos = new Vector2 (_playerController.transform.position.x, _playerController.transform.position.y);
		Vector2 gravity = gravityWell - playerPos;
		_playerController.AddForce (gravity);
	}
}
