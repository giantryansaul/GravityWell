using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;

    public int numLivesPerGame = 5;
    public int repsawnTimeInSeconds = 1; 

	public Text gameOverText;

	void Start() {
		gameOverText.text = "";
	}

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

	public void GameOver(PlayerData loser) {

		GameObject[] players = GameObject.FindGameObjectsWithTag ("Player");

		foreach (GameObject player in players) {
			PlayerData playerData = player.GetComponent<PlayerData> ();
			if (playerData != null && playerData != loser) {
				gameOverText.text = "Game Over\n" + playerData.playerDisplay + " is the winner";
				break;
			}
		}

		Time.timeScale = 0;

	}

	public void ResetGame() {
		gameOverText.text = "";
	}
}
