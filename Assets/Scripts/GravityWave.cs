using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWave : MonoBehaviour {

    public Rigidbody2D playerSource;

    public GameObject gravityWaveObj;

	// Use this for initialization
	void Start () {
        GameObject gravityWaveObjPrefab = (GameObject) Resources.Load("GravityWaveObject");
        gravityWaveObj = Instantiate(gravityWaveObjPrefab, playerSource.position, Quaternion.identity, playerSource.transform);
    }
	
	// Update is called once per frame
	void Update () {
        if (gravityWaveObj != null)
        {
            ParticleSystem ps = gravityWaveObj.GetComponent<ParticleSystem>();
            if(ps != null && !ps.IsAlive())
            {
                Destroy(gravityWaveObj);
            }
        }
	}

}
