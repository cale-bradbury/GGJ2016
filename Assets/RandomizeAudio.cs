using UnityEngine;
using System.Collections;

public class RandomizeAudio : MonoBehaviour {

	AudioSource source;
	public AudioClip[] elevatorClips;

	// Use this for initialization
	void OnEnable() {
		source = GetComponent<AudioSource>();
		Randomize();
	}

	void OnDisable(){
		CancelInvoke("Randomize");
	}
	
	// Update is called once per frame
	void Randomize () {
		CancelInvoke("Randomize");
		source.clip = elevatorClips[Mathf.FloorToInt(Random.value*elevatorClips.Length)];
		source.Play();
		Invoke("Randomize",source.clip.length);
	}
}
