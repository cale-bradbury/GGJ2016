using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

[ExecuteInEditMode]
public class PostElevator : ImageEffectBase {

	PreElevator pre;

	void OnEnable(){
		pre = GetComponent<PreElevator>();
	}

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		Graphics.Blit (source, destination);
	}
}
