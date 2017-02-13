using UnityEngine;
using System.Collections;

public class UnParent : MonoBehaviour {


	public	bool	Scale=true;	
	public	bool	Rotate=true;	

	Vector3		mScale;
	Quaternion	mRotation;

	void	Start() {
		mRotation = transform.localRotation;
		mScale = transform.localScale;
	}

	//Remove parental scale & rotation
	void LateUpdate () {
		if(Rotate)
			transform.localRotation=mRotation;
		if(Scale)
			transform.localScale=mScale;
	}
}
