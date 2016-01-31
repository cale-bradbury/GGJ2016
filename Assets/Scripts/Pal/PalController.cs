using UnityEngine;
using System.Collections;

public class PalController : MonoBehaviour {

    public Transform target;
    public Transform teleportTarget;
    public Transform couch;
    public ParticleSystem particles;
    public CouchController couchController;
    public AudioSource[] sounds;
    public AudioSource teleportSound;
    public float speed = 0.1f;
    public float minDistance = 2f;
    private bool canFollow = false;
    private bool isCloseWithDave = false;
    private bool isWorried = false;

    public Dialog introTalk;
    public Dialog couchTalk;
    public Dialog leavingTalk;
    public Dialog worriedTalk;

    void Start()
    {
        couchTalk.enabled = false;
        leavingTalk.enabled = false;
        worriedTalk.enabled = false;
        particles.playOnAwake = true;
        Messenger.AddListener("pal-to-couch", TeleportToCouch);
        Messenger.AddListener("pal-enable-couch-talk", EnableCouchTalk);
        Messenger.AddListener("isCloseWithDave", CloseWithDave);
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = target.position;
        if (pos.y - 0.5f < transform.position.y)
        {
            transform.LookAt(pos);
        }
        Worrying();
        Follow();
    }

    void Worrying() {
        if (couchController.isPalOnCouch && isCloseWithDave)
        {
            float distance = getDistance();

            if(distance > 10f)
            {
                Debug.Log("PAL is starting to get worried.");
                ResumeFollowing();
                EnableWorriedTalk();
            }
        }
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
        float randFloat = Random.Range(0f, (float) (sounds.Length - 1));
        int randInt = (int) Mathf.Round(randFloat);
        sounds[randInt].Play();
        canFollow = true;
        if (getDistance() > minDistance * 3f)
        {
            TeleportToTarget();
        }
        couchController.isPalOnCouch = false;
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
        couchController.isPalOnCouch = true;
    }

    void TeleportParticles() {
        teleportSound.Play();
        particles.gameObject.SetActive(false);
        particles.gameObject.SetActive(true);
    }

    float getDistance() {
        return Vector3.Distance(transform.position, target.position);
    }

    void EnableCouchTalk() {
        introTalk.enabled = false;
        leavingTalk.enabled = false;
        worriedTalk.enabled = false;
        couchTalk.enabled = true;
    }

    void EnableWorriedTalk() {
        introTalk.enabled = false;
        leavingTalk.enabled = false;
        worriedTalk.enabled = true;
        couchTalk.enabled = false;
        isWorried = true;
    }

    void CloseWithDave() {
        isCloseWithDave = true;
        //couchTalk.enabled = false;    // causes the dialog not to wrap up interaction correctly (text box remains visible)
    }

    public void SetThreatLevel(int threatLevel)
    {

    }

    public bool getIsWorried()
    {
        return isWorried;
    }
}
