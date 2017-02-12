using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class GameManager : MonoBehaviour {

	[Header("Prefab links")]
	public	GameObject	CrystalPrefab;      //Assign Prefab here, must be an asset not be a scene object
	public	GameObject	RainPrefab;      //Assign Prefab here, must be an asset not be a scene object


    private PlayerController  mPlayerController;        //Static GM keeps referenced to Key Game Objects
    private TerrainController mTerrainController;

    private static	GameManager	GM;     //Internal link to GM instance used by static methods

    private List<TerrainObject>   mTerrainObjectList;		//List of objects in scene

	//Set up game manager singleton
	void Awake () {
		if (GM == null) {
			GM = this;
			DontDestroyOnLoad (gameObject);	//Keep it hanging around during scene change
            mTerrainObjectList = new List<TerrainObject>();     //Generic list of terrain objects
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

	public	static	int		ObjectCount {	//Get number of objects in list
		get {
			return	GM.mTerrainObjectList.Count;
		}
	}

	public  static	void	CreateRain() {
		Vector3 tPosition = TC.RandomPosition(PC.transform.position,30f);
		tPosition.y = Random.Range (10, 30);
		Instantiate (GM.RainPrefab, tPosition, Quaternion.identity);
	}


	public  static	void	CreateCrystal() {
        Vector3 tPosition = TC.RandomPosition(PC.transform.position,10f);
        Crystal mCrystal = TC.SpawnTerrainObject<Crystal>(tPosition, GM.CrystalPrefab);
       GM.mTerrainObjectList.Add(mCrystal);
        Debug.Log("Adding Terrain Object");
    }

    public  static	void	DeleteCrystal(TerrainObject vTO) {
        GM.mTerrainObjectList.Remove(vTO);
        Debug.Log("Deleting Terrain Object");
	}

    static  public  string  DebugText {         //Make up Debug text for display
        get {
            StringBuilder tBuilder = new StringBuilder();           //Much faster than string+string
            tBuilder.Append(string.Format("{0} Items\n", ObjectCount));
            foreach( TerrainObject tTO in GM.mTerrainObjectList) {
                tBuilder.Append(string.Format("{0}\n", tTO));
            }
            return tBuilder.ToString();
        }
    }

    // Update is called once per frame
    void Update () {
	
	}
}
