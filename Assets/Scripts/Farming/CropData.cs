using UnityEngine;

namespace ChroniclesOfADrifter.Farming
{
    /// <summary>
    /// Scriptable Object that defines a crop type
    /// Similar to Stardew Valley's crop system
    /// </summary>
    [CreateAssetMenu(fileName = "New Crop", menuName = "Chronicles/Farming/Crop")]
    public class CropData : ScriptableObject
    {
        [Header("Basic Info")]
        public string cropName = "Crop";
        public string description = "A basic crop";
        public Sprite icon;
        
        [Header("Growth")]
        public int[] growthStageDays; // Days required for each stage
        public Sprite[] growthStageSprites; // Sprite for each growth stage
        
        [Header("Requirements")]
        public bool requiresWater = true;
        public bool requiresTilling = true;
        public Season[] validSeasons;
        
        [Header("Harvest")]
        public string harvestItemId;
        public int harvestQuantityMin = 1;
        public int harvestQuantityMax = 1;
        public bool regrowsAfterHarvest = false;
        public int regrowthDays = 0;
        
        [Header("Purchase")]
        public int seedPrice = 50;
        public int sellPrice = 100;
        
        public enum Season
        {
            Spring,
            Summer,
            Fall,
            Winter,
            AllSeasons
        }
        
        /// <summary>
        /// Get the total days to maturity
        /// </summary>
        public int TotalGrowthDays
        {
            get
            {
                int total = 0;
                foreach (int days in growthStageDays)
                {
                    total += days;
                }
                return total;
            }
        }
        
        /// <summary>
        /// Check if this crop can grow in the given season
        /// </summary>
        public bool CanGrowInSeason(Season season)
        {
            foreach (Season validSeason in validSeasons)
            {
                if (validSeason == Season.AllSeasons || validSeason == season)
                    return true;
            }
            return false;
        }
    }
}
