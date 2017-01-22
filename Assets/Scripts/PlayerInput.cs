using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

	private Rigidbody2D _playerController;
	private ParticleSystem playerEngine;

    private float timeTillNextWave = 0;

	public float thrustVelocity = 5.0f;
	public float turnSpeed = 3.0f;
    public int secondsBetweenWaves = 1;
    public string turnControlAxis = "Horizontal";
    public string throttleControlAxis = "Vertical";
    public string fireWaveAxis = "Fire1";

    // Use this for initialization
    void Start () {
		_playerController = GetComponent<Rigidbody2D> ();
        GetComponent<PlayerData>().giveInitialVelocity();

	}

	void Awake() {
		playerEngine = GetComponentInChildren<ParticleSystem>();
		playerEngine.gameObject.SetActive (true);
		var eng = playerEngine.emission;
		eng.enabled = false;
	}

    private void Update() {
        timeTillNextWave = Mathf.Max(timeTillNextWave - Time.deltaTime, 0);
    }
	void FixedUpdate () {
		var eng = playerEngine.emission;
        _playerController.MoveRotation(_playerController.rotation - getTurnAxis() * turnSpeed);
        float axis = Input.GetAxisRaw(throttleControlAxis);

		if (axis != 0) {
			_playerController.AddRelativeForce (new Vector2 (0, thrustVelocity * axis));
			eng.enabled = true;

		} else {
			eng.enabled = false;
		}



        if(Input.GetAxisRaw(fireWaveAxis) != 0)
        {
            fireWave();
        }

	}

    private void fireWave()
    {
        if (timeTillNextWave == 0)
        {
            GravityWave gw = _playerController.gameObject.AddComponent<GravityWave>();
            gw.playerSource = _playerController;

            timeTillNextWave = secondsBetweenWaves;
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
            //Move ship off screen
            //Play explosion
            //Wait some time
            GetComponent<PlayerData>().respawnShip();
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        Rigidbody2D otherPlayer = other.GetComponentInParent<Rigidbody2D>();
        bool selfCreated = otherPlayer != null && _playerController.name == otherPlayer.name;
        if(!selfCreated)
        {
            //PUSH AWAY
            Vector2 otherPlayerPosition = otherPlayer.position;
            Vector2 playerPos = new Vector2(_playerController.transform.position.x, _playerController.transform.position.y);
            Vector2 gravity = otherPlayerPosition - playerPos;
            _playerController.AddForce(-gravity * 20);
        }
        Debug.Log(_playerController.name + "Collided with a particle created by " + other.GetComponentInParent<Rigidbody2D>().name);
        
    }
}