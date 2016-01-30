using UnityEngine;
using System.Collections;

public class ccEventEnableBehaviour : MonoBehaviour {
	
	public string enableEvent;
	public string disableEvent;
	public MonoBehaviour[] behaviours;

	// Use this for initialization
	void Start () {
		Messenger.AddListener(enableEvent,On);
		Messenger.AddListener(disableEvent,Off);
	}
	
	// Update is called once per frame
	void On () {
		foreach(MonoBehaviour m in behaviours){
			m.enabled = true;
		}
	}
	void Off () {
		foreach(MonoBehaviour m in behaviours){
			m.enabled = false;
		}
	}
}
