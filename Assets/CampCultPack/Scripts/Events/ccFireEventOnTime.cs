using UnityEngine;
using System.Collections;

public class ccFireEventOnTime : MonoBehaviour {
	
	public string eventName;
	public float time;
	// Use this for initialization
	void OnEnable () {
        CancelInvoke("Fire");
		Invoke ("Fire", time);
	}

	void Fire(){
		Messenger.Broadcast (eventName);
		Invoke ("Fire", time);
	}
}
