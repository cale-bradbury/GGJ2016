using UnityEngine;
using System.Collections;

public class ShaderAnimator : MonoBehaviour {

	public AnimationCurve curve;
	public float time;
	public Material mat;

	// Use this for initialization
	void OnEnable () {
		Messenger.AddListener ("anim0", A0);
		Messenger.AddListener ("anim1", A1);
		Messenger.AddListener ("anim2", A2);
		Messenger.AddListener ("anim3", A3);
		Messenger.AddListener ("anim4", A4);
	}
	void OnDisable () {

	}
	
	// Update is called once per frame
	void A0 () {
		StartCoroutine (Utils.AnimationCoroutine (curve, time, SetA0));
	}
	void A1 () {
		StartCoroutine (Utils.AnimationCoroutine (curve, time, SetA1));
	}
	void A2 () {
		StartCoroutine (Utils.AnimationCoroutine (curve, time, SetA2));
	}
	void A3 () {
		StartCoroutine (Utils.AnimationCoroutine (curve, time, SetA3));
	}
	void A4 () {
		StartCoroutine (Utils.AnimationCoroutine (curve, time, SetA4));
	}

	void SetA0(float f){
		Vector4 v = mat.GetVector ("_Form");
		v.y = Mathf.Min (v.y, 1-f);
		v.z = Mathf.Min (v.z, 1-f);
		v.w = Mathf.Min (v.w, 1-f);
		v.x = f;
		mat.SetVector ("_Form", v);
	}
	void SetA1(float f){
		Vector4 v = mat.GetVector ("_Form");
		v.x = Mathf.Min (v.x, 1-f);
		v.z = Mathf.Min (v.z, 1-f);
		v.w = Mathf.Min (v.w, 1-f);
		v.y = f;
		mat.SetVector ("_Form", v);
	}
	void SetA2(float f){
		Vector4 v = mat.GetVector ("_Form");
		v.x = Mathf.Min (v.x, 1-f);
		v.y = Mathf.Min (v.y, 1-f);
		v.z = Mathf.Min (v.z, 1-f);
		v.w = Mathf.Min (v.w, 1-f);
		mat.SetVector ("_Form", v);
	}
	void SetA3(float f){
		Vector4 v = mat.GetVector ("_Form");
		v.x = Mathf.Min (v.x, 1-f);
		v.y = Mathf.Min (v.y, 1-f);
		v.w = Mathf.Min (v.w, 1-f);
		v.z = f;
		mat.SetVector ("_Form", v);
	}
	void SetA4(float f){
		Vector4 v = mat.GetVector ("_Form");
		v.x = Mathf.Min (v.x, 1-f);
		v.y = Mathf.Min (v.y, 1-f);
		v.z = Mathf.Min (v.z, 1-f);
		v.w = f;
		mat.SetVector ("_Form", v);
	}
}
