using UnityEngine;
using System.Collections;

public class PalController : MonoBehaviour {

    public Transform target;
    public Transform teleportTarget;
    public ParticleSystem particles;
    public float speed = 0.1f;
    public float minDistance = 2f;
    private bool canFollow = false;

    public Dialog introTalk;
    public Dialog couchTalk;
    public Dialog randomTalk;

    void Start()
    {
        couchTalk.enabled = false;
        randomTalk.enabled = false;
        particles.playOnAwake = true;

    }

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
        if(getDistance() > minDistance * 3f)
        {
            TeleportToTarget();
        }
    }

    public void StopFollowing() {
        canFollow = false;
    }

    void TeleportToTarget() {
        transform.position = teleportTarget.position;
        particles.gameObject.SetActive(false);
        particles.gameObject.SetActive(true);
    }

    float getDistance() {
        return Vector3.Distance(transform.position, target.position);
    }
}
