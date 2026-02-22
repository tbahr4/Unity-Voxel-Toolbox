///====================================================================================================
///
/// @file  BlockRegistry.cs
/// 
/// <summary>
/// Registers blocks to their definitions
/// </summary>
/// 
///====================================================================================================
using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using VoxelToolbox.Editor.Utils;



namespace VoxelToolbox.Runtime.Blocks {

	/// <summary>
	/// Registers blocks to their definitions
	/// </summary>
	[CreateAssetMenu(menuName = "Voxel/Block Registry")]
	public class BlockRegistry : ScriptableObject
    {
		[SerializeField] DefaultAsset textureRootDir;		// Root folder of block textures
		[SerializeField] List<BlockDefinition> blockList;   // Exposed block registration list

		/// <summary>
		/// Retrieves the definition of the block with specified ID
		/// </summary>
		/// <param name="id">Block ID</param>
		/// <returns></returns>
		//public static BlockDefinition GetDefinition(ushort id) {
		//	if (mBlockIDMap == null) {
		//		throw new NullReferenceException("Attempted to retrieve definition prior to initialization");
		//	}

		//	mBlockIDMap.TryGetValue(id, out var blockDef);
		//	return blockDef;
		//}

#if UNITY_EDITOR
		/// <summary>
		/// Updates registered block IDs
		/// </summary>
		public void UpdateBlockIDs() {
			for (int blockIdx = 0; blockIdx < blockList.Count; blockIdx++) {
				BlockDefinition block = blockList[blockIdx];
				int newID = blockIdx + 1;

				// Set ID
				if (block.ID != newID) {
					block.SetID(newID);
					EditorUtility.SetDirty(block);
				}
			}
		}

		/// <summary>
		/// Updates registered block texture fields
		/// </summary>
		public void UpdateBlockTextures() {
			int sideCount = Enum.GetNames(typeof(BlockDefinition.CubeFace)).Length;
			var textures = AssetUtils.LoadTexturesFromFolder(textureRootDir);

			for (int blockIdx = 0; blockIdx < blockList.Count; blockIdx++) {
				BlockDefinition block = blockList[blockIdx];
				string blockName = block.BlockName.ToLower();

				//===================================================
				// Check for <BLOCK_NAME> texture
				//===================================================
				Texture2D newTexture;
				textures.TryGetValue(blockName, out newTexture);

				if (newTexture != null) {
					block.SetTexture(newTexture);
					continue;
				}

				//===================================================
				// Check for <BLOCK_NAME_FACE> textures
				//===================================================
				Dictionary<BlockDefinition.CubeFace, Texture2D> textureSides = new();

				// Attempt all 6 sides
				string textureName;
				foreach (BlockDefinition.CubeFace face in Enum.GetValues(typeof(BlockDefinition.CubeFace))) {
					textureName = blockName + "_" + face.ToString().ToLower();
					textures.TryGetValue(textureName, out newTexture);

					if (newTexture != null) {
						textureSides[face] = newTexture;
					}
				}

				if (textureSides.Count == sideCount) {
					continue;
				}

				// Attempt to retrive other definitions
				textureName = blockName + "_side";
				textures.TryGetValue(textureName, out newTexture);

				if (newTexture != null) {
					textureSides[BlockDefinition.CubeFace.Left] = newTexture;
					textureSides[BlockDefinition.CubeFace.Front] = newTexture;
					textureSides[BlockDefinition.CubeFace.Right] = newTexture;
					textureSides[BlockDefinition.CubeFace.Back] = newTexture;
				}

				//===================================================
				// Store textures
				//===================================================
				block.SetTexture(null); // Reset block to base texture

				foreach(BlockDefinition.CubeFace face in Enum.GetValues(typeof(BlockDefinition.CubeFace))) {
					Texture2D texture;
					textureSides.TryGetValue(face, out texture);

					if (texture != null) {
						block.SetTexture(texture, face);
					}
				}
			}
		}
#endif

	}

} // namespace VoxelToolbox.Runtime.Blocks
