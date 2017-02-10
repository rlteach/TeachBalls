using UnityEngine;
using System.Collections;

public class TerrainController : MonoBehaviour {

	private	Terrain	mT;

	// Use this for initialization
	private	void Start () {
		mT = GetComponent<Terrain> ();
        GameManager.TC = this;      //Link myself to game Manager
        InvokeRepeating("NewItem", 0, 2f);
	}

    void OnDestroy() {
        GameManager.TC = null;          //Remove link when we die, should happen anyway but allows for cleanup
        Debug.Log("Terrain Controller Destroyed");
    }

    public Vector3 RandomPosition(Vector3 vPosition, float vDistance) {     //Get position at Random angle with a certain distance from the specified position
        Vector3 tSpawnPoint = Quaternion.Euler(0, Random.Range(0f, 360f), 0) * Vector3.forward * vDistance;		//Make forward vector, point it a random direction at a set Distance
        return tSpawnPoint + vPosition;
    }

    public	T	SpawnTerrainObject<T>(Vector3 vPosition,GameObject vGO) where T : Component {
        GameObject mGO = Instantiate<GameObject>(vGO);  //Make Up a game Object from given Prefab
        mGO.transform.position = vPosition;
        T mTO=mGO.AddComponent<T>();
            return	mTO;
	}

    public  Vector3   MoveToGround(Vector3 vPosition) {
        vPosition.y= mT.SampleHeight(vPosition);
        return vPosition;
    }

    void NewItem() {
        GameManager.CreateCrystal();
    }

}
