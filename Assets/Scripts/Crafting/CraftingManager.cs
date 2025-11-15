using UnityEngine;
using System.Collections.Generic;

namespace ChroniclesOfADrifter.Crafting
{
    /// <summary>
    /// Manages crafting system with recipes and crafting stations
    /// </summary>
    public class CraftingManager : MonoBehaviour
    {
        [Header("Recipes")]
        [SerializeField] private List<CraftingRecipe> allRecipes = new List<CraftingRecipe>();
        
        private HashSet<string> unlockedRecipes = new HashSet<string>();
        
        public static CraftingManager Instance { get; private set; }
        
        // Events
        public System.Action<CraftingRecipe> OnRecipeUnlocked;
        public System.Action<CraftingRecipe, int> OnItemCrafted;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                // Silently destroy duplicate instances - this is expected behavior when scenes reload
                // Only log in development builds to avoid console spam
                #if UNITY_EDITOR
                Debug.Log($"[CraftingManager] Duplicate instance found on '{gameObject.name}', destroying. This is normal if scene was reloaded.");
                #endif
                Destroy(gameObject);
                return;
            }
            
            InitializeRecipes();
        }
        
        private void InitializeRecipes()
        {
            // Unlock default recipes
            foreach (var recipe in allRecipes)
            {
                if (recipe.isUnlockedByDefault)
                {
                    UnlockRecipe(recipe.recipeName);
                }
            }
        }
        
        /// <summary>
        /// Unlock a recipe for crafting
        /// </summary>
        public void UnlockRecipe(string recipeName)
        {
            if (unlockedRecipes.Add(recipeName))
            {
                CraftingRecipe recipe = GetRecipeByName(recipeName);
                if (recipe != null)
                {
                    OnRecipeUnlocked?.Invoke(recipe);
                }
            }
        }
        
        /// <summary>
        /// Check if a recipe is unlocked
        /// </summary>
        public bool IsRecipeUnlocked(string recipeName)
        {
            return unlockedRecipes.Contains(recipeName);
        }
        
        /// <summary>
        /// Attempt to craft an item
        /// </summary>
        public bool TryCraft(CraftingRecipe recipe, Components.Inventory inventory)
        {
            if (recipe == null || inventory == null)
                return false;
            
            // Check if recipe is unlocked
            if (!IsRecipeUnlocked(recipe.recipeName))
                return false;
            
            // Build available items dictionary
            Dictionary<string, int> availableItems = new Dictionary<string, int>();
            foreach (var slot in inventory.Slots)
            {
                if (slot != null)
                {
                    if (availableItems.ContainsKey(slot.itemId))
                        availableItems[slot.itemId] += slot.quantity;
                    else
                        availableItems[slot.itemId] = slot.quantity;
                }
            }
            
            // Check if we have enough resources
            if (!recipe.CanCraft(availableItems))
                return false;
            
            // Consume ingredients
            foreach (var ingredient in recipe.ingredients)
            {
                inventory.RemoveItem(ingredient.itemId, ingredient.quantity);
            }
            
            // Add output item
            bool added = inventory.AddItem(recipe.outputItemId, recipe.outputQuantity);
            
            if (added)
            {
                OnItemCrafted?.Invoke(recipe, recipe.outputQuantity);
                return true;
            }
            else
            {
                // Failed to add item (inventory full), return ingredients
                foreach (var ingredient in recipe.ingredients)
                {
                    inventory.AddItem(ingredient.itemId, ingredient.quantity);
                }
                return false;
            }
        }
        
        /// <summary>
        /// Get recipe by name
        /// </summary>
        public CraftingRecipe GetRecipeByName(string recipeName)
        {
            return allRecipes.Find(r => r.recipeName == recipeName);
        }
        
        /// <summary>
        /// Get all unlocked recipes in a category
        /// </summary>
        public List<CraftingRecipe> GetUnlockedRecipesByCategory(CraftingRecipe.RecipeCategory category)
        {
            List<CraftingRecipe> recipes = new List<CraftingRecipe>();
            
            foreach (var recipe in allRecipes)
            {
                if (recipe.category == category && IsRecipeUnlocked(recipe.recipeName))
                {
                    recipes.Add(recipe);
                }
            }
            
            return recipes;
        }
        
        /// <summary>
        /// Get all unlocked recipes
        /// </summary>
        public List<CraftingRecipe> GetAllUnlockedRecipes()
        {
            List<CraftingRecipe> recipes = new List<CraftingRecipe>();
            
            foreach (var recipe in allRecipes)
            {
                if (IsRecipeUnlocked(recipe.recipeName))
                {
                    recipes.Add(recipe);
                }
            }
            
            return recipes;
        }
    }
}
