using UnityEngine;
using System.Collections;

public class PalWarning : MonoBehaviour {

    public PalController pal;
    public int threatLevel;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && pal.getIsWorried())
        {
            Debug.Log("Set threat level: " + threatLevel);
            pal.SetThreatLevel(threatLevel);
        }
    }
}
