using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;

public class ElevatorController : MonoBehaviour {

	int currentLevel = -1;
	int nextLevel = 1;
	public List<GameObject> levels = new List<GameObject>();

	public AnimationCurve doorAnimation;
	public float doorTime = 1;
	public float elevatorTime = 2;

	public Transform leftDoor;
	public Transform rightDoor;
	public AudioSource rideSource;
	
	private TextMesh floorText;
	private bool openingDoor = false;
	private bool animating = false;

    public bool isPlayerInside;
    bool openDoors = false;
	bool shake = false;
	public Transform shakeMe;
	public AudioMixer levelMix;

    // Use this for initialization
    void Start () {
		floorText = gameObject.GetComponentInChildren<TextMesh>();
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
		floorText.text = levels [nextLevel].GetComponent<LevelData> ().levelName;
		Invoke ("OpenDoor", elevatorTime);
		rideSource.Play ();
		shake = true;
	}

	void Update(){
		if (shake) {
			shakeMe.localPosition = new Vector3 (Random.value - .5f, Random.value - .5f, Random.value - .5f)*.02f;
		}
	}

	public void OpenDoor(){
		shake = false;
		shakeMe.localPosition = Vector3.zero;
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
			levelMix.SetFloat ("Volume", (1-f)*(-80));
		} else {
			r.x = f-1;
			l.x = 1-f;
			levelMix.SetFloat ("Volume", f*(-80));
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

