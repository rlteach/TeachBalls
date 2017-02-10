using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[Header("Prefab links")]
	public	GameObject	CrystalPrefab;		//Assign Prefab here, must be an asset not be a scene object


	private	static	GameManager	GM;

	//Set up game manager singleton
	void Awake () {
		if (GM == null) {
			GM = this;
			DontDestroyOnLoad (gameObject);	//Keep it hanging around during scene change
		} else if (GM != this) {		//Only allow one per game
			Destroy (gameObject);		//if duplicate kill it
		}
	}

	static	void	CreateCrystal() {
	}

	static	void	DeleteCrystal() {
	}

	// Update is called once per frame
	void Update () {
	
	}
}
