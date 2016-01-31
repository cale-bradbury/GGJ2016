using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private GameObject elevator;
    private ElevatorController elevatorController;
<<<<<<< HEAD
	Camera mainCam;
=======
    private int collectiblesFound = 0;

>>>>>>> remotes/origin/erik
	// Use this for initialization
	void OnEnable () {
        elevator = GameObject.Find("Elevator");
        elevatorController = elevator.GetComponent<ElevatorController>();
		mainCam = GetComponentInChildren<Camera> ();
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
        float rayLength = 2f;
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
            int levelKey = hit.transform.GetComponent<ElevatorButton>().levelKey;
            elevatorController.GoToLevel(levelKey);
            Debug.Log("button-click:" + levelKey);
        }
        else if(hit.transform.gameObject.tag == "elevator-door")
        {
            elevatorController.OpenDoorsFromOutside();
        }
        else if (hit.transform.gameObject.tag == "collectible")
        {
            Destroy(hit.transform.gameObject);
            collectiblesFound++;
            Debug.Log("Wow, you found a sweet nothing. Great job!");
        }
        else {
            Dialog d = hit.transform.GetComponent<Dialog>();
            if (d != null)
            {
                d.StartDialog();
            }
        }
    }
}
