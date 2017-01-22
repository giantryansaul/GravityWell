using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public Vector2 defaultSpawn = new Vector2(-5, 0);
    private Rigidbody2D player;

	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void respawnShip() {
        transform.position = defaultSpawn;
        player.velocity = Vector3.zero;
        player.angularVelocity = 0;
    }
}
