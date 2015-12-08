using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Utils;
using UnityStandardAssets.ImageEffects;
public class MusicPlayer : MonoBehaviour {
	
	private int channelcount = 5;

	private List <MelodyGenerator> generators;
  /*  public static GameObject mainCam;
    public static int sampleIndex = 0;
    public static int discomfort = 0;
    public Color[] lightColors = { Color.red, Color.black, Color.blue, Color.green, Color.cyan, Color.magenta, Color.yellow, Color.white, Color.clear };
    public GameObject dirLight;*/
	public void Start()
	{
      //  mainCam = transform.GetChild(0).gameObject;
		for (int i=0;i<channelcount;i++)
		{
			AudioSource a_s = this.gameObject.AddComponent<AudioSource>();
			a_s.panStereo=0;
			a_s.spatialBlend=0;
			a_s.loop=false;
			a_s.playOnAwake=false;
		}
		
		generators = new List<MelodyGenerator>();
		//new Jazzy();
		generators.Add(new Jazzy());
		generators.Add(new MarkovPlay());
		generators.Add(new Species_Generator());
		generators.Add(new MotivicGenerator());
			
		NewMelody();
	}
	
	public void NewMelody()
	{
		StopCoroutine("GenerateMelody");
		StartCoroutine("GenerateMelody");
	}

	private IEnumerator GenerateMelody()
	{
		GenericMelody melody = Utility.RandomElement(generators).GenerateMelody();
		StopCoroutine("PlayMelody");
		StartCoroutine("PlayMelody",melody);
		yield break;
	}
	
	private IEnumerator PlayMelody(GenericMelody melody)
	{
		int pitchindex=0;
		int durationindex=0;
		int velocityindex=0;
		int sampleindex=0;		
		int channelindex=0;
        float tempRand = Random.Range(0f, 100f);
		AudioSource[] audiosources = GetComponents<AudioSource>();
       // mainCam.GetComponent<PP_LineArt>().lineColor = lightColors[(int)tempRand % 9];
		while(true)
		{
			float pitch = melody.frequencies[pitchindex];
			float duration = melody.durations[durationindex];
			float velocity = melody.volumes[velocityindex]/2;
			AudioClip sample = melody.sounds[sampleindex];

            //Debug.Log("DurationIndex "+durationindex);
            //Debug.Log("PitchIndex " + pitchindex);
            //Debug.Log("VelocityIndex " + velocityindex);
           // Debug.Log("SampleIndex " + sampleindex);

        /*    mainCam.GetComponent<Vortex>().radius = new Vector2(sampleindex % 14, sampleindex % 13);
            mainCam.GetComponent<Vortex>().center = new Vector2(sampleindex % 16, sampleindex % 18);
            mainCam.GetComponent<Vortex>().angle =tempRand +(sampleindex * 4f);
            dirLight.GetComponent<Light>().color = lightColors[sampleindex % 9];
            if (discomfort < 10)
                mainCam.GetComponent<PP_LineArt>().lineAmount = (sampleindex % (10 - discomfort) * 500);
            else
                mainCam.GetComponent<PP_LineArt>().lineAmount = (sampleindex % 10 * 500);
            mainCam.GetComponent<PP_ScreenWaves>().amplitude = pitch/9f;
            mainCam.GetComponent<NoiseAndGrain>().intensityMultiplier = discomfort;
            mainCam.transform.parent.gameObject.GetComponent<Gain>().level = discomfort;
            mainCam.transform.parent.gameObject.GetComponent<Noise>().offset = 2f- (discomfort / 5f);
            mainCam.transform.parent.gameObject.GetComponent<AudioDistortionFilter>().distortionLevel = discomfort/10f;*/
          //  sampleIndex = sampleindex;
			AudioSource a_s;
			if (melody.specifychannels)
			{
				a_s = audiosources[melody.channels[channelindex]];
			}
			else
			{
				a_s = audiosources[channelindex];
			}
			
			a_s.pitch=pitch;
			a_s.volume=velocity;
			//produces clicks :(
			//if (melody.clearchannelonretrigger)
			//	a_s.Stop();
			a_s.PlayOneShot(sample);
			yield return new WaitForSeconds(duration);
			
			pitchindex = (pitchindex+1)%melody.frequencies.Count;
			durationindex = (durationindex+1)%melody.durations.Count;
			velocityindex = (velocityindex+1)%melody.volumes.Count;
			sampleindex = (sampleindex+1)%melody.sounds.Count;
			if (melody.specifychannels)
			{
				channelindex = (channelindex + 1)%melody.channels.Count;
			}
			else
			{
				channelindex = (channelindex + 1)%audiosources.Length;
			}
		}
	}
	
	public void Update()
	{
		if (Input.anyKeyDown)
		{
			NewMelody();
		}
			
	}
}
