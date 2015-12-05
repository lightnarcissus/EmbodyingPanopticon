using UnityEngine;
using System.Collections;

public class WebcamScript : MonoBehaviour {

	private int filter=0; //0 for normal
	public GameObject main;
	// Use this for initialization
	IEnumerator Start () {
		yield return Application.RequestUserAuthorization(UserAuthorization.WebCam | UserAuthorization.Microphone);
		WebCamTexture webcamTexture = new WebCamTexture();
		GetComponent<Renderer>().material.mainTexture = webcamTexture;
		webcamTexture.Play();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			if(filter!=0)
			filter--;
			else
				filter=10;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			if(filter!=10)
				filter++;
			else
				filter=0;
		}
/*
	switch (filter) {
		case 0:
			main.GetComponent<PP_SecurityCamera>().enabled=false;
			main.GetComponent<PP_4Bit>().enabled=false;
			break;
		case 1:
			main.GetComponent<PP_4Bit>().enabled=true;
			main.GetComponent<PP_BlackAndWhite>().enabled=false;
			break;
		case 2:
			main.GetComponent<PP_4Bit>().enabled=false;
			main.GetComponent<PP_BlackAndWhite>().enabled=true;
			main.GetComponent<PP_Charcoal>().enabled=false;
			break;
		case 3:
			main.GetComponent<PP_BlackAndWhite>().enabled=false;
			main.GetComponent<PP_Charcoal>().enabled=true;
			main.GetComponent<PP_Bleach>().enabled=false;
			break;
		case 4:
			main.GetComponent<PP_Charcoal>().enabled=false;
			main.GetComponent<PP_Bleach>().enabled=true;
			main.GetComponent<PP_LineArt>().enabled=false;
			break;
		case 5:
			main.GetComponent<PP_Bleach>().enabled=false;
			main.GetComponent<PP_LineArt>().enabled=true;
			main.GetComponent<PP_Negative>().enabled=false;
			break;
		case 6:
			main.GetComponent<PP_LineArt>().enabled=false;
			main.GetComponent<PP_Negative>().enabled=true;
			main.GetComponent<PP_SobelOutlineV7>().enabled=false;
			break;
		case 7:
			main.GetComponent<PP_Negative>().enabled=false;
			main.GetComponent<PP_SobelOutlineV7>().enabled=true;
			main.GetComponent<PP_SinCity>().enabled=false;
			break;
		case 8:
			main.GetComponent<PP_SobelOutlineV7>().enabled=false;
			main.GetComponent<PP_SinCity>().enabled=true;
			main.GetComponent<PP_Pixelated>().enabled=false;
			break;
		case 9:
			main.GetComponent<PP_SinCity>().enabled=false;
			main.GetComponent<PP_Pixelated>().enabled=true;
			main.GetComponent<PP_SecurityCamera>().enabled=false;
			break;
		case 10:
			main.GetComponent<PP_Pixelated>().enabled=false;
			main.GetComponent<PP_SecurityCamera>().enabled=true;
			break;
		default:
			break;
		}
	*/
	}
}
