///====================================================================================================
///
/// @file  AssetUtils.cs
/// 
/// <summary>
/// Editor utilities relating to assets
/// </summary>
/// 
///====================================================================================================
#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



namespace VoxelToolbox.Editor.Utils
{
    public static class AssetUtils
    {
		
		/// <summary>
		/// Loads all textures from the provided folder into a dictionary
		/// </summary>
		/// <param name="folder">Folder to scan for assets</param>
		/// <returns>Dictionary mapping from name to texture</returns>
		public static Dictionary<string, Texture2D> LoadTexturesFromFolder(DefaultAsset folder) {
			var textures = new Dictionary<string, Texture2D>();

			if (folder == null) {
				return textures;
			}

			string path = AssetDatabase.GetAssetPath(folder);
			string[] guids = AssetDatabase.FindAssets("t:Texture2D", new[] { path });

			foreach (string guid in guids) {
				string assetPath = AssetDatabase.GUIDToAssetPath(guid);
				Texture2D texture = AssetDatabase.LoadAssetAtPath<Texture2D>(assetPath);

				if (texture != null) {
					textures[texture.name] = texture;
				}
			}

			return textures;
		}

	}

} // namespace VoxelToolbox.Editor.Utils
#endif
