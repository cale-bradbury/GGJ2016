using UnityEngine;
using System;
[Serializable]
public class DialogElement{
	
}

public class TextElement:DialogElement{
	public string dialog;
}
public class EventElement:DialogElement{
	public string eventName;
}
