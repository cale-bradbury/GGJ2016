using UnityEngine;
using System.Collections;

public class PalController : MonoBehaviour {

    public Transform target;
    public Transform teleportTarget;
    public float speed = 0.1f;
    public float minDistance = 2f;
    private bool canFollow = false;

	// Update is called once per frame
	void Update () {
        Follow();
    }

    void Follow() {
        if (canFollow)
        {
            float distance = getDistance();
            if (distance > minDistance)
            {
                transform.position = Vector3.Lerp(transform.position, target.position, speed * distance * Time.deltaTime);
            }
        }        
    }

    public void ResumeFollowing() {
        canFollow = true;
        // TODO: possibly teleport if a certain distance away.
        if(getDistance() > minDistance * 3f)
        {
            TeleportToTarget();
        }
    }

    public void StopFollowing() {
        canFollow = false;
    }

    void TeleportToTarget() {
        /*float distance = getDistance();
        while (distance > minDistance) {
            transform.position = Vector3.Lerp(transform.position, target.position, speed * distance * Time.deltaTime);
            distance = Vector3.Distance(transform.position, target.position);
        }*/

        transform.position = teleportTarget.position;
    }

    float getDistance() {
        return Vector3.Distance(transform.position, target.position);
    }
}
