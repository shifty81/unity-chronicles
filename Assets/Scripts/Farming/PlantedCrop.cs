using UnityEngine;
using UnityEngine.Tilemaps;

namespace ChroniclesOfADrifter.Farming
{
    /// <summary>
    /// Represents a planted crop on a tile
    /// Manages growth, watering, and harvesting
    /// </summary>
    public class PlantedCrop : MonoBehaviour
    {
        [SerializeField] private CropData cropData;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private Vector3Int tilePosition;
        
        private int currentGrowthStage = 0;
        private int daysInCurrentStage = 0;
        private bool isWateredToday = false;
        private bool isFullyGrown = false;
        
        public CropData CropData => cropData;
        public Vector3Int TilePosition => tilePosition;
        public bool IsFullyGrown => isFullyGrown;
        public bool IsWateredToday => isWateredToday;
        
        /// <summary>
        /// Initialize a planted crop
        /// </summary>
        public void Initialize(CropData data, Vector3Int position)
        {
            cropData = data;
            tilePosition = position;
            currentGrowthStage = 0;
            daysInCurrentStage = 0;
            isWateredToday = false;
            
            if (spriteRenderer == null)
                spriteRenderer = GetComponent<SpriteRenderer>();
            
            UpdateSprite();
        }
        
        /// <summary>
        /// Water this crop for the day
        /// </summary>
        public void Water()
        {
            if (!isWateredToday)
            {
                isWateredToday = true;
                // Could add visual effect here
            }
        }
        
        /// <summary>
        /// Called at the end of each day to progress growth
        /// </summary>
        public void OnDayEnd()
        {
            if (isFullyGrown)
            {
                isWateredToday = false;
                return;
            }
            
            // Check if watering requirement is met
            if (cropData.requiresWater && !isWateredToday)
            {
                // Crop doesn't grow today
                isWateredToday = false;
                return;
            }
            
            // Progress growth
            daysInCurrentStage++;
            
            // Check if we should advance to next stage
            if (currentGrowthStage < cropData.growthStageDays.Length)
            {
                if (daysInCurrentStage >= cropData.growthStageDays[currentGrowthStage])
                {
                    currentGrowthStage++;
                    daysInCurrentStage = 0;
                    UpdateSprite();
                    
                    // Check if fully grown
                    if (currentGrowthStage >= cropData.growthStageDays.Length)
                    {
                        isFullyGrown = true;
                    }
                }
            }
            
            isWateredToday = false;
        }
        
        /// <summary>
        /// Harvest this crop and return harvest data
        /// </summary>
        public HarvestResult Harvest()
        {
            if (!isFullyGrown)
                return null;
            
            int quantity = Random.Range(cropData.harvestQuantityMin, cropData.harvestQuantityMax + 1);
            
            HarvestResult result = new HarvestResult
            {
                itemId = cropData.harvestItemId,
                quantity = quantity
            };
            
            // Handle regrowth
            if (cropData.regrowsAfterHarvest)
            {
                // Reset to regrowth stage
                currentGrowthStage = Mathf.Max(0, cropData.growthStageDays.Length - 1);
                daysInCurrentStage = 0;
                isFullyGrown = false;
                UpdateSprite();
            }
            else
            {
                // Destroy this crop
                Destroy(gameObject);
            }
            
            return result;
        }
        
        private void UpdateSprite()
        {
            if (spriteRenderer != null && cropData != null && cropData.growthStageSprites != null)
            {
                int spriteIndex = Mathf.Min(currentGrowthStage, cropData.growthStageSprites.Length - 1);
                if (spriteIndex >= 0 && spriteIndex < cropData.growthStageSprites.Length)
                {
                    spriteRenderer.sprite = cropData.growthStageSprites[spriteIndex];
                }
            }
        }
        
        public class HarvestResult
        {
            public string itemId;
            public int quantity;
        }
    }
}
