using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace UnityEditor.Tilemaps
{
    /// <summary>
    /// Abstract base class for Tile Templates.
    /// Template used to create TileBase assets from Texture2D and Sprites.
    /// This class provides the missing base class that AutoTileTemplate and RuleTileTemplate
    /// in Unity's com.unity.2d.tilemap.extras package expect but is not included in the package.
    /// </summary>
    public abstract class TileTemplate : ScriptableObject
    {
        /// <summary>
        /// Creates a List of TileBase Assets from Texture2D and Sprites 
        /// with placement data onto a Tile Palette.
        /// </summary>
        /// <param name="texture2D">The source Texture2D to generate tiles from</param>
        /// <param name="sprites">The sprites extracted from the texture</param>
        /// <param name="tilesToAdd">The list of tile change data to populate</param>
        public abstract void CreateTileAssets(
            Texture2D texture2D,
            IEnumerable<Sprite> sprites,
            ref List<TileChangeData> tilesToAdd);
    }
}
