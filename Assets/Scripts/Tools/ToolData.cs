using UnityEngine;

namespace ChroniclesOfADrifter.Tools
{
    /// <summary>
    /// Scriptable Object that defines a tool type
    /// Tools include: Hoe, Watering Can, Axe, Pickaxe, Sword
    /// </summary>
    [CreateAssetMenu(fileName = "New Tool", menuName = "Chronicles/Tools/Tool")]
    public class ToolData : ScriptableObject
    {
        [Header("Basic Info")]
        public string toolName = "Tool";
        public string description = "A useful tool";
        public Sprite icon;
        public ToolType toolType;
        
        [Header("Stats")]
        public int tier = 1; // 1 = basic, 2 = copper, 3 = iron, 4 = gold, 5 = iridium
        public float useSpeed = 1f; // How fast the tool can be used
        public int damageOrPower = 1; // Damage for combat, power for gathering
        public int staminaCost = 2;
        
        [Header("Visuals")]
        public Sprite[] useAnimationSprites;
        public float animationSpeed = 0.1f;
        
        [Header("Audio")]
        public AudioClip useSound;
        
        public enum ToolType
        {
            Hoe,          // Till soil for farming
            WateringCan,  // Water crops
            Axe,          // Chop trees and wood
            Pickaxe,      // Mine rocks and ore
            Sword,        // Combat weapon
            Scythe,       // Harvest crops and cut grass
            FishingRod,   // Catch fish
            Hammer        // Break rocks and pathways
        }
        
        /// <summary>
        /// Get the tier name for display
        /// </summary>
        public string GetTierName()
        {
            return tier switch
            {
                1 => "Basic",
                2 => "Copper",
                3 => "Iron",
                4 => "Gold",
                5 => "Iridium",
                _ => "Unknown"
            };
        }
    }
}
