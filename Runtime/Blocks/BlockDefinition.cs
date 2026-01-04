///====================================================================================================
///
/// @file  BlockDefinition.cs
/// 
/// <summary>
/// Provides a static definition of a block
/// </summary>
/// 
///====================================================================================================
using UnityEngine;



namespace VoxelToolbox.Runtime.Blocks
{

	/// <summary>
	/// Provides a static definition of a block
	/// </summary>
	[CreateAssetMenu(menuName = "Voxel/Block")]
	public class BlockDefinition : ScriptableObject
    {
		[Header("Identity")]
		[SerializeField] string blockName;	// Name of the block
		[SerializeField] int id;         // Unique ID of the block

		[Header("Textures")]
		[SerializeField] Texture2D textureLeft;
		[SerializeField] Texture2D textureFront;
		[SerializeField] Texture2D textureRight;
		[SerializeField] Texture2D textureBack;
		[SerializeField] Texture2D textureTop;
		[SerializeField] Texture2D textureBottom;

		// Read-only accessors
		public string BlockName => blockName;
		public int ID => id;

		/// <summary>
		/// Updates block fields
		/// </summary>
		private void OnValidate() {
			blockName = this.name;	
		}

		// Editor methods
#if UNITY_EDITOR
		public void SetID(int id) => this.id = id;
#endif
	}

} // namespace VoxelToolbox.Runtime.Blocks
