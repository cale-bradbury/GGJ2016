using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.ImageEffects;
using System.Reflection;

[ExecuteInEditMode]
public class LevelData : MonoBehaviour {

	public string levelName = "default level";
	public Material skybox;
	public Color ambientSky;
	public Color ambientEquator;
	public Color ambientGround;
	public Color fogColor;
	public float fogStartDistance;
	public float fogEndDistance;
	public bool constantUpdate = false;
	public Camera postCam;
	public Camera mainCam;
	List<Component> added;


	// Use this for initialization
	void OnEnable () {
		UpdateRenderSettings ();
		UpdateCamera ();
	}

	void OnDisable(){
		RemoveCamera ();
	}

	void UpdateCamera(){
		if (!Application.isPlaying)
			return;
		if (postCam == null||mainCam==null)
			return;
		added = new List<Component> ();
		MonoBehaviour[] fx = postCam.GetComponents<MonoBehaviour> ();
		foreach (MonoBehaviour i in fx) {
			if (i.GetType() != typeof(Camera) && i.GetType() != typeof(Transform)) {
				Component c = Utils.MoveComponent (i, mainCam.gameObject);
				added.Add(c);
				foreach (FieldInfo f in c.GetType().GetFields()){
					if (f.FieldType == typeof(CCReflectFloat)) {
						CCReflectFloat cc = f.GetValue (c) as CCReflectFloat;
						foreach (Component comp in added) {
							if (comp.GetType() == cc.obj.GetType ()) {
								cc.obj = comp;
								break;
							}
						}
						f.SetValue (c, cc);
					}
				}
			}
		}
		PostElevator p = mainCam.gameObject.AddComponent<PostElevator> ();
		p.shader = Shader.Find("Elevator/Post");
		added.Add (p);
		postCam.enabled = false;
	}

	void RemoveCamera(){
		if (mainCam == null)
			return;
		foreach (MonoBehaviour i in added) {
			Destroy (i);
		}
	}

	void UpdateRenderSettings(){
		RenderSettings.skybox = skybox;
		RenderSettings.fogColor = fogColor;
		RenderSettings.fogStartDistance = fogStartDistance;
		RenderSettings.fogEndDistance = fogEndDistance;
		RenderSettings.fogMode = FogMode.Linear;
		RenderSettings.fog = true;
		RenderSettings.ambientSkyColor = ambientSky;
		RenderSettings.ambientEquatorColor = ambientEquator;
		RenderSettings.ambientGroundColor = ambientGround;
		RenderSettings.ambientMode = UnityEngine.Rendering.AmbientMode.Trilight;
	}
	
	// Update is called once per frame
	void Update () {
		if(constantUpdate)UpdateRenderSettings ();
	}

	void OnGUI(){
		UpdateRenderSettings ();
	}
}
