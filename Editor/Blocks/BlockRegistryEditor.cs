///====================================================================================================
///
/// @file  BlockRegistryEditor.cs
/// 
/// <summary>
/// Custom editor for BlockRegistry
/// </summary>
/// 
///====================================================================================================
using UnityEngine;
using UnityEditor;
using VoxelToolbox.Runtime.Blocks;



namespace VoxelToolbox.Editor.Blocks
{

	/// <summary>
	/// Custom editor for BlockRegistry
	/// </summary>
	[CustomEditor(typeof(BlockRegistry))]
	public class BlockRegistryEditor : UnityEditor.Editor
    {
		/// <summary>
		/// Updates the editor GUI
		/// </summary>
		public override void OnInspectorGUI() {
			BlockRegistry blockRegistry = (BlockRegistry)target;
			serializedObject.Update();

			// Display base properties
			EditorGUILayout.PropertyField(serializedObject.FindProperty("textureRootDir"));
			EditorGUILayout.PropertyField(serializedObject.FindProperty("blockList"));

			// Actions
			if (GUILayout.Button("Update All")) {
				blockRegistry.UpdateBlockIDs();
				blockRegistry.UpdateBlockTextures();
			}

			serializedObject.ApplyModifiedProperties();
		}
	}

} // namespace VoxelToolbox.Editor.Blocks
