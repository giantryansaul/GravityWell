#pragma strict
 
//http://answers.unity3d.com/questions/463704/smooth-orbit-round-object-with-adjustable-orbit-ra.html

var objectToOrbit : Transform; //Object To Orbit
var orbitAxis : Vector3 = Vector3.left; //Which vector to use for Orbit
var orbitRadius : float = 7.0; //Orbit Radius
var orbitRadiusCorrectionSpeed : float = 2.0; //How quickly the object moves to new position
var orbitRoationSpeed : float = 50.0; //Speed Of Rotation arround object
var orbitAlignToDirectionSpeed : float = 0.2; //Realign speed to direction of travel
 
private var orbitDesiredPosition : Vector3;
private var previousPosition : Vector3;
private var relativePos : Vector3;
private var rotation : Quaternion;
private var thisTransform : Transform;
 
//---------------------------------------------------------------------------------------------------------------------
 
function Start() {    
    thisTransform = transform;
}
 
//---------------------------------------------------------------------------------------------------------------------
 
function Update() {
    //Movement
    thisTransform.RotateAround (objectToOrbit.position, orbitAxis, orbitRoationSpeed * Time.deltaTime);
    orbitDesiredPosition = (thisTransform.position - objectToOrbit.position).normalized * orbitRadius + objectToOrbit.position;
    thisTransform.position = Vector3.Slerp(thisTransform.position, orbitDesiredPosition, Time.deltaTime * orbitRadiusCorrectionSpeed);
}