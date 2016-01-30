using UnityEngine;  
using System.Collections.Generic;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {  
	public List<DialogElement> dialogs = new List<DialogElement>();

	Text text;
	int index = 0;
	bool dialogMode = false;
	List<MonoBehaviour> scriptsToLock = new List<MonoBehaviour>();
	Camera cam;
	Transform lookTarget;
	Transform lookStart;

	void OnEnable(){
		text = FindObjectOfType<Text> ();
		text.text = "";
		cam = Camera.main;
		MouseLook[] ml = FindObjectsOfType<MouseLook> ();
		foreach(MouseLook m in ml)
			scriptsToLock.Add (m);
		scriptsToLock.Add (FindObjectOfType<FirstPersonDrifter> ());
		scriptsToLock.Add (FindObjectOfType<MouseLook> ());
		scriptsToLock.Add (FindObjectOfType<PlayerController> ());
		scriptsToLock.Add (FindObjectOfType<HeadBob> ());
	}

	void Update(){
		if (dialogMode) {
			if (Input.GetMouseButtonDown (0)) {
				NextInput ();
			}
		}
	}

	public void StartDialog(){
		index = 0;
		dialogMode = true;
		foreach (MonoBehaviour m in scriptsToLock)
			m.enabled = false;
		NextInput ();
	}

	public void EndDialog(){
		dialogMode = false;
		foreach (MonoBehaviour m in scriptsToLock)
			m.enabled = true;
		text.text = "";
	}

	void NextInput(){
		if (index == dialogs.Count) {
			EndDialog ();
			return;
		}
		bool fireNext = false;
		DialogElement d = dialogs [index];
		if (d.type == DialogElement.Type.Dialog) {
			text.text = d.string1;
		} else if (d.type == DialogElement.Type.Event) {
			Messenger.Broadcast (d.string1);
			fireNext = true;
		}else if (d.type == DialogElement.Type.LookAt) {
			lookTarget = cam.transform;
			lookTarget.LookAt(d.transform1);
			lookStart = cam.transform;
			dialogMode = false;
			Utils.AnimationCoroutine (AnimationCurve.EaseInOut(0,0,1,1), d.float1, LookAt, FinishLookAt);
		}
		index++;
		if (fireNext)
			NextInput ();
	}

	void FinishLookAt(){
		NextInput ();
		dialogMode = true;
	}

	void LookAt(float f){
		cam.transform.rotation = Quaternion.Lerp (lookStart.rotation, lookTarget.rotation, f);
	}

}