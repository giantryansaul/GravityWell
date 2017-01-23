using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionWave : MonoBehaviour
{

    public Rigidbody2D playerSource;

    public GameObject explosionWaveObj;

    // Use this for initialization
    void Start()
    {
        GameObject explosionWaveObjPrefab = (GameObject)Resources.Load("ExplosionWaveObject");
        explosionWaveObj = Instantiate(explosionWaveObjPrefab, playerSource.position, Quaternion.identity, playerSource.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (explosionWaveObj != null)
        {
            ParticleSystem ps = explosionWaveObj.GetComponent<ParticleSystem>();
            if (ps != null && !ps.IsAlive())
            {
                Destroy(explosionWaveObj);
            }
        }
    }

}
