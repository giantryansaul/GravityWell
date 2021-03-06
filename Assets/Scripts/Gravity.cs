﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

	private Rigidbody2D _playerController;
    private PlayerData playerData;

    public Transform orbitObject;
	public float gravityForce = 0.2f;

	// Use this for initialization
	void Start () {
		_playerController = GetComponent<Rigidbody2D> ();
        playerData = GetComponent<PlayerData>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if(!playerData.playerIsAlive())
        {
            return;
        }

		Vector2 gravityWell = orbitObject == null ? new Vector2 (0, 0) : new Vector2(orbitObject.position.x, orbitObject.position.y);
		Vector2 playerPos = new Vector2 (_playerController.transform.position.x, _playerController.transform.position.y);
		Vector2 gravity = gravityWell - playerPos;
		_playerController.AddForce (gravity * gravityForce );
    }
}
