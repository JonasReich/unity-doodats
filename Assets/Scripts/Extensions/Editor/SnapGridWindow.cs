﻿//-------------------------------------------
// (c) 2017 - Jonas Reich
//-------------------------------------------

using UnityEditor;
using UnityEngine;

namespace UnityDoodats.Editor
{
// ignore "TransformGridComponent is obsolete" warning
// -> my own warning to prohibit misuse and bugs
#pragma warning disable 0618
	public class SnapGridWindow : UnityEditor.EditorWindow
	{
		//-------------------------------------
		// This class only contains the GUI
		//
		// All the runtime logic apart from creation/destruction 
		// is handled in SnapGridComponent
		//-------------------------------------

		[MenuItem("Tools/Snap Grid")]
		private static void ShowWindow ()
		{
			var window = GetWindow<SnapGridWindow>("Grid");
			window.Show();
		}

		private void OnEnable ()
		{
			ShowGrid();
		}

		private void OnDisable ()
		{
			HideGrid();
		}

		private static void ShowGrid()
		{
			SnapGridComponent.red = new Color(219f / 255f, 62f / 255f, 29f / 255f, 237f / 255f);
			SnapGridComponent.green = new Color(154f / 255f, 243f / 255f, 72f / 255f, 237f / 255f);
			SnapGridComponent.blue = new Color(58f / 255f, 122f / 255f, 248f / 255f, 237f / 255f);
			
			if (SnapGridComponent.instance != null)
				GameObject.DestroyImmediate(SnapGridComponent.instance.transform.parent.gameObject);

			var go_parent = new GameObject("Transform Grid Parent");
			go_parent.hideFlags = HideFlags.HideInHierarchy | HideFlags.DontSave;

			var go = new GameObject("Transform Grid");
			go.transform.SetParent(go_parent.transform);
			go.hideFlags = HideFlags.DontSave;

			SnapGridComponent.instance = go.AddComponent<SnapGridComponent>();

			SceneView.RepaintAll();
		}
		
		private static void HideGrid ()
		{
			if (SnapGridComponent.instance != null)
				GameObject.DestroyImmediate(SnapGridComponent.instance.transform.parent.gameObject);

			SnapGridComponent.instance = null;

			SceneView.RepaintAll();
		}
		
		private void OnGUI ()
		{
			GUI.color = Color.white;
			
			//-------------------------------------
			// XYZ Buttons
			//-------------------------------------
			GUILayout.BeginVertical();

			GUI.backgroundColor = SnapGridComponent.showX ? SnapGridComponent.red : Color.grey;
			if (GUILayout.Button("X"))
			{
				SnapGridComponent.showX = !SnapGridComponent.showX;
				SceneView.RepaintAll();
			}
			GUI.backgroundColor = SnapGridComponent.showY ? SnapGridComponent.green : Color.grey;
			if (GUILayout.Button("Y"))
			{
				SnapGridComponent.showY = !SnapGridComponent.showY;
				SceneView.RepaintAll();
			}
			GUI.backgroundColor = SnapGridComponent.showZ ? SnapGridComponent.blue : Color.grey;
			if (GUILayout.Button("Z"))
			{
				SnapGridComponent.showZ = !SnapGridComponent.showZ;
				SceneView.RepaintAll();
			}

			//-------------------------------------
			// Snap Selected
			//-------------------------------------

			GUI.backgroundColor = Color.white;
			if (GUILayout.Button("Snap selected"))
				SnapGridComponent.SnapToGrid();

			//-------------------------------------
			// Auto Snap
			//-------------------------------------

			SnapGridComponent.autoSnap = GUILayout.Toggle(SnapGridComponent.autoSnap, "Auto Snap");

			//-------------------------------------
			// End of window...
			//-------------------------------------

			GUILayout.BeginHorizontal();
			GUILayout.EndHorizontal();
			EditorGUILayout.EndVertical();
		}
#pragma warning restore 0618
	}
}
