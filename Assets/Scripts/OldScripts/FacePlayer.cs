using UnityEngine;
using System.Collections;

public class FacePlayer : MonoBehaviour {

	Quaternion	mStartingRotation;		//Keep starting rotation
	Vector3		mStartingScale;			//Keep start

	void	Start() {
		mStartingRotation = transform.rotation;
		mStartingScale = transform.localScale;
	}


	//Undo Parent rotation
	void LateUpdate () {
		transform.rotation = mStartingRotation;
		transform.localScale = mStartingScale;
	}
}
