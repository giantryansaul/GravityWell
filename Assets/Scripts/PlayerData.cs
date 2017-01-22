using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    public Vector2 defaultSpawn = new Vector2(-5, 0);
 
    private Rigidbody2D player;

    private int numLivesRemaining;

	// Use this for initialization
	void Start () {
        numLivesRemaining = GameManager.instance.numLivesPerGame;
        player = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void respawnShip() {
        numLivesRemaining--;
        if (numLivesRemaining == 0)
        {
            Debug.Log(player.name+": YOU DEAD SON");
            transform.position = new Vector2(1000, 1000);
        }
        else if (numLivesRemaining > 0)
        {
            transform.position = defaultSpawn;
            player.velocity = Vector3.zero;
            player.angularVelocity = 0;
            giveInitialVelocity();
            Debug.Log(player.name + " lives remaining: " + numLivesRemaining);
        }
    }

    public void giveInitialVelocity()
    {
        GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, 1) * 200);
    }

    public bool playerIsAlive()
    {
        return numLivesRemaining > 0;
    }
}
