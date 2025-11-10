using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

namespace ChroniclesOfADrifter.Farming
{
    /// <summary>
    /// Manages the farming system including tilling, planting, watering, and harvesting
    /// Core mechanic inspired by Stardew Valley
    /// </summary>
    public class FarmingManager : MonoBehaviour
    {
        [Header("Tilemaps")]
        [SerializeField] private Tilemap groundTilemap;
        [SerializeField] private Tilemap farmTilemap;
        
        [Header("Tiles")]
        [SerializeField] private TileBase tilledSoilTile;
        [SerializeField] private TileBase wateredSoilTile;
        
        [Header("Prefabs")]
        [SerializeField] private GameObject cropPrefab;
        
        private Dictionary<Vector3Int, TileData> farmTiles = new Dictionary<Vector3Int, TileData>();
        private Dictionary<Vector3Int, PlantedCrop> plantedCrops = new Dictionary<Vector3Int, PlantedCrop>();
        
        public static FarmingManager Instance { get; private set; }
        
        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);
        }
        
        /// <summary>
        /// Till a tile to make it ready for planting
        /// </summary>
        public bool TillSoil(Vector3Int tilePosition)
        {
            // Check if tile is valid for tilling
            if (!CanTillTile(tilePosition))
                return false;
            
            // Create farm tile data
            if (!farmTiles.ContainsKey(tilePosition))
            {
                farmTiles[tilePosition] = new TileData
                {
                    position = tilePosition,
                    isTilled = true,
                    isWatered = false
                };
            }
            else
            {
                farmTiles[tilePosition].isTilled = true;
            }
            
            // Update visual
            if (farmTilemap != null && tilledSoilTile != null)
            {
                farmTilemap.SetTile(tilePosition, tilledSoilTile);
            }
            
            return true;
        }
        
        /// <summary>
        /// Water a tilled tile
        /// </summary>
        public bool WaterTile(Vector3Int tilePosition)
        {
            if (!farmTiles.ContainsKey(tilePosition) || !farmTiles[tilePosition].isTilled)
                return false;
            
            farmTiles[tilePosition].isWatered = true;
            
            // Update visual
            if (farmTilemap != null && wateredSoilTile != null)
            {
                farmTilemap.SetTile(tilePosition, wateredSoilTile);
            }
            
            // Water crop if present
            if (plantedCrops.ContainsKey(tilePosition))
            {
                plantedCrops[tilePosition].Water();
            }
            
            return true;
        }
        
        /// <summary>
        /// Plant a seed on a tilled tile
        /// </summary>
        public bool PlantSeed(Vector3Int tilePosition, CropData cropData)
        {
            // Check if tile is tilled and has no crop
            if (!farmTiles.ContainsKey(tilePosition) || !farmTiles[tilePosition].isTilled)
                return false;
            
            if (plantedCrops.ContainsKey(tilePosition))
                return false; // Already has a crop
            
            // Create crop instance
            if (cropPrefab != null)
            {
                Vector3 worldPosition = farmTilemap.CellToWorld(tilePosition) + new Vector3(0.5f, 0.5f, 0);
                GameObject cropObj = Instantiate(cropPrefab, worldPosition, Quaternion.identity, transform);
                PlantedCrop crop = cropObj.GetComponent<PlantedCrop>();
                
                if (crop != null)
                {
                    crop.Initialize(cropData, tilePosition);
                    plantedCrops[tilePosition] = crop;
                    return true;
                }
            }
            
            return false;
        }
        
        /// <summary>
        /// Harvest a crop at the given position
        /// </summary>
        public PlantedCrop.HarvestResult HarvestCrop(Vector3Int tilePosition)
        {
            if (!plantedCrops.ContainsKey(tilePosition))
                return null;
            
            PlantedCrop crop = plantedCrops[tilePosition];
            if (!crop.IsFullyGrown)
                return null;
            
            PlantedCrop.HarvestResult result = crop.Harvest();
            
            // Remove from dictionary if destroyed
            if (crop == null || crop.gameObject == null)
            {
                plantedCrops.Remove(tilePosition);
            }
            
            return result;
        }
        
        /// <summary>
        /// Called at the end of each day to progress all crops
        /// </summary>
        public void OnDayEnd()
        {
            // Progress all crops
            foreach (var crop in plantedCrops.Values)
            {
                crop.OnDayEnd();
            }
            
            // Reset watered state for all tiles
            foreach (var tileData in farmTiles.Values)
            {
                if (tileData.isWatered)
                {
                    tileData.isWatered = false;
                    // Update visual back to tilled soil
                    if (farmTilemap != null && tilledSoilTile != null)
                    {
                        farmTilemap.SetTile(tileData.position, tilledSoilTile);
                    }
                }
            }
        }
        
        /// <summary>
        /// Check if a tile can be tilled
        /// </summary>
        private bool CanTillTile(Vector3Int tilePosition)
        {
            // Check if there's ground at this position
            if (groundTilemap == null)
                return true;
            
            TileBase groundTile = groundTilemap.GetTile(tilePosition);
            return groundTile != null;
        }
        
        /// <summary>
        /// Get crop at position
        /// </summary>
        public PlantedCrop GetCropAt(Vector3Int tilePosition)
        {
            if (plantedCrops.ContainsKey(tilePosition))
                return plantedCrops[tilePosition];
            return null;
        }
        
        /// <summary>
        /// Check if tile is tilled
        /// </summary>
        public bool IsTilled(Vector3Int tilePosition)
        {
            return farmTiles.ContainsKey(tilePosition) && farmTiles[tilePosition].isTilled;
        }
        
        [System.Serializable]
        private class TileData
        {
            public Vector3Int position;
            public bool isTilled;
            public bool isWatered;
        }
    }
}
