using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;

[ExecuteInEditMode]
public class PreElevator : ImageEffectBase {

	[HideInInspector]
	public RenderTexture pure;

	// Called by camera to apply image effect
	void OnRenderImage (RenderTexture source, RenderTexture destination) {
		if (pure == null || pure.width != source.width || pure.height != source.height){
			DestroyImmediate(pure);
			pure = new RenderTexture(source.width, source.height, 0,RenderTextureFormat.ARGB32);
			pure.hideFlags = HideFlags.HideAndDontSave;
		}
		Graphics.Blit (source, destination);
		Graphics.Blit (source, pure);
	}
}
