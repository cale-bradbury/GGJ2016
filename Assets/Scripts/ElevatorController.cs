using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ElevatorController : MonoBehaviour {

    public List<GameObject> levelPrefabs = new List<GameObject>();
    private List<GameObject> levels = new List<GameObject>();
    private GameObject activeLevel;
    private Vector3 levelOrigin = new Vector3(0f, 0f, 0f);

    // Use this for initialization
    void Start () {
        foreach(GameObject levelPrefab in levelPrefabs)
        {
            GameObject level = (GameObject)Instantiate(levelPrefab, levelOrigin, Quaternion.identity);
            level.SetActive(false);
            levels.Add(level);
        }
    }

    // Update is called once per frame
    void Update() {

    }

    public void GoToLevel (int levelKey) {
        Debug.Log("Go to: " + levelKey);
        GameObject requestedLevel = levels[levelKey - 1];
        if (activeLevel) {
            if(activeLevel != requestedLevel) {
                activeLevel.SetActive(false);
            } else {
                return;
            }
        }
        activeLevel = requestedLevel;
        activeLevel.SetActive(true);
    }
}
