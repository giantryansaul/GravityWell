using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWave : MonoBehaviour {

    public Rigidbody2D playerSource;

    public GameObject gravityWaveObj;

	// Use this for initialization
	void Start () {
        Debug.Log("New wave.wav");
        GameObject gravityWaveObjPrefab = (GameObject) Resources.Load("GravityWaveObject");
        gravityWaveObj = Instantiate(gravityWaveObjPrefab, playerSource.position, Quaternion.identity);
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
