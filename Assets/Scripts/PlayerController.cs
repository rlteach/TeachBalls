using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    [Header("Settings")]
    public float Sensitivity = 5f;


    Rigidbody mRB;			//RB link
    Vector3 mForce = Vector3.zero;


    // Use this for initialization
    void Start() {
        mRB = GetComponent<Rigidbody>();        //Get Reference to RB to move it
        GameManager.PC = this;              //Link us into the GameController
		InvokeRepeating("Shrink", 1f,0.5f);
    }

    void    OnDestroy() {
        GameManager.PC = null;          //Remove link when we die, should happen anyway but allows for cleanup
        Debug.Log("PlayerController Destroyed");
    }

    // FixedUpdate is called once per physics frame, this is locked to a fixed framerate
    void FixedUpdate() {
        mForce.x = InputController.GetInput(InputController.Directions.MoveX);
        mForce.z = InputController.GetInput(InputController.Directions.MoveY);
		float	tThrust = InputController.GetInput (InputController.Directions.Thrust)+2f;
		float	tBrake = -InputController.GetInput (InputController.Directions.Brake)+2f;
		mRB.AddForce(mForce * Sensitivity*(tThrust+tBrake));
        mForce.x = mForce.z = 0f;
        mForce.y = InputController.GetInput(InputController.Directions.Jump);
        mRB.AddForce(mForce, ForceMode.Impulse);
    }

	void	Grow() {
		Resize (1.2f);
	}

	void	Shrink() {
		Resize (0.99f);
	}

	public	float	Size {
		get {
			return transform.localScale.magnitude;
		}
	}

	void Resize(float vScale=1.2f) {
		float	tSize = Mathf.Clamp (Size * vScale, 0.2f, 5f);
		transform.localScale = transform.localScale.normalized * tSize;
    }

    void OnCollisionEnter(Collision vCol) {
		if (vCol.gameObject.tag == "Crystal") {
			Crystal tC = vCol.gameObject.GetComponent<Crystal> ();
			tC.PlayerCollided ();
			Invoke ("Grow", 0.5f);
		} else if (vCol.gameObject.tag == "Rain") {
			Invoke ("Grow", 0.2f);
			Destroy (vCol.gameObject);		//Get rid of the rain
		}
    }
}
