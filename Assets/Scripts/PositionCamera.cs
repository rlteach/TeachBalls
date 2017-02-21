//Code (C) 2017 Richard Leinfellner
//Permission given to use for educational use

using UnityEngine;
using System.Collections;


public class PositionCamera : MonoBehaviour {

    [Header("Controls")]
    [Range(1f, 100f)]
    public float Sensitivity = 10f;     //Sensitivity

	float	mDistance;		//
	float	mA;		//
	float	mP;		//

	public	GameObject	Target;		//Follow this target

	public	Terrain Terrain;

	Polar	mPolar;		//Polar mapping helper for Camera
	Vector3	mRelativePosition;

	public	bool	AutoHeight;

    void Start() {
		mPolar=new Polar(transform.position-Target.transform.position);
		mRelativePosition = transform.position-Target.transform.position;
    }


	//Update Camera so its pointing at Target, cater for Camara Zoom and Move
    void LateUpdate () {


		if (AutoHeight) {
			Quaternion	tYrotation = Quaternion.Euler (0, Target.transform.rotation.eulerAngles.y,0);		//Isolate Rotation around y
			Vector3	tAdjustedPosition = tYrotation*mRelativePosition;		//Rotate Camera around Y
			tAdjustedPosition+=Target.transform.position;
			tAdjustedPosition.y += Terrain.SampleHeight (tAdjustedPosition);
			transform.position = tAdjustedPosition;
		} else {
			mPolar.Radius += IC.GetInput (IC.Directions.Zoom) * Time.deltaTime * Sensitivity;
			mPolar.Azimuth += IC.GetInput (IC.Directions.ShiftMoveX) * Time.deltaTime * Sensitivity * 10f;
			mPolar.Attitude += IC.GetInput (IC.Directions.ShiftMoveY) * Time.deltaTime * Sensitivity * 10f;

			mPolar.Radius = Mathf.Clamp (mPolar.Radius, 1.5f, 50f);
			mPolar.Azimuth = Mathf.Clamp (mPolar.Azimuth, -135f, 135);
			mPolar.Attitude = Mathf.Clamp (mPolar.Attitude, 5f, 45f);
			transform.position =mPolar.Vector+Target.transform.position;;	//Move camera to now location on Camera plane
		}

        if (Target == null) {       //Keep Camera looking at Parent
			Debug.Log("No Parent to look at");
        } else {
            transform.LookAt(Target.transform.position);	//Look at parent
        }
    }
}
