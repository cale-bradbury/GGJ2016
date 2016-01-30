using UnityEngine;  
using System.Collections.Generic;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {  
	public List<DialogElement> dialogs = new List<DialogElement>();

	Text text;
	int index = 0;
	bool dialogMode = false;

	void OnEnable(){
		text = FindObjectOfType<Text> ();
	}

	void Update(){
		if (dialogMode) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				NextInput ();
			}
		}
	}

	void NextInput(){
		DialogElement d = dialogs [index];
		if (d.type == DialogElement.Type.Dialog) {
			text.text = d.string1;
		} else if (d.type == DialogElement.Type.Event) {
			Messenger.Broadcast (d.string1);
		}
		index++;
		if (index == dialogs.Count) {
			index = 0;
		}
	}

}