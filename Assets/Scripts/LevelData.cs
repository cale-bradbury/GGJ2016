using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

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
	ImageEffectBase[] fx;

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
		fx = postCam.GetComponents<ImageEffectBase> ();
		foreach (ImageEffectBase i in fx)
			Utils.MoveComponent (i, mainCam.gameObject);
		mainCam.gameObject.AddComponent<PostElevator> ();
		postCam.enabled = false;
	}

	void RemoveCamera(){
		fx = mainCam.GetComponents<ImageEffectBase> ();
		foreach (ImageEffectBase i in fx) {
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
