using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenericMelody {
	public List<AudioClip> sounds;
	public List<float> frequencies;
	public List<float> durations;
	public List<float> volumes;

	public bool specifychannels=false;
	public bool clearchannelonretrigger=false;
	public List<int> channels;
}
