using UnityEngine;
using System.Collections.Generic;

namespace ChroniclesOfADrifter.Crafting
{
    /// <summary>
    /// Scriptable Object that defines a crafting recipe
    /// Similar to Stardew Valley and Core Keeper crafting
    /// </summary>
    [CreateAssetMenu(fileName = "New Recipe", menuName = "Chronicles/Crafting/Recipe")]
    public class CraftingRecipe : ScriptableObject
    {
        [Header("Basic Info")]
        public string recipeName = "Recipe";
        public string description = "Craft something useful";
        public Sprite icon;
        public RecipeCategory category;
        
        [Header("Requirements")]
        public List<Ingredient> ingredients = new List<Ingredient>();
        public int craftingTime = 0; // Seconds, 0 = instant
        public string requiredCraftingStation = ""; // Empty = can craft anywhere
        
        [Header("Output")]
        public string outputItemId;
        public int outputQuantity = 1;
        
        [Header("Unlock")]
        public bool isUnlockedByDefault = false;
        public int requiredLevel = 0;
        public string unlockCondition = ""; // Quest ID or special condition
        
        public enum RecipeCategory
        {
            Equipment,
            Tools,
            Building,
            Furniture,
            Consumables,
            Materials,
            Seeds,
            Other
        }
        
        [System.Serializable]
        public class Ingredient
        {
            public string itemId;
            public int quantity;
            
            public Ingredient(string id, int qty)
            {
                itemId = id;
                quantity = qty;
            }
        }
        
        /// <summary>
        /// Check if the recipe can be crafted with given resources
        /// </summary>
        public bool CanCraft(Dictionary<string, int> availableItems)
        {
            foreach (var ingredient in ingredients)
            {
                if (!availableItems.ContainsKey(ingredient.itemId))
                    return false;
                
                if (availableItems[ingredient.itemId] < ingredient.quantity)
                    return false;
            }
            
            return true;
        }
    }
}
