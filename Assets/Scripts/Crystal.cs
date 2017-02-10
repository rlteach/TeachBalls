using UnityEngine;
using System.Collections;

public class Crystal : TerrainObject {

	public	float	KillTime=10.0f;

	public	Color	FromColour=Color.cyan;
	public	Color	ToColour=Color.yellow;

	protected override void 	Start () {
        base.Start();                       //Ensure base class Start() runs
		mANI.SetFloat("Speed",Random.Range(0.1f,1.5f));
	}

	public	void	ColourCycle(float vTime) {		//Colour Cycle Crystals
		mMR.material.color = Vector4.Lerp (FromColour, ToColour, Mathf.Sin (vTime * Mathf.PI * 2f));
	}

	public	override void	PlayerCollided() {
		base.PlayerCollided ();		//Call Base methods
		Debug.Log ("PlayerCollided:Crystal");
	}

	public	void	Eaten() {
		Destroy (gameObject);
        GameManager.DeleteCrystal(this);
	}

    public override string ToString() {
        return "Crystal";
    }
}
