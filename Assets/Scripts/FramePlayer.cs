using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[ExecuteInEditMode]
public class FramePlayer : MonoBehaviour {

	public CCReflectTexture output;
	public List<Texture2D> frames;
	int index = 0;
	public float frameDelay = .03f;

	public bool loop = true;
	public string endLoopEvent;

	void OnEnable(){

		frames = frames.OrderBy (x => x.name).ToList ();
		if(Application.isPlaying)
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
				index = 0;
				Invoke ("NextFrame", frameDelay);
			}
		} else {
			Invoke ("NextFrame", frameDelay);
		}
	}
}
