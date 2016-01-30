using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;
using System;

[CustomEditor(typeof(Dialog))]
public class DialogEditor : Editor {
	private ReorderableList list;
	Dialog dialog;

	private void OnEnable(){
		dialog = target as Dialog;
		list = new ReorderableList (dialog.dialogs, typeof(DialogElement), true, true, true, true);

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
				EditorGUI.LabelField(new Rect(rect.x,rect.y,60,EditorGUIUtility.singleLineHeight),"dialog");
				rect.x+=60;
				e.string1 = EditorGUI.TextField(new Rect(rect.x,rect.y,60,EditorGUIUtility.singleLineHeight),
					e.string1);
			}else if(t == DialogElement.Type.Event){
				EditorGUI.LabelField(new Rect(rect.x,rect.y,60,EditorGUIUtility.singleLineHeight),"event");
				rect.x+=60;
				e.string1 = EditorGUI.TextField(new Rect(rect.x,rect.y,60,EditorGUIUtility.singleLineHeight),
					e.string1);
			}
		};
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
