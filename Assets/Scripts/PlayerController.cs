using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Interact();
        }
    }

    void Interact() {
        Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
        float rayLength = 500f;

        // actual Ray
        Ray ray = Camera.main.ViewportPointToRay(rayOrigin);

        // debug Ray
        Debug.DrawRay(ray.origin, ray.direction * rayLength, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            InteractElevatorButton(hit);
        }
    }

    void InteractElevatorButton(RaycastHit hit) {
        if (hit.transform.name == "button")
        {
            Debug.Log("Press button");
            // todo: broadcast button that has been pressed.
        }
    }
}
