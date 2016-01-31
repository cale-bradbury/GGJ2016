using UnityEngine;
using System.Collections;

public class CaleRayController : MonoBehaviour {

	public Material[] mat;
	public Transform player;
	public Transform camera;
	Vector4 v;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		v = mat[0].GetVector ("_Camera");
		v.x = player.position.x;
		v.y = -player.position.y;
		v.z = player.position.z;

		float a = -Mathf.Atan2 (v.z, v.x)+Mathf.PI;
		float d = Vector2.Distance (Vector2.zero, new Vector2 (v.z, v.x));
		v.x = Mathf.Cos (a) * d;
		v.z = Mathf.Sin (a) * d;

		foreach(Material m in mat){
			m.SetVector("_Camera",v);
		}

		v = mat[0].GetVector ("_CameraAngle");
		v.x = camera.position.x-player.position.x;
		v.y = camera.position.y-player.position.y;
		v.z = camera.position.z-player.position.z;

		a = -Mathf.Atan2 (v.z, v.x);
		d = Vector2.Distance (Vector2.zero, new Vector2 (v.z, v.x));
		v.x = Mathf.Cos (a) * d;
		v.z = Mathf.Sin (a) * d;

		foreach(Material m in mat){
			m.SetVector("_CameraAngle",v);
		}
	}
}
