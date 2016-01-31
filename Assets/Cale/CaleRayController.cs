using UnityEngine;
using System.Collections;

public class CaleRayController : MonoBehaviour {

	public Material mat;
	public Transform player;
	public Transform camera;
	Vector4 v;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		v = mat.GetVector ("_Camera");
		v.x = player.position.x;
		v.y = player.position.y;
		v.z = player.position.z;
		mat.SetVector("_Camera",v*-1);
		v = mat.GetVector ("_CameraAngle");
		v.x = camera.position.x-player.position.x;
		v.y = camera.position.y-player.position.y;
		v.z = camera.position.z-player.position.z;
		mat.SetVector("_CameraAngle",v*-1);
	}
}
