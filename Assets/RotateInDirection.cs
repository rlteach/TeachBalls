using UnityEngine;
using System.Collections;

public class RotateInDirection : MonoBehaviour {

	Vector3	mLastPosition;
	// Use this for initialization
	void Start () {
		mLastPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3	tVelocity = transform.position - mLastPosition;
		mLastPosition = transform.position;
		transform.rotation *= Quaternion.Euler (tVelocity.magnitude*Time.deltaTime*3600f, 0, 0);
	}
}
