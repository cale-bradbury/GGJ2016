using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private GameObject elevator;
    private ElevatorController elevatorController;

	// Use this for initialization
	void Start () {
        elevator = GameObject.Find("elevator");
        elevatorController = elevator.GetComponent<ElevatorController>();
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
        float rayLength = 500f;
        Ray ray = Camera.main.ViewportPointToRay(rayOrigin);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            InteractWithCollision(hit);
        }
    }

    void InteractWithCollision(RaycastHit hit) {
        if (hit.transform.gameObject.tag == "button")
        {
            string levelKey = hit.transform.GetComponent<ElevatorButton>().levelKey;
            elevatorController.GoToLevel(levelKey);
            Debug.Log("button-click:" + levelKey);
        } else {
            Dialog d = hit.transform.GetComponent<Dialog>();
            if (d != null)
            {
                d.StartDialog();
            }
        }
    }
}
