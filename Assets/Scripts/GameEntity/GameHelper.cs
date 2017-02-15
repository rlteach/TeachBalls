using UnityEngine;
using System.Collections;

public class GameHelper : MonoBehaviour {

	public	static	bool	DebugOn=true;



	//Only send to debug if Debug is true
	public	static	void	DebugMsg(string vText) {
		if (DebugOn) {
			Debug.Log (vText);
		}
	}
}
