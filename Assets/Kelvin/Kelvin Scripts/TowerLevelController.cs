using UnityEngine;
using System.Collections;

public class TowerLevelController : MonoBehaviour {

    private int inactiveTowerKeys = 3;
	// Use this for initialization
	void Start () {
       Messenger.AddListener("tower-key-active", KeyActivated);
	}
	
	void KeyActivated() {
        inactiveTowerKeys--;
        Debug.Log("Inactive tower keys remaining: " + inactiveTowerKeys);
        if(inactiveTowerKeys == 0)
        {
            RevealSweetNothing();
        }
    }

    void RevealSweetNothing() {

    }
}
