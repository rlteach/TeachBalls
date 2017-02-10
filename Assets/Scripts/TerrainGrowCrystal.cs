using UnityEngine;
using System.Collections;

public class TerrainGrowCrystal : MonoBehaviour {

	[Header("Links GO's")]
	public	GameObject	Player;
	public	GameObject	CrystalPrefab;

	private	Terrain	mT;

	// Use this for initialization
	private	void Start () {
		mT = GetComponent<Terrain> ();
	}

	public	Vector3	RandomPosition(float vDistance) {		//Get position at Random angle with a certain distance from the player
		Vector3	tSpawnPoint = Quaternion.Euler (0, Random.Range (0f, 360f), 0) * Vector3.forward*vDistance;		//Make forward vector, point it a random direction at a set Distance
		tSpawnPoint.y = mT.SampleHeight (tSpawnPoint);		//Fix up Y to sit on terrain
		return	tSpawnPoint;
	}

	public	<T>	SpawnCrystal<Time>(Vector3 vPosition) {
		GameObject	mGO = Instantiate (CrystalPrefab,vPosition,Quaternion.identity);
		return	mGO.GetComponent<Crystal> ();
	}
}
