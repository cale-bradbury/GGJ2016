using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ElevatorController : MonoBehaviour {

    // TODO: this will be a list of level objects (will these have their own class?)
    // List<GameObject> levels = new List<GameObject>();
    // Dictionary<string, GameObject> levels = new Dictionary<string, GameObject>();

    //public List<GameObject> buttons = new List<GameObject>();

    // Use this for initialization
    void Start () {

        // TODO: add each level > levels.Add ( new GameObject() );
    }

    // Update is called once per frame
    void Update() {

    }

    void OnButtonClick() {
       // GoToLevel();
    }

    public void GoToLevel (string levelKey) {
        // close > levels[currentLevelKey];
        // open > levels[levelKey];
        Debug.Log("Go to: " + levelKey);
    }
}
