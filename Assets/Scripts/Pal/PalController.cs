using UnityEngine;
using System.Collections;

public class PalController : MonoBehaviour {

    public Transform target;
    public Transform teleportTarget;
    public Transform couch;
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
        Messenger.AddListener("pal-to-couch", TeleportToCouch);
        Messenger.AddListener("pal-enable-couch-talk", EnableCouchTalk);
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = target.position;
        if (pos.y - 0.5f < transform.position.y)
        {
            transform.LookAt(pos);
        }
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
        if (getDistance() > minDistance * 3f)
        {
            TeleportToTarget();
        }
    }

    public void StopFollowing() {
        canFollow = false;
    }

    void TeleportToTarget() {
        transform.position = teleportTarget.position;
        TeleportParticles();
    }

    void TeleportToCouch() {
        StopFollowing();
        transform.position = couch.position;
        TeleportParticles();
    }

    void TeleportParticles() {
        particles.gameObject.SetActive(false);
        particles.gameObject.SetActive(true);
    }

    float getDistance() {
        return Vector3.Distance(transform.position, target.position);
    }

    void EnableCouchTalk() {
        introTalk.enabled = false;
        randomTalk.enabled = false;
        couchTalk.enabled = true;
    }
}
