using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Utils;

public class Jazzy : MelodyGenerator
{	

	public int sound_channels=5;
	
	public List<Scale> scales;
	public List<Scale> chords;
	public List<Progression> progressions;
	
	public static List<AudioClip> allsounds;
	
	// Use this for initialization
	public Jazzy () {
		//generate scales
		scales = Scale.LoadFromFile(Resources.Load("Texts/scaledata") as TextAsset);
		//generate chords
		chords = Scale.LoadFromFile(Resources.Load("Texts/chorddata") as TextAsset);
		
		/*
		string chordnames ="";
		for (int i=0;i<chords.Count;i++)
		{
			chordnames+=chords[i].name+",";
		}
		Debug.Log("chord names:"+chordnames);
		*/
		
		//generate progressions
		progressions = Progression.LoadFromFile(Resources.Load("Texts/progressiondata") as TextAsset,chords);
		
		// audio stuff
		
		Object[] obs;
		obs  = Resources.LoadAll("melodic",typeof(AudioClip));					
		allsounds = new List<AudioClip>();

	    for (int i=0; i < obs.Length; i++)
	    {
	    	AudioClip ac = obs[i] as AudioClip;
	    	if (ac!=null)
	    	{
	        	allsounds.Add(ac);
	        }
	    }
		
		//
		
		//Generate();
	}
	
	public override GenericMelody GenerateMelody()
	{
			JazzGenerator generator = new JazzGenerator(scales,chords,progressions);
			float tempo_bpm=Random.Range(60.0f,160.0f);
			MelodyLine music = new MelodyLine(generator.melody,generator.accompaniment,Utility.RandomElement(allsounds),Utility.RandomElement(allsounds),tempo_bpm);					
			return music;
	}
	
	/*
	void Generate()
	{	
		MelodyGenerator generator = new MelodyGenerator(scales,chords,progressions);
		float tempo_bpm=Random.Range(60.0f,160.0f);
		MelodyLine melodyline = new MelodyLine(generator.melody,generator.accompaniment,Utility.RandomElement(allsounds),Utility.RandomElement(allsounds),tempo_bpm);
		
	
		// MELODY STUFF - can separate into own component if necessary
		
		if (GetComponents<AudioSource>().Length==0)
		{
			for (int i=0;i<sound_channels;i++)
			{
				AudioSource a_s = gameObject.AddComponent<AudioSource>();
				a_s.pan=0;
			}
		}
		
//		PlayMelody(melodyline);
	}
		
	void PlayMelody(MelodyLine melody)
	{
		StopCoroutine("StartPlay");
		StartCoroutine("StartPlay",melody);
	}
	
	IEnumerator StartPlay(MelodyLine melody)
	{		
		for (int i=0;i<GetComponents<AudioSource>().Length;i++)
		{ 
			AudioSource audiosource = GetComponents<AudioSource>()[i];
			audiosource.Stop();
		}
		
		AudioSource[] a_s = GetComponents<AudioSource>();
		
		if (a_s.Length==0)
		{
			Debug.Log("ASdFASD");
			yield return null;
		}
		
		int curas=0;
		
		float time=0;
		
		int soundlocation=0;
		int durationlocation=0;
		int frequencylocation=0;
		int volumelocation=0;
			
		while(true)
		{
			AudioClip sound =  melody.sounds[soundlocation];
			float duration = melody.durations[durationlocation];
			float frequency = melody.frequencies[frequencylocation];
			float volume = melody.volumes[volumelocation];			
			time+=duration;
			
			a_s[curas].pitch=frequency;
			a_s[curas].PlayOneShot(sound);
			curas=(curas+1)%a_s.Length;						
			
			yield return new WaitForSeconds(duration);
			soundlocation = (soundlocation+1)%melody.sounds.Count;
			durationlocation = (durationlocation+1)%melody.durations.Count;
			frequencylocation = (frequencylocation+1)%melody.frequencies.Count;
			volumelocation = (volumelocation+1)%melody.volumes.Count;
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump"))
		{
			Generate();
		}
	}*/
}
