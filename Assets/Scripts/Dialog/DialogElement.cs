using UnityEngine;
using System;
[Serializable]
public class DialogElement{
	public enum Type{
		Dialog,
		Event
	}
	public Type type;
	public string string1;
}