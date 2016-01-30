using UnityEngine;
using System.Collections.Generic;

public class FramePlayer : MonoBehaviour {

	public CCReflectTexture output;
	public List<Texture2D> frames;
	int index = 0;
	float frameDelay = .03f;

	public bool loop = true;
	public string endLoopEvent;

	void OnEnable(){
		Play ();
	}
	void Play () {
		index = 0;
		CancelInvoke ("NextFrame");
		Invoke ("NextFrame", frameDelay);
	}
	void OnDisable () {
		CancelInvoke ("NextFrame");
	}
	
	// Update is called once per frame
	void NextFrame () {
		output.SetValue (frames [index]);
		index++;
		if (index == frames.Count) {
			Messenger.Broadcast (endLoopEvent);
			if (loop) {
				Invoke ("NextFrame", frameDelay);
			}
		}
	}
}
