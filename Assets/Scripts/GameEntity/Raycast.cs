using UnityEngine;
using System.Collections;
using System;

public class Raycast : MonoBehaviour {

	[Flags]
	public	enum MouseClickMask {
		NoClick=0
		,LeftMouse=(1<<0)
		,RightMouse=(1<<1)
		,MiddleMouse=(1<<2)
	}

	readonly	static	MouseClickMask[]	mMouseButtons = { MouseClickMask.LeftMouse, MouseClickMask.MiddleMouse, MouseClickMask.RightMouse };	

	void Update () {
		Ray tRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit	tHit;
		float	tLength=10f;
		if (Physics.Raycast (tRay,out tHit,tLength)) {
			MouseClickMask	tMouseButtons = GetButtons;
			Debug.DrawLine (tRay.origin, tRay.origin+tRay.direction*tHit.distance, Color.red, 1f);
			GameObject tGO=tHit.collider.gameObject;
			Entity	tEntity = tGO.GetComponent<Entity> ();
			if (tEntity != null) {
				tEntity.MouseOver (tMouseButtons,tHit.point);
			}
			Ground	tGround = tGO.GetComponent<Ground> ();
			if (tGround != null) {
				tGround.MouseOver (tMouseButtons,tHit.point);
			}
		}
	}

	private	MouseClickMask	GetButtons {
		get	{
			MouseClickMask	tMouseclick = MouseClickMask.NoClick;
			for (int tI = 0; tI < mMouseButtons.Length; tI++) {
				if (Input.GetMouseButton (tI))
					tMouseclick |= mMouseButtons [tI];
			}
			return	tMouseclick;
		}
	}
}
