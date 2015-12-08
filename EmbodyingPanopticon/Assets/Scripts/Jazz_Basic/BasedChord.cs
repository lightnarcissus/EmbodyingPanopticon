using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Utils;

public class BasedChord {
	public int pitchclass;
	public int chordindex;
	public BasedChord(string desc,List<Scale> chordlist)
	{
		string suffix="";
		bool found=false;
		for (int i=0;i<Note.Names.Length;i++)
		{
			string notename = Note.Names[i];
			
			if (desc.StartsWith(notename))
			{
				if (desc==notename)
				{
					desc+="major";
				}
				found=true;
				pitchclass=i;
				suffix=desc.Substring(notename.Length);
				break;
			}
		}
		
		if (!found)
		{
			Debug.Log("ERROR ERROR BASEDCHORD NOT RIGHT - desc = " + desc);
			return;
		}
			
		bool foundchord=false;
		for (int i=0;i<chordlist.Count;i++)
		{
			Scale chord = chordlist[i];
			if (suffix==chord.name)
			{
				chordindex=i;
				foundchord=true;
				break;
			}
		}
		
		
		if (!foundchord)
		{
			Debug.Log("ERROR ERROR BASEDCHORD NOT RIGHT - desc = " + desc + " | " + suffix);
			return;
		}
				
	}
	
	public int GetNote(int lower, int upper, int n, List<Scale> chordlist)
	{
		Scale chord = chordlist[chordindex];
		//pretend in c and get lower note
		lower-=pitchclass;
		upper-=pitchclass;
		List<int> validnotes = new List<int>();
		for (int i=lower;i<=upper;i++)
		{
			if (chord.notes[((i%12)+12)%12])
			{
				validnotes.Add(i);
			}
		}
		int note = validnotes[((n%validnotes.Count)+validnotes.Count) % validnotes.Count];
		
		// transform to proper key
		note+=pitchclass;
		
		return note;		
	}
	
	public BasedScale FindScale(List<Scale> scales, List<Scale> chords,int key_pitchclass)
	{
		List<BasedScale> compatiblescales = new List<BasedScale>();
		
		bool foundscale=false;
		for (int t=0;t<12;t++)
		{
			for (int i=0;i<scales.Count;i++)
			{
				BasedScale s = new BasedScale(key_pitchclass+t,i);
				if (s.HasChord(scales,chords,this))
				{
					compatiblescales.Add(s);
					foundscale=true;
				}
			}
			if (foundscale)
				break;
		}
		//Debug.Log(Time.time.ToString() + " compatiblescales = " + compatiblescales.Count.ToString());
		return Utility.RandomElement(compatiblescales);
	}
		
	public int RandomNote(int lower, int upper, List<Scale> chordlist)
	{		
		Scale chord = chordlist[chordindex];
		//pretend in c and get lower note
		lower-=pitchclass;
		upper-=pitchclass;
		List<int> validnotes = new List<int>();
		for (int i=lower;i<=upper;i++)
		{
			if (chord.notes[((i%12)+12)%12])
			{
				validnotes.Add(i);
			}
		}
		int note = Utility.RandomElement(validnotes);
		
		// transform to proper key
		note+=pitchclass;
		
		return note;
	}
	
	public bool HasNote(List<Scale> chords, int n)
	{
		n-=pitchclass;
		return chords[chordindex].notes[((n%12)+12)%12];
	}
	
	public string Print(List<Scale> chords)
	{
		string s = "chord - ";
		for (int i=0;i<12;i++)//in real space
		{
			s += HasNote(chords,i) ? "1" : "0";
		}
		
		return s;
	}
}
