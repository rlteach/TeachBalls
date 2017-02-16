using UnityEngine;
using System.Collections;
using System;

public class Entity : MonoBehaviour {


	private		float mHoverHeight=1f;

	private		Vector3	mDestination;

	public		Vector3	Destination {
		set {
			Destination = value;
		}
	}

	private		Rigidbody	mRB;

	public	Rigidbody RB {
		get {
			return	mRB;
		}
	}

	protected	float HoverHeight {
		set {
			mHoverHeight=value;
		}
		get {
			return	mHoverHeight;
		}
	}


	//Assign RigidBody
	protected	virtual	void Start () {
		mRB = GetComponent<Rigidbody> ();
		if (mRB == null) {
			throw new System.ArgumentException(GetType().Name+":Parameter cannot be null", "RigidBody");
		}
		GM.AddPlayer (this);
	}


	protected	virtual	void	Kill() {
		GM.RemovePlayer (this);
	}

	void	OnDestroy() {
		Kill ();
	}

	void	Update() {
	}

	void FixedUpdate () {
		Hover ();
	}

	void	Hover() {
		RaycastHit	tHit;
		if (Physics.Raycast (transform.position, Vector3.down, out tHit,mHoverHeight)) {
			if (tHit.collider.tag == "Terrain") {
				float tHeight = tHit.distance;
				Vector3	tVelocity = mRB.velocity;
				tVelocity.y = Mathf.Max(tVelocity.y,0f);
				mRB.velocity = tVelocity;
				mRB.AddForce (Vector3.up*(-Physics.gravity.y/tHeight));
			}
		}
	}

	void OnCollisionEnter(Collision vCol) {
		
	}

	public	virtual void MouseOver(Raycast.MouseClickMask vMouseClick,Vector3 vOffset) {
		if ((vMouseClick&Raycast.MouseClickMask.LeftMouse)==Raycast.MouseClickMask.LeftMouse) {
			GameHelper.DebugMsg (GetType () + ":ClickOn " + vMouseClick.ToString ());
		}
	}

}
