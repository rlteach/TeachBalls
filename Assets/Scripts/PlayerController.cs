using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

    [Header("Settings")]
    public float Sensitivity = 5f;


    CharacterController mCC;			//CC link

	public	Terrain	Terrain;

    // Use this for initialization
    void Start() {
		mCC = GetComponent<CharacterController>();        //Get Reference to RB to move it
        GameManager.PC = this;              //Link us into the GameController
		InvokeRepeating("Shrink", 1f,0.5f);
    }

    void    OnDestroy() {
        GameManager.PC = null;          //Remove link when we die, should happen anyway but allows for cleanup
        Debug.Log("PlayerController Destroyed");
    }


    // FixedUpdate is called once per physics frame, this is locked to a fixed framerate

	bool	Dead=false;

    void Update() {
		MoveCharacter ();
    }

	public	float	MoveSpeed = 10f;
	Vector3 mMoveDirection = Vector3.zero;

	void MoveCharacter() {          //Move Character with controller
		if (!Dead) {
			if (mCC.isGrounded) {
				transform.Rotate (0, IC.GetInput (IC.Directions.MoveX), 0);
				mMoveDirection.x = 0f;
				mMoveDirection.y = 0f;
				mMoveDirection.z = IC.GetInput (IC.Directions.MoveY);
				mMoveDirection = transform.TransformDirection (mMoveDirection);      //Move in direction character is facing
				mMoveDirection *= MoveSpeed;
				if (IC.GetInput (IC.Directions.Jump) > 0f) {
					mMoveDirection.y = 10f;        //Jump
				}
			}
			mMoveDirection.y += Physics.gravity.y * Time.deltaTime;
			mCC.Move (mMoveDirection * Time.deltaTime);
		}
	}


	void	Grow() {
	//	Resize (1.2f);
	}

	void	Shrink() {
	//	Resize (0.99f);
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

	void OnTriggerEnter(Collider vCol)  {
		if (vCol.gameObject.tag == "Crystal") {
			Crystal tC = vCol.gameObject.GetComponent<Crystal> ();
			tC.PlayerCollided ();
			Invoke ("Grow", 0.5f);
		} else if (vCol.gameObject.tag == "Rain") {
			Invoke ("Grow", 0.2f);
			Destroy (vCol.gameObject);		//Get rid of the rain
		}  else if (vCol.gameObject.tag == "Terrain") {
		}
    }
}
