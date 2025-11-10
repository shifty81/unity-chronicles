using UnityEngine;

namespace ChroniclesOfADrifter
{
    /// <summary>
    /// Game-wide constants for Chronicles of a Drifter.
    /// These values are used throughout the game for consistency and scale reference.
    /// </summary>
    public static class GameConstants
    {
        #region Player Character Dimensions
        
        /// <summary>
        /// The height of the player character in Unity units (blocks).
        /// This is approximately 2.5 blocks tall, which serves as the scale reference 
        /// for all game elements, terrain features, and procedurally generated content.
        /// </summary>
        public const float PlayerHeightInBlocks = 2.5f;
        
        /// <summary>
        /// The width of the player character in Unity units (blocks).
        /// This represents the collision box width and is used for pathfinding and doorway sizing.
        /// </summary>
        public const float PlayerWidthInBlocks = 0.8f;
        
        /// <summary>
        /// The default collision box height for the player.
        /// This should be slightly smaller than the sprite height for better game feel.
        /// </summary>
        public const float PlayerCollisionHeight = 2.5f;
        
        /// <summary>
        /// The default collision box width for the player.
        /// This should be narrower than the visual sprite for smoother navigation.
        /// </summary>
        public const float PlayerCollisionWidth = 0.8f;
        
        #endregion
        
        #region World/Block Dimensions
        
        /// <summary>
        /// The size of a single block in Unity units (1 Unity unit = 1 block).
        /// All world measurements are based on this block size.
        /// </summary>
        public const float BlockSize = 1f;
        
        /// <summary>
        /// Chunk width in blocks
        /// </summary>
        public const int ChunkWidth = 32;
        
        /// <summary>
        /// Chunk height in blocks
        /// </summary>
        public const int ChunkHeight = 30;
        
        #endregion
        
        #region Movement
        
        /// <summary>
        /// Default player movement speed in blocks per second
        /// </summary>
        public const float DefaultPlayerSpeed = 5.0f;
        
        /// <summary>
        /// Swimming speed multiplier
        /// </summary>
        public const float SwimSpeedMultiplier = 0.6f;
        
        #endregion
        
        #region Combat
        
        /// <summary>
        /// Default player maximum health
        /// </summary>
        public const float DefaultPlayerMaxHealth = 100f;
        
        /// <summary>
        /// Default enemy health
        /// </summary>
        public const float DefaultEnemyHealth = 50f;
        
        #endregion
    }
}
