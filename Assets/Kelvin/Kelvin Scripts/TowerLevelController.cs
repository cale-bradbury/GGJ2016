using UnityEngine;
using System.Collections;

public class TowerLevelController : MonoBehaviour {

    public GameObject sweetNothing;
    private int inactiveTowerKeys = 3;
	// Use this for initialization
	void Start () {
        sweetNothing.SetActive(false);
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
        sweetNothing.SetActive(true);
		Messenger.Broadcast ("TowersActive");
    }
}
