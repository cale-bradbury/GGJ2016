using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class FieldMultiCompile : MonoBehaviour {

	public enum Style{
		sphere,
		cross2,
		cross1 ,
		cube,
		hex,
		tie,
		tri
	}

	public Style style = Style.sphere;
	public Material mat;

	// Use this for initialization
	void Set () {
		foreach(string s in mat.shaderKeywords)
			mat.DisableKeyword (s);
		mat.EnableKeyword (style.ToString ().ToLower());
		Debug.Log (style.ToString ().ToLower());
	}
	
	// Update is called once per frame
	void OnGUI () {
		Set ();
	}

	void OnEnable(){
		Set ();
	}
}
