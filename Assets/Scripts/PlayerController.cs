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
    }

    void    OnDestroy() {
        GameManager.PC = null;          //Remove link when we die, should happen anyway but allows for cleanup
        Debug.Log("PlayerController Destroyed");
    }

    // FixedUpdate is called once per physics frame, this is locked to a fixed framerate
    void FixedUpdate() {
        mForce.x = InputController.GetInput(InputController.Directions.MoveX);
        mForce.z = InputController.GetInput(InputController.Directions.MoveY);
        mRB.AddForce(mForce * Sensitivity);
        mForce.x = mForce.z = 0f;
        mForce.y = InputController.GetInput(InputController.Directions.Jump);
        mRB.AddForce(mForce, ForceMode.Impulse);
    }

    void Grow() {
        transform.localScale *= 1.02f;
		mRB.mass *= 1.1f;
    }

    void OnCollisionEnter(Collision vCol) {
        if (vCol.gameObject.tag == "Crystal") {
            Crystal tC = vCol.gameObject.GetComponent<Crystal>();
            tC.PlayerCollided();
            Invoke("Grow", 0.5f);
        }
    }
}
