using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[Header("Prefab links")]
	public	GameObject	CrystalPrefab;      //Assign Prefab here, must be an asset not be a scene object


    private PlayerController  mPlayerController;        //Static GM keeps referenced to Key Game Objects
    private TerrainController mTerrainController;

    private static	GameManager	GM;     //Internal link to GM instance used by static methods

	//Set up game manager singleton
	void Awake () {
		if (GM == null) {
			GM = this;
			DontDestroyOnLoad (gameObject);	//Keep it hanging around during scene change
		} else if (GM != this) {		//Only allow one per game
			Destroy (gameObject);		//if duplicate kill it
		}
	}

    public  static PlayerController PC {            //Set the player controller, so it can access by all
        get {
            return GM.mPlayerController;
        }
        set {
            GM.mPlayerController = value;
        }
    }

    public static TerrainController TC {       //Allow terrain controller object set/get
        get {
            return GM.mTerrainController;
        }

        set {
            GM.mTerrainController = value;
        }
    }  

	public  static	void	CreateCrystal() {
        Vector3 tPosition = TC.RandomPosition(PC.transform.position,10f);
        Crystal mCrystal = TC.SpawnTerrainObject<Crystal>(tPosition, GM.CrystalPrefab);
	}

	public  static	void	DeleteCrystal() {
	}



    // Update is called once per frame
    void Update () {
	
	}
}
