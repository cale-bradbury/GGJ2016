using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections;
using System;

[CustomEditor(typeof(Dialog))]
public class DialogEditor : Editor {
	private ReorderableList list;

	private void OnEnable(){
		list = new ReorderableList (serializedObject, serializedObject.FindProperty ("dialogs"), true, true, true, true);

		list.onAddDropdownCallback = (Rect rect, ReorderableList rl) => {
			GenericMenu menu = new GenericMenu();
			menu.AddItem(new GUIContent("Dialog"),false,OnMenuClick, new TextElement());

			menu.AddItem(new GUIContent("Event"),false,OnMenuClick, new EventElement());


			menu.ShowAsContext();
		};



		list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
			var element = list.serializedProperty.GetArrayElementAtIndex(index);
			rect.y+=2;
			EditorGUI.PropertyField(
				new Rect(rect.x,rect.y,60,EditorGUIUtility.singleLineHeight),
				element.FindPropertyRelative("dialog"),
				GUIContent.none
			);
		};
	}

	private void OnMenuClick(object target){
		Type t = target.GetType ();
	}

	public override void OnInspectorGUI(){
		serializedObject.Update ();
		list.DoLayoutList ();
		serializedObject.ApplyModifiedProperties ();
	}
}
