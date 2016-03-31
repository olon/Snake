using UnityEngine;
using System.Collections;

public class CameraRoutateAround : MonoBehaviour {

    public GameObject Target;
	
	void Update () {
        transform.LookAt(Target.transform);
        //transform.R
    }
}
