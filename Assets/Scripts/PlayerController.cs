using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private GameObject elevator;
    private ElevatorController elevatorController;
	Camera mainCam;
    private int collectiblesFound = 0;
    ElevatorButton[] buttons;

	// Use this for initialization
	void OnEnable () {
        elevator = GameObject.Find("Elevator");
        elevatorController = elevator.GetComponent<ElevatorController>();
		mainCam = GetComponentInChildren<Camera> ();
    }

    void Start()
    {
        buttons = FindObjectsOfType<ElevatorButton>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Interact();
        }
    }

    void Interact() {
        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f);
        float rayLength = 3f;
        Ray ray = mainCam.ViewportPointToRay(rayOrigin);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            InteractWithCollision(hit);
        }
    }

    void InteractWithCollision(RaycastHit hit) {
        Debug.Log("Interact with collision: " + hit.transform.gameObject.tag);
        if (hit.transform.gameObject.tag == "button")
        {
            ElevatorButton e = hit.transform.GetComponent<ElevatorButton>();
            int levelKey = e.levelKey;
            e.Press();
            foreach (ElevatorButton b in buttons)
                if (b != e)
                    b.Revert();
            elevatorController.GoToLevel(levelKey);
            Debug.Log("button-click:" + levelKey);
        }
        else if(hit.transform.gameObject.tag == "elevator-door")
        {
			if(!elevatorController.isPlayerInside)
				elevatorController.OpenDoor();
        }
        else if (hit.transform.gameObject.tag == "collectible")
        {
            Destroy(hit.transform.gameObject);
            collectiblesFound++;
            Debug.Log("Wow, you found a sweet nothing. Great job!");
        }
        else {
            Dialog[] dia = hit.transform.GetComponents<Dialog>();
            foreach (Dialog d in dia)
            {
                if (d != null && d.enabled)
                {
                    d.StartDialog();
                }
            }
        }
    }
}
