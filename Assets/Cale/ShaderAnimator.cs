using UnityEngine;
using System.Collections;

public class ShaderAnimator : MonoBehaviour {

	public AnimationCurve curve;
	public float time;
	public Material mat;
	public GameObject audioHolder;
	AudioSource[] audios;
	float[] values;

	// Use this for initialization
	void OnEnable () {
		Messenger.AddListener ("anim0", A0);
		Messenger.AddListener ("anim1", A1);
		Messenger.AddListener ("anim2", A2);
		Messenger.AddListener ("anim3", A3);
		Messenger.AddListener ("anim4", A4);
		audios = audioHolder.GetComponents<AudioSource> ();
		values = new float[audios.Length];
		for(int i = 0; i<audios.Length;i++){
			values[i] =  .4f;
			audios[i].pitch  = .4f;
		}
	}

	void OnDisable () {
		Messenger.RemoveListener ("anim0", A0);
		Messenger.RemoveListener ("anim1", A1);
		Messenger.RemoveListener ("anim2", A2);
		Messenger.RemoveListener ("anim3", A3);
		Messenger.RemoveListener ("anim4", A4);
	}
	
	// Update is called once per frame
	void A0 () {
		StartCoroutine (Utils.AnimationCoroutine (curve, time, SetA0));
		SetValues ();
	}
	void A1 () {
		StartCoroutine (Utils.AnimationCoroutine (curve, time, SetA1));
		SetValues ();
	}
	void A2 () {
		StartCoroutine (Utils.AnimationCoroutine (curve, time, SetA2));
		SetValues ();
	}
	void A3 () {
		StartCoroutine (Utils.AnimationCoroutine (curve, time, SetA3));
		SetValues ();
	}
	void A4 () {
		StartCoroutine (Utils.AnimationCoroutine (curve, time, SetA4));
		SetValues ();
	}

	void SetValues(){
		for(int i = 0; i<audios.Length;i++){
			values [i] = audios [i].pitch;
		}
	}

	void SetA0(float f){
		Vector4 v = mat.GetVector ("_Form");
		v.y = Mathf.Min (v.y, 1-f);
		v.z = Mathf.Min (v.z, 1-f);
		v.w = Mathf.Min (v.w, 1-f);
		v.x = Mathf.Max (f, v.x);
		audios [0].pitch = Mathf.Lerp (values [0], .5f,f);
		audios [1].pitch = Mathf.Lerp (values [1], .1f,f);
		mat.SetVector ("_Form", v);
	}
	void SetA1(float f){
		Vector4 v = mat.GetVector ("_Form");
		v.x = Mathf.Min (v.x, 1-f);
		v.z = Mathf.Min (v.z, 1-f);
		v.w = Mathf.Min (v.w, 1-f);
		v.y = Mathf.Max (f, v.y);;
		audios [0].pitch = Mathf.Lerp (values [0], .4f,f);
		audios [1].pitch = Mathf.Lerp (values [1], .2f,f);
		mat.SetVector ("_Form", v);
	}
	void SetA2(float f){
		Vector4 v = mat.GetVector ("_Form");
		v.x = Mathf.Min (v.x, 1-f);
		v.y = Mathf.Min (v.y, 1-f);
		v.z = Mathf.Min (v.z, 1-f);
		v.w = Mathf.Min (v.w, 1-f);
		audios [0].pitch = Mathf.Lerp (values [0], .3f,f);
		audios [1].pitch = Mathf.Lerp (values [1], .3f,f);
		mat.SetVector ("_Form", v);
	}
	void SetA3(float f){
		Vector4 v = mat.GetVector ("_Form");
		v.x = Mathf.Min (v.x, 1-f);
		v.y = Mathf.Min (v.y, 1-f);
		v.w = Mathf.Min (v.w, 1-f);
		v.z = Mathf.Max (f, v.z);
		audios [0].pitch = Mathf.Lerp (values [0], .2f,f);
		audios [1].pitch = Mathf.Lerp (values [1], .4f,f);
		mat.SetVector ("_Form", v);
	}
	void SetA4(float f){
		Vector4 v = mat.GetVector ("_Form");
		v.x = Mathf.Min (v.x, 1-f);
		v.y = Mathf.Min (v.y, 1-f);
		v.z = Mathf.Min (v.z, 1-f);
		v.w = Mathf.Max (f, v.z);;
		audios [0].pitch = Mathf.Lerp (values [0], .1f,f);
		audios [1].pitch = Mathf.Lerp (values [1], .5f,f);
		mat.SetVector ("_Form", v);
	}
}
