using UnityEngine;
using System.Collections;

public class CaleRayController : MonoBehaviour {

	public Material[] mat;
	public Transform player;
	public Transform cameraTransform;
	Vector4 v;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		v = mat[0].GetVector ("_Camera");
		Vector3 p = player.position*.1f;

		v.x = p.x;
		v.y = -p.y;
		v.z = p.z;

		float a = -Mathf.Atan2 (v.z, v.x)+Mathf.PI;
		float d = Vector2.Distance (Vector2.zero, new Vector2 (v.z, v.x));
		v.x = Mathf.Cos (a) * d;
		v.z = Mathf.Sin (a) * d;

		foreach(Material m in mat){
			m.SetVector("_Camera",v);
		}

		v = mat[0].GetVector ("_CameraAngle");
		v.x = cameraTransform.position.x-p.x;
		v.y = cameraTransform.position.y-p.y;
		v.z = cameraTransform.position.z-p.z;

		a = -Mathf.Atan2 (v.z, v.x);
		d = Vector2.Distance (Vector2.zero, new Vector2 (v.z, v.x));
		v.x = Mathf.Cos (a) * d;
		v.z = Mathf.Sin (a) * d;

		foreach(Material m in mat){
			m.SetVector("_CameraAngle",v);
		}
	}
}
