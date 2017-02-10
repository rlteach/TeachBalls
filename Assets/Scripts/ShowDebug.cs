//Code (C) 2017 Richard Leinfellner
//Permission given to use for educational use

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowDebug : MonoBehaviour {

    Text mText;

    void Start () {
        mText = GetComponent<Text>();        	
	}
	
	//Example of how to read the input from central manager
	void Update () {
        mText.text = GameManager.DebugText;
    }
}
