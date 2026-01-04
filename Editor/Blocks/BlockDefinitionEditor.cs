///====================================================================================================
///
/// @file  BlockDefinitionEditor.cs
/// 
/// <summary>
/// Custom editor for BlockDefinition
/// </summary>
/// 
///====================================================================================================
using UnityEngine;
using UnityEditor;
using VoxelToolbox.Runtime.Blocks;



namespace VoxelToolbox.Editor.Blocks
{

	/// <summary>
	/// Custom editor for BlockDefinition
	/// </summary>
	[CustomEditor(typeof(BlockDefinition))]
	public class BlockDefinitionEditor : UnityEditor.Editor
    {
		/// <summary>
		/// Updates the editor GUI
		/// </summary>
		public override void OnInspectorGUI() {
			BlockDefinition block = (BlockDefinition)target;
			serializedObject.Update();

			// Display read-only properties
			EditorGUILayout.HelpBox("Data is auto-populated from the registry", MessageType.Info);

			GUI.enabled = false;
			EditorGUILayout.PropertyField(serializedObject.FindProperty("blockName"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("id"));

			EditorGUILayout.PropertyField(serializedObject.FindProperty("textureLeft"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("textureFront"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("textureRight"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("textureBack"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("textureTop"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("textureBottom"));
			GUI.enabled = true;

			serializedObject.ApplyModifiedProperties();
		}
	}

} // namespace VoxelToolbox.Editor.Blocks
