﻿using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;
using System;

[CustomEditor(typeof(Dialog))]
public class DialogEditor : Editor {
	private ReorderableList list;
	Dialog dialog;

	Color dialogColor= new Color (.75f, 1, .75f);
	Color eventColor = new Color (.75f,.75f,1);

	private void OnEnable(){
		dialog = target as Dialog;
		list = new ReorderableList (dialog.dialogs, typeof(DialogElement), true, true, true, true);
		list.elementHeight = EditorGUIUtility.singleLineHeight * 2 + 4;
		list.drawHeaderCallback = (Rect rect) => {
			EditorGUI.LabelField (new Rect (rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight), "dankilog supersystem v4.20 tm (c)");
		};

		list.onAddDropdownCallback = (Rect rect, ReorderableList rl) => {
			GenericMenu menu = new GenericMenu();
			menu.AddItem(new GUIContent("Dialog"),false,OnMenuClick, CreateElement(DialogElement.Type.Dialog));

			menu.AddItem(new GUIContent("Event"),false,OnMenuClick, CreateElement(DialogElement.Type.Event));

			menu.ShowAsContext();
		};

		list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
			DialogElement e = dialog.dialogs[index] as DialogElement;
			DialogElement.Type t = e.type;
			rect.y+=2;
			if(t == DialogElement.Type.Dialog){
				ChangeColor(rect,dialogColor);
				EditorGUI.LabelField(new Rect(rect.x,rect.y,60,EditorGUIUtility.singleLineHeight),"dialog");
				rect.x+=60;
				rect.height = EditorGUIUtility.singleLineHeight*2;
				e.string1 = EditorGUI.TextArea(new Rect(rect.x,rect.y,rect.width-60,rect.height),
					e.string1);
			}else if(t == DialogElement.Type.Event){
				ChangeColor(rect,eventColor);
				EditorGUI.LabelField(new Rect(rect.x,rect.y,60,EditorGUIUtility.singleLineHeight),"event");
				rect.x+=60;
				e.string1 = EditorGUI.TextField(new Rect(rect.x,rect.y,rect.width-60,EditorGUIUtility.singleLineHeight),
					e.string1);
			}
		};
	}

	void ChangeColor(Rect rect, Color c){
		EditorGUI.DrawRect (new Rect (rect.x + 1, rect.y - 1, rect.width - 2, rect.height - 4), c);
	}

	private DialogElement CreateElement(DialogElement.Type t){
		DialogElement e = new DialogElement ();
		e.type = t;
		return e;
	}

	private void OnMenuClick(object target){
		dialog.dialogs.Add (target as DialogElement);
	}

	public override void OnInspectorGUI(){
		serializedObject.Update ();
		list.DoLayoutList ();
		serializedObject.ApplyModifiedProperties ();
		EditorUtility.SetDirty (dialog);
	}
}
