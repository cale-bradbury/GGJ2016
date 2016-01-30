using UnityEngine;
using System.Collections;

public class ccEventSetScene : ccEventBase {

	public string sceneName;

	protected override void OnEvent ()
	{
		base.OnEvent ();
		Application.LoadLevel (sceneName);
	}
}
