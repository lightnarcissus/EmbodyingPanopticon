using UnityEngine;
using System.Collections;

public class MoveZ : MonoBehaviour {

	// Use this for initialization
	void Start () {

        GetComponent<Camera>().clearFlags = CameraClearFlags.Nothing;
	
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.position = new Vector3(transform.position.x, transform.position.y, 10f * oscControl.accX);
	
	}
}
