using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	private Rigidbody2D _playerController;
	public float thrustVelocity = 5.0f;
	public float turnSpeed = 3.0f;
    public string turnControlAxis = "Horizontal";
    public string throttleControlAxis = "Vertical";
    public string fireWaveAxis = "Fire1";

    // Use this for initialization
    void Start () {
		_playerController = GetComponent<Rigidbody2D> ();
        GetComponent<PlayerData>().giveInitialVelocity();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (0, 0, -getTurnAxis() * turnSpeed);
        float axis = Input.GetAxisRaw(throttleControlAxis);

        if (axis != 0) {
			_playerController.AddRelativeForce (new Vector2 (0, thrustVelocity * axis));
		}

        if(Input.GetAxisRaw(fireWaveAxis) != 0)
        {
            GravityWave gw = _playerController.gameObject.AddComponent<GravityWave>();
            gw.playerSource = _playerController;
  
        }

	}

    public float getTurnAxis()
    {
        return Input.GetAxis(turnControlAxis);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "GravityWell")
        {
            GetComponent<PlayerData>().respawnShip();
        }
    }
}
