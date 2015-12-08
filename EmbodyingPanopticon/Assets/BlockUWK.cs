using UnityEngine;
using System.Collections;

public class BlockUWK : MonoBehaviour {

    private GameObject targetObj;

	// Use this for initialization

    void Awake()
    {
        
    }
	void Start () {

       
      


    }
	
	// Update is called once per frame
	void Update () {

        if(targetObj==null)
        {
            targetObj = GameObject.Find("UWKCore");
        }
        else
        {
          //  targetObj.GetComponent<UWKActivation>().enabled = false;
        }
	
	}
}
