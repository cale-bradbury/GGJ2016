using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ElevatorController : MonoBehaviour {

	int currentLevel = -1;
	int nextLevel = 0;
	public List<GameObject> levels = new List<GameObject>();

	public AnimationCurve doorAnimation;
	public float doorTime = 1;
	public float elevatorTime = 2;

	public Transform leftDoor;
	public Transform rightDoor;
	
	private TextMesh floorText;
	private bool openingDoor = false;
	private bool animating = false;

    private Vector3 levelOrigin = new Vector3(0f, 0f, 0f);

    public bool isPlayerInside;
    bool openDoors = false;

    // Use this for initialization
    void Start () {
		floorText = gameObject.GetComponentInChildren<TextMesh>();
		GoToLevel (nextLevel);
    }

	public void GoToLevel(int index) {
		nextLevel = index;
		if (nextLevel == currentLevel || animating)
			return;
		if (openDoors) {
			CloseDoor ();
			return;
		}
		EnableLevel ();
	}

	void EnableLevel(){
		CancelInvoke ("OpenDoor");
		if(currentLevel >= 0 && levels [currentLevel])
			levels [currentLevel].SetActive (false);
		levels [nextLevel].SetActive (true);
		currentLevel = nextLevel;
		Invoke ("OpenDoor", elevatorTime);
	}

	public void OpenDoor(){
		if (animating||openDoors)
			return;
		openingDoor = animating = true;
		StartCoroutine (Utils.AnimationCoroutine (doorAnimation, doorTime, AnimateDoor, OnDoorOpen));
	}

	void CloseDoor(){
		openingDoor = openDoors = false;
		animating = true;
		StartCoroutine (Utils.AnimationCoroutine (doorAnimation, doorTime, AnimateDoor, OnDoorClose));
	}

	void AnimateDoor(float f){
		Vector3 r = rightDoor.transform.localPosition;
		Vector3 l = leftDoor.transform.localPosition;
		if (openingDoor) {
			r.x = -f;
			l.x = f;
		} else {
			r.x = f-1;
			l.x = 1-f;
		}
		rightDoor.transform.localPosition = r;
		leftDoor.transform.localPosition = l;
	}

	void OnDoorOpen(){
		animating = false;
		openDoors = true;
		if (nextLevel != currentLevel)
			CloseDoor ();
	}

	void OnDoorClose(){
		animating = false;
		if (isPlayerInside) {
			EnableLevel ();
		} else {
			nextLevel = currentLevel;
			OpenDoor ();
		}
	}

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            isPlayerInside = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerInside = false;
        }
    }
}

