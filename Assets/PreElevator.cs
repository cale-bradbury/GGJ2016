using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

[ExecuteInEditMode]
public class PreElevator : ImageEffectBase {

	RenderTexture pure;

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		Graphics.Blit (source, destination,material);
		//Graphics.Blit (source, pure);
	}
}
