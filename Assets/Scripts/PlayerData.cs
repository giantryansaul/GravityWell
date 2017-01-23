﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour {

	public string playerDisplay;

	public Text livesText;

    public Vector2 defaultSpawn = new Vector2(-5, 0);
 
    private Rigidbody2D player;

    private int numLivesRemaining;

	private Quaternion initialRotation;

	// Use this for initialization
	void Start () {
        numLivesRemaining = GameManager.instance.numLivesPerGame;
        player = GetComponent<Rigidbody2D>();

		initialRotation = player.transform.rotation;

		livesText.text = numLivesRemaining.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void playerDied() {
        numLivesRemaining--;
		livesText.text = numLivesRemaining.ToString();

        ExplosionWave ew = player.gameObject.AddComponent<ExplosionWave>();
        ew.playerSource = player;

        player.GetComponent<SpriteRenderer>().enabled = false;

        if (numLivesRemaining == 0)
        {
			GameManager.instance.GameOver (this);
        }
        else if (numLivesRemaining > 0)
		{
            StartCoroutine(hideAndWaitAndRespawn());
        }
    }

    private IEnumerator hideAndWaitAndRespawn()
    {
        yield return new WaitForSecondsRealtime(GameManager.instance.repsawnTimeInSeconds);
        player.GetComponent<SpriteRenderer>().enabled = true;
        respawnShip();
    }

    public void respawnShip()
    {
        transform.position = defaultSpawn;
        player.velocity = Vector3.zero;
        player.angularVelocity = 0;
        player.transform.rotation = initialRotation;
        giveInitialVelocity();
    }

    public void giveInitialVelocity()
    {
        player.AddRelativeForce(new Vector2(0, 1) * 200);
    }

    public bool playerIsAlive()
    {
        return numLivesRemaining > 0;
    }
}
