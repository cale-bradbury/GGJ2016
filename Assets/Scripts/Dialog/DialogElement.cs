using UnityEngine;
using System;
[Serializable]
public class DialogElement{
	public enum Type{
		Dialog,
		Event,
		LookAt,
		Sound
	}
	public Type type;

	public string string1;
	public float float1;

	public Transform transform1;
}