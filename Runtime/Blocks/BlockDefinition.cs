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
using UnityEditor;



namespace VoxelToolbox.Runtime.Blocks
{

	/// <summary>
	/// Provides a static definition of a block
	/// </summary>
	[CreateAssetMenu(menuName = "Voxel/Block")]
	public class BlockDefinition : ScriptableObject {
		/// <summary>
		/// Face names for a cube voxel
		/// </summary>
		public enum CubeFace : byte {
			Left,
			Front,
			Right,
			Back,
			Top,
			Bottom
		}

		[Header("Identity")]
		[SerializeField] string blockName;  // Name of the block
		[SerializeField] int id;         // Unique ID of the block

		[Header("Textures")]
		[SerializeField] Texture2D textureLeft;
		[SerializeField] Texture2D textureFront;
		[SerializeField] Texture2D textureRight;
		[SerializeField] Texture2D textureBack;
		[SerializeField] Texture2D textureTop;
		[SerializeField] Texture2D textureBottom;

		// Accessors
		public string BlockName => blockName;
		public int ID => id;

		/// <summary>
		/// Returns the texture assigned to the specified face
		/// </summary>
		/// <param name="face">Cube face</param>
		/// <returns>Texture</returns>
		public Texture2D GetTexture(CubeFace face) {
			return face switch {
				CubeFace.Left => textureLeft,
				CubeFace.Front => textureFront,
				CubeFace.Right => textureRight,
				CubeFace.Back => textureBack,
				CubeFace.Top => textureTop,
				CubeFace.Bottom => textureBottom,
				_ => null,
			};
		}

		/// <summary>
		/// Updates block fields
		/// </summary>
		private void OnValidate() {
			blockName = this.name;	
		}

		// Editor methods
#if UNITY_EDITOR
		public void SetID(int id) => this.id = id;

		/// <summary>
		/// Sets all faces of a block to the specified texture
		/// </summary>
		public void SetTexture(Texture2D texture) {
			this.textureLeft = texture;
			this.textureFront = texture;
			this.textureRight = texture;
			this.textureBack = texture;
			this.textureTop = texture;
			this.textureBottom = texture;

			EditorUtility.SetDirty(this);
		}

		/// <summary>
		/// Sets the specified block face to a given texture
		/// </summary>
		public void SetTexture(Texture2D texture, CubeFace face) {
			switch (face) {
				case CubeFace.Left:
					this.textureLeft = texture;
					break;

				case CubeFace.Front:
					this.textureFront = texture;
					break;

				case CubeFace.Right:
					this.textureRight = texture;
					break;

				case CubeFace.Back:
					this.textureBack = texture;
					break;

				case CubeFace.Top:
					this.textureTop = texture;
					break;

				case CubeFace.Bottom:
					this.textureBottom = texture;
					break;

				default:
					Debug.LogWarning("Attempted to set texture for invalid face");
					return;
			}

			EditorUtility.SetDirty(this);
		}
#endif
	}

} // namespace VoxelToolbox.Runtime.Blocks
