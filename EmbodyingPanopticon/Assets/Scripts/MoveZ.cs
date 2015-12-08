using UnityEngine;
using System.Collections;

public class MoveZ : MonoBehaviour {

    private float timer = 0f;

	// Use this for initialization
	void Start () {

        InvokeRepeating("MoveCam", 1f, 1f);
      
	
	}
	
	// Update is called once per frame
	void Update () {
        
       
	
	}

    void MoveCam()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 10f * oscControl.accX);
        GetComponent<GlitchEffect>().intensity = oscControl.accX*2f;
        GetComponent<Camera>().clearFlags = CameraClearFlags.Nothing;
    }
}
