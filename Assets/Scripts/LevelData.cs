using UnityEngine;
using System.Collections;

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

	// Use this for initialization
	void OnEnable () {
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
		if(constantUpdate)OnEnable ();
	}

	void OnGUI(){
		OnEnable ();
	}
}
