///====================================================================================================
///
/// @file  MathUtils.cs
/// 
/// <summary>
/// Provides common mathematical utilities
/// </summary>
/// 
///====================================================================================================
using System;
using UnityEngine;



namespace VoxelToolbox.Runtime.Utilities
{

	/// <summary>
	/// Provides common mathematical utilities
	/// </summary>
	public static class MathUtils
    {

		/// <summary>
		/// Defines the storage ordering for a flat representation of a 3D array
		/// </summary>
		public enum Array3DStorageOrder {
			XYZ,
			XZY,
			YXZ,
			YZX,
			ZXY,
			ZYX
		}

		/// <summary>
		/// Converts 3D coordinates to a flat index from a given flat array
		/// </summary>
		/// <param name="x">X coordinate</param>
		/// <param name="y">Y coordinate</param>
		/// <param name="z">Z coordinate</param>
		/// <param name="width">X width of array</param>
		/// <param name="height">Y height of array</param>
		/// <param name="depth">Z depth of array</param>
		/// <param name="order">Storage order of increasing array index</param>
		/// <returns>Flat index in array</returns>
		public static int FlattenIndex3D(int x, int y, int z, int width, int height, int depth, Array3DStorageOrder order = Array3DStorageOrder.XYZ) {
			switch (order) {
				case Array3DStorageOrder.XYZ: return x + y * width + z * width * height;
				case Array3DStorageOrder.XZY: return x + z * width + y * width * depth;
				case Array3DStorageOrder.YXZ: return y + x * height + z * width * height;
				case Array3DStorageOrder.YZX: return y + z * height + x * height * depth;
				case Array3DStorageOrder.ZXY: return z + x * depth + y * width * depth;
				case Array3DStorageOrder.ZYX: return z + y * depth + x * height * depth;
				default: throw new ArgumentException("Invalid array storage order");
			}
		}

		/// <summary>
		/// Converts flat index from a given flat array to 3D coordinates
		/// </summary>
		/// <param name="index">Flat index in array</param>
		/// <param name="width">X width of array</param>
		/// <param name="height">Y height of array</param>
		/// <param name="depth">Z depth of array</param>
		/// <param name="order">Storage order of increasing array index</param>
		/// <returns>3D coordinates relative to array</returns>
		public static Vector3Int UnflattenIndex3D(int index, int width, int height, int depth, Array3DStorageOrder order = Array3DStorageOrder.XYZ) {
			switch (order) {
				case Array3DStorageOrder.XYZ: {
					int z = index / (width * height);
					int rem = index % (width * height);
					int y = rem / width;
					int x = rem % width;
					return new Vector3Int(x, y, z);
				}
				case Array3DStorageOrder.XZY: {
					int y = index / (width * depth);
					int rem = index % (width * depth);
					int z = rem / width;
					int x = rem % width;
					return new Vector3Int(x, y, z);
				}
				case Array3DStorageOrder.YXZ: {
					int z = index / (width * height);
					int rem = index % (width * height);
					int x = rem / height;
					int y = rem % height;
					return new Vector3Int(x, y, z);
				}
				case Array3DStorageOrder.YZX: {
					int x = index / (height * depth);
					int rem = index % (height * depth);
					int z = rem / height;
					int y = rem % height;
					return new Vector3Int(x, y, z);
				}
				case Array3DStorageOrder.ZXY: {
					int y = index / (width * depth);
					int rem = index % (width * depth);
					int x = rem / depth;
					int z = rem % depth;
					return new Vector3Int(x, y, z);
				}
				case Array3DStorageOrder.ZYX: {
					int x = index / (height * depth);
					int rem = index % (height * depth);
					int y = rem / depth;
					int z = rem % depth;
					return new Vector3Int(x, y, z);
				}
				default: throw new ArgumentException("Invalid array storage order");
			}
		}

    }

} // namespace VoxelToolbox.Runtime.Utilities
