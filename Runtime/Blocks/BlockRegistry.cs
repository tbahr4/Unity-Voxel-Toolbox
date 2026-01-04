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

		/// <summary>
		/// Updates registry fields
		/// </summary>
		private void OnValidate() {
			for (int blockIdx = 0; blockIdx < blockList.Count; blockIdx++) {
				BlockDefinition block = blockList[blockIdx];
				int newID = blockIdx + 1;

				if (block.ID != newID) {
					block.SetID(newID);
					EditorUtility.SetDirty(block);
				}
			}
		}
	}

} // namespace VoxelToolbox.Runtime.Blocks
