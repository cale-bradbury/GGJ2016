using UnityEngine;
using System.Collections;

public class ElevatorButton : MonoBehaviour {

    public int levelKey;
    public Color litColor;
    public Color unlitColor;
    Renderer rend;
    public AnimationCurve curve;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.material.color = unlitColor;
    }

	// Use this for initialization
	public void Press () {

        rend.material.color = litColor;
        StartCoroutine(Utils.AnimationCoroutine(curve,.5f,Move));
    }

    public void Revert()
    {
        rend.material.color = unlitColor;
        StopAllCoroutines();
        Move(0);
    }


	// Update is called once per frame
	void Move (float f) {
        Vector3 v = transform.localPosition;
        v.z = f;
        transform.localPosition = v;
	}
}
