using UnityEngine;
using System.Collections;

public abstract class TerrainObject : MonoBehaviour {           //This is only a base class, it must be inherited

    protected   Animator mANI;          //Animator reference
    protected   MeshRenderer mMR;       //Mesh renderer reference

    // Use this for initialization
    protected virtual void Start () {               //Protected means a dereived class can access but nothign beyond
        mANI = GetComponent<Animator>();
        mMR = GetComponent<MeshRenderer>();
        mANI.SetFloat("Speed", 0f);     //Stop Animation
        transform.position=GameManager.TC.MoveToGround(transform.position);
    }
    public override string ToString() {
        return base.ToString();
    }
}
