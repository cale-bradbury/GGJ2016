using UnityEngine;
using System.Collections;

public class CouchController : MonoBehaviour {

    private bool isPlayerOnCouch = false;
    public bool isPalOnCouch = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player enter couch");
            isPlayerOnCouch = true;
        }

        if(isPlayerOnCouch && isPalOnCouch)
        {
            // trigger anim float for RGB rotate
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player exit couch");
            isPlayerOnCouch = false;
        }
    }
}
