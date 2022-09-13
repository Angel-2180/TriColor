using UnityEngine;
using System.Collections;
using UnityEditor;

public class AudioEventEditor : MonoBehaviour
{
	/*
	[SerializeField] private AudioSource _previewer;

	public void OnEnable()
	{
		_previewer = EditorUtility.CreateGameObjectWithHideFlags("Audio preview", HideFlags.HideAndDontSave, typeof(AudioSource)).GetComponent<AudioSource>();
	}

	public void OnDisable()
	{
		DestroyImmediate(_previewer.gameObject);
	}
	
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		EditorGUI.BeginDisabledGroup(serializedObject.isEditingMultipleObjects);
		if (GUILayout.Button("Preview"))
		{
			((SO_AudioEvent) target).Play(_previewer);
		}
		EditorGUI.EndDisabledGroup();
	}*/
}
