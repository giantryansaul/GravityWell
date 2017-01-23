﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

public Transform objectToOrbit; //Object To Orbit
public Vector3 orbitAxis = Vector3.forward; //Which vector to use for Orbit
public float orbitRadius = 7.0f; //Orbit Radius
public float orbitRadiusCorrectionSpeed = 2.0f; //How quickly the object moves to new position
public float orbitRoationSpeed = 50.0f; //Speed Of Rotation arround object
public float orbitAlignToDirectionSpeed = 0.2f; //Realign speed to direction of travel
 
private Vector3 orbitDesiredPosition;
private Vector3 previousPosition;
private Vector3 relativePos;
private Quaternion rotation;
private Transform thisTransform;
 

	// Use this for initialization
	void Start () {
        thisTransform = transform;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //PlayerInput input = GetComponent<PlayerInput>();
        
        thisTransform.RotateAround(objectToOrbit.position, orbitAxis, orbitRoationSpeed * Time.deltaTime);      
        orbitDesiredPosition = (thisTransform.position - objectToOrbit.position).normalized * orbitRadius + objectToOrbit.position;
        //if (!input || input.getTurnAxis() == 0)
        //{
        thisTransform.position = Vector3.Slerp(thisTransform.position, orbitDesiredPosition, Time.deltaTime * orbitRadiusCorrectionSpeed);
        //}
    }

}
