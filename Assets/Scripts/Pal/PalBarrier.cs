using UnityEngine;
using System.Collections;

public class PalBarrier : MonoBehaviour {
    public PalController pal;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player enter Pal barrier");
            pal.StopFollowing();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player exit Pal barrier");
            pal.ResumeFollowing();
        }
    }
}
