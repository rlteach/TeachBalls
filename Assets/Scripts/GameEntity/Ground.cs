using 	UnityEngine;
using 	System.Collections;
using	System;

public class Ground : MonoBehaviour {

	Terrain	mTerrain;

	protected	virtual	void Start () {
		mTerrain = GetComponent<Terrain> ();	

	}

	public	virtual void MouseOver(Raycast.MouseClickMask vMouseClick,Vector3 vOffset) {
		if ((vMouseClick&Raycast.MouseClickMask.LeftMouse)==Raycast.MouseClickMask.LeftMouse) {
			GameHelper.DebugMsg (GetType () + ":Clicked on " + vMouseClick.ToString () + vOffset);
			Entity	tPlayer = GM.GetPlayer (0);
			if (tPlayer != null) {
				tPlayer.RB.MovePosition (vOffset);
			}
		}
	}
}
