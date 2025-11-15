using UnityEngine;
using UnityEditor;
using System.IO;
using ChroniclesOfADrifter.Farming;
using ChroniclesOfADrifter.Tools;
using ChroniclesOfADrifter.Crafting;
using ChroniclesOfADrifter.NPC;

namespace ChroniclesOfADrifter.Editor
{
    /// <summary>
    /// Editor utility to generate placeholder assets for the Chronicles of a Drifter project
    /// Creates folders, sprites, and ScriptableObject instances
    /// </summary>
    public static class PlaceholderAssetGenerator
    {
        private const string ASSETS_ROOT = "Assets";
        
        [MenuItem("Chronicles/Generate Placeholder Assets")]
        public static void GeneratePlaceholderAssets()
        {
            Debug.Log("Starting placeholder asset generation...");
            
            // Create folder structure
            CreateFolderStructure();
            
            // Generate placeholder sprites
            GeneratePlaceholderSprites();
            
            // Create ScriptableObject instances
            CreateCrops();
            CreateTools();
            CreateRecipes();
            CreateNPCs();
            
            // Refresh the asset database
            AssetDatabase.Refresh();
            
            Debug.Log("Placeholder asset generation complete!");
            EditorUtility.DisplayDialog("Success", "Placeholder assets have been generated successfully!", "OK");
        }
        
        private static void CreateFolderStructure()
        {
            Debug.Log("Creating folder structure...");
            
            // ScriptableObjects
            CreateFolder("ScriptableObjects");
            CreateFolder("ScriptableObjects/Crops");
            CreateFolder("ScriptableObjects/Tools");
            CreateFolder("ScriptableObjects/Recipes");
            CreateFolder("ScriptableObjects/NPCs");
            
            // Sprites
            CreateFolder("Sprites");
            CreateFolder("Sprites/Characters");
            CreateFolder("Sprites/Tiles");
            CreateFolder("Sprites/Items");
            CreateFolder("Sprites/UI");
            CreateFolder("Sprites/UI/Icons");
            
            // Prefabs
            CreateFolder("Prefabs");
            CreateFolder("Prefabs/Characters");
            CreateFolder("Prefabs/Enemies");
            CreateFolder("Prefabs/Items");
            CreateFolder("Prefabs/UI");
            
            // Materials
            CreateFolder("Materials");
            
            Debug.Log("Folder structure created.");
        }
        
        private static void CreateFolder(string folderPath)
        {
            string fullPath = Path.Combine(ASSETS_ROOT, folderPath);
            if (!AssetDatabase.IsValidFolder(fullPath))
            {
                string parentFolder = Path.GetDirectoryName(fullPath);
                string folderName = Path.GetFileName(fullPath);
                AssetDatabase.CreateFolder(parentFolder, folderName);
            }
        }
        
        private static void GeneratePlaceholderSprites()
        {
            Debug.Log("Generating placeholder sprites...");
            
            // Tile sprites
            CreateColoredTexture("Sprites/Tiles/grass_tile.png", new Color(0.2f, 0.6f, 0.2f)); // Green
            CreateColoredTexture("Sprites/Tiles/dirt_tile.png", new Color(0.6f, 0.4f, 0.2f)); // Brown
            CreateColoredTexture("Sprites/Tiles/tilled_dirt.png", new Color(0.5f, 0.3f, 0.15f)); // Dark brown
            CreateColoredTexture("Sprites/Tiles/watered_dirt.png", new Color(0.4f, 0.25f, 0.1f)); // Darker brown
            CreateColoredTexture("Sprites/Tiles/stone_tile.png", new Color(0.5f, 0.5f, 0.5f)); // Gray
            CreateColoredTexture("Sprites/Tiles/water_tile.png", new Color(0.2f, 0.4f, 0.8f)); // Blue
            
            // Crop sprites (4 growth stages)
            CreateColoredTexture("Sprites/Items/crop_stage1.png", new Color(0.8f, 0.9f, 0.7f)); // Light green - seedling
            CreateColoredTexture("Sprites/Items/crop_stage2.png", new Color(0.5f, 0.8f, 0.4f)); // Medium green - growing
            CreateColoredTexture("Sprites/Items/crop_stage3.png", new Color(0.3f, 0.7f, 0.3f)); // Darker green - almost ready
            CreateColoredTexture("Sprites/Items/crop_stage4.png", new Color(0.9f, 0.3f, 0.3f)); // Red - mature/harvest
            
            // Tool icons
            CreateColoredTexture("Sprites/UI/Icons/hoe_icon.png", new Color(0.6f, 0.4f, 0.2f)); // Brown
            CreateColoredTexture("Sprites/UI/Icons/watering_can_icon.png", new Color(0.4f, 0.6f, 0.8f)); // Light blue
            CreateColoredTexture("Sprites/UI/Icons/axe_icon.png", new Color(0.5f, 0.5f, 0.5f)); // Gray
            CreateColoredTexture("Sprites/UI/Icons/pickaxe_icon.png", new Color(0.6f, 0.6f, 0.6f)); // Light gray
            CreateColoredTexture("Sprites/UI/Icons/sword_icon.png", new Color(0.8f, 0.8f, 0.9f)); // Silver
            CreateColoredTexture("Sprites/UI/Icons/scythe_icon.png", new Color(0.7f, 0.7f, 0.7f)); // Gray
            
            // Item icons
            CreateColoredTexture("Sprites/Items/tomato_icon.png", new Color(0.9f, 0.2f, 0.2f)); // Red
            CreateColoredTexture("Sprites/Items/wheat_icon.png", new Color(0.9f, 0.8f, 0.4f)); // Yellow
            CreateColoredTexture("Sprites/Items/carrot_icon.png", new Color(0.9f, 0.5f, 0.2f)); // Orange
            CreateColoredTexture("Sprites/Items/potato_icon.png", new Color(0.7f, 0.6f, 0.4f)); // Tan
            CreateColoredTexture("Sprites/Items/wood_icon.png", new Color(0.6f, 0.4f, 0.2f)); // Brown
            CreateColoredTexture("Sprites/Items/stone_icon.png", new Color(0.5f, 0.5f, 0.5f)); // Gray
            CreateColoredTexture("Sprites/Items/iron_ore_icon.png", new Color(0.4f, 0.3f, 0.3f)); // Dark gray
            
            // Character placeholders
            CreateColoredTexture("Sprites/Characters/player_placeholder.png", new Color(0.3f, 0.5f, 0.9f)); // Blue
            CreateColoredTexture("Sprites/Characters/npc_farmer.png", new Color(0.7f, 0.5f, 0.3f)); // Brown
            CreateColoredTexture("Sprites/Characters/npc_merchant.png", new Color(0.6f, 0.3f, 0.7f)); // Purple
            CreateColoredTexture("Sprites/Characters/npc_blacksmith.png", new Color(0.3f, 0.3f, 0.3f)); // Dark gray
            
            Debug.Log("Placeholder sprites generated.");
        }
        
        private static void CreateColoredTexture(string path, Color color)
        {
            string fullPath = Path.Combine(ASSETS_ROOT, path);
            string directory = Path.GetDirectoryName(fullPath);
            
            // Ensure directory exists
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            
            // Create a 32x32 texture with the specified color
            Texture2D texture = new Texture2D(32, 32);
            Color[] pixels = new Color[32 * 32];
            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = color;
            }
            texture.SetPixels(pixels);
            texture.Apply();
            
            // Save as PNG
            byte[] bytes = texture.EncodeToPNG();
            File.WriteAllBytes(fullPath, bytes);
            
            // Clean up
            DestroyImmediate(texture);
        }
        
        private static void CreateCrops()
        {
            Debug.Log("Creating crop ScriptableObjects...");
            
            // Tomato
            CreateCrop("Crop_Tomato", "Tomato", "A juicy red tomato. Grows in Spring and Summer.",
                new int[] { 2, 2, 2, 2 }, // 8 days total
                new Season[] { Season.Spring, Season.Summer },
                "tomato", 1, 3, true, 3, 50, 100);
            
            // Wheat
            CreateCrop("Crop_Wheat", "Wheat", "Golden wheat for making flour. Grows in Spring and Fall.",
                new int[] { 3, 3, 2 }, // 8 days total
                new Season[] { Season.Spring, Season.Fall },
                "wheat", 1, 1, false, 0, 30, 60);
            
            // Carrot
            CreateCrop("Crop_Carrot", "Carrot", "A crunchy orange carrot. Grows in Spring.",
                new int[] { 2, 2, 3 }, // 7 days total
                new Season[] { Season.Spring },
                "carrot", 1, 2, false, 0, 40, 80);
            
            // Potato
            CreateCrop("Crop_Potato", "Potato", "A versatile potato. Grows in Spring.",
                new int[] { 3, 3, 3 }, // 9 days total
                new Season[] { Season.Spring },
                "potato", 2, 4, false, 0, 60, 100);
            
            Debug.Log("Crop ScriptableObjects created.");
        }
        
        private static void CreateCrop(string fileName, string cropName, string description,
            int[] growthDays, Season[] seasons, string harvestId, int minYield, int maxYield,
            bool regrows, int regrowDays, int seedPrice, int sellPrice)
        {
            CropData crop = ScriptableObject.CreateInstance<CropData>();
            crop.cropName = cropName;
            crop.description = description;
            crop.growthStageDays = growthDays;
            crop.validSeasons = seasons;
            crop.harvestItemId = harvestId;
            crop.harvestQuantityMin = minYield;
            crop.harvestQuantityMax = maxYield;
            crop.regrowsAfterHarvest = regrows;
            crop.regrowthDays = regrowDays;
            crop.seedPrice = seedPrice;
            crop.sellPrice = sellPrice;
            crop.requiresWater = true;
            crop.requiresTilling = true;
            
            // Load placeholder sprites
            Sprite[] stageSprites = new Sprite[4];
            for (int i = 0; i < 4; i++)
            {
                stageSprites[i] = LoadSprite($"Sprites/Items/crop_stage{i + 1}.png");
            }
            crop.growthStageSprites = stageSprites;
            crop.icon = LoadSprite($"Sprites/Items/{harvestId}_icon.png");
            
            string path = $"Assets/ScriptableObjects/Crops/{fileName}.asset";
            AssetDatabase.CreateAsset(crop, path);
        }
        
        private static void CreateTools()
        {
            Debug.Log("Creating tool ScriptableObjects...");
            
            CreateTool("Tool_Hoe", "Hoe", "Basic hoe for tilling soil.", ToolData.ToolType.Hoe, 1, 1.0f, 1, 2, "hoe_icon.png");
            CreateTool("Tool_WateringCan", "Watering Can", "Basic watering can for watering crops.", ToolData.ToolType.WateringCan, 1, 1.0f, 1, 2, "watering_can_icon.png");
            CreateTool("Tool_Axe", "Axe", "Basic axe for chopping wood.", ToolData.ToolType.Axe, 1, 0.8f, 5, 4, "axe_icon.png");
            CreateTool("Tool_Pickaxe", "Pickaxe", "Basic pickaxe for mining.", ToolData.ToolType.Pickaxe, 1, 0.8f, 5, 4, "pickaxe_icon.png");
            CreateTool("Tool_Sword", "Sword", "Basic sword for combat.", ToolData.ToolType.Sword, 1, 1.2f, 10, 3, "sword_icon.png");
            CreateTool("Tool_Scythe", "Scythe", "Basic scythe for harvesting.", ToolData.ToolType.Scythe, 1, 1.0f, 1, 2, "scythe_icon.png");
            
            Debug.Log("Tool ScriptableObjects created.");
        }
        
        private static void CreateTool(string fileName, string toolName, string description,
            ToolData.ToolType toolType, int tier, float useSpeed, int power, int staminaCost, string iconFile)
        {
            ToolData tool = ScriptableObject.CreateInstance<ToolData>();
            tool.toolName = toolName;
            tool.description = description;
            tool.toolType = toolType;
            tool.tier = tier;
            tool.useSpeed = useSpeed;
            tool.damageOrPower = power;
            tool.staminaCost = staminaCost;
            tool.icon = LoadSprite($"Sprites/UI/Icons/{iconFile}");
            
            string path = $"Assets/ScriptableObjects/Tools/{fileName}.asset";
            AssetDatabase.CreateAsset(tool, path);
        }
        
        private static void CreateRecipes()
        {
            Debug.Log("Creating recipe ScriptableObjects...");
            
            // Wood Plank recipe
            var woodPlankRecipe = ScriptableObject.CreateInstance<CraftingRecipe>();
            woodPlankRecipe.recipeName = "Wood Plank";
            woodPlankRecipe.description = "Process raw wood into planks.";
            woodPlankRecipe.category = CraftingRecipe.RecipeCategory.Materials;
            woodPlankRecipe.ingredients.Add(new CraftingRecipe.Ingredient("wood", 1));
            woodPlankRecipe.outputItemId = "wood_plank";
            woodPlankRecipe.outputQuantity = 4;
            woodPlankRecipe.isUnlockedByDefault = true;
            woodPlankRecipe.icon = LoadSprite("Sprites/Items/wood_icon.png");
            AssetDatabase.CreateAsset(woodPlankRecipe, "Assets/ScriptableObjects/Recipes/Recipe_WoodPlank.asset");
            
            // Stone Block recipe
            var stoneBlockRecipe = ScriptableObject.CreateInstance<CraftingRecipe>();
            stoneBlockRecipe.recipeName = "Stone Block";
            stoneBlockRecipe.description = "Craft stones into building blocks.";
            stoneBlockRecipe.category = CraftingRecipe.RecipeCategory.Materials;
            stoneBlockRecipe.ingredients.Add(new CraftingRecipe.Ingredient("stone", 5));
            stoneBlockRecipe.outputItemId = "stone_block";
            stoneBlockRecipe.outputQuantity = 1;
            stoneBlockRecipe.isUnlockedByDefault = true;
            stoneBlockRecipe.icon = LoadSprite("Sprites/Items/stone_icon.png");
            AssetDatabase.CreateAsset(stoneBlockRecipe, "Assets/ScriptableObjects/Recipes/Recipe_StoneBlock.asset");
            
            // Basic Chest recipe
            var chestRecipe = ScriptableObject.CreateInstance<CraftingRecipe>();
            chestRecipe.recipeName = "Basic Chest";
            chestRecipe.description = "A simple wooden chest for storage.";
            chestRecipe.category = CraftingRecipe.RecipeCategory.Furniture;
            chestRecipe.ingredients.Add(new CraftingRecipe.Ingredient("wood", 20));
            chestRecipe.outputItemId = "chest_basic";
            chestRecipe.outputQuantity = 1;
            chestRecipe.isUnlockedByDefault = true;
            chestRecipe.icon = LoadSprite("Sprites/Items/wood_icon.png");
            AssetDatabase.CreateAsset(chestRecipe, "Assets/ScriptableObjects/Recipes/Recipe_BasicChest.asset");
            
            Debug.Log("Recipe ScriptableObjects created.");
        }
        
        private static void CreateNPCs()
        {
            Debug.Log("Creating NPC ScriptableObjects...");
            
            // Farmer NPC
            var farmer = ScriptableObject.CreateInstance<NPCData>();
            farmer.npcName = "Bob";
            farmer.description = "A friendly local farmer who knows everything about crops.";
            farmer.biography = "Friendly and helpful, loves talking about farming. Bob has been farming in this region for over 20 years.";
            farmer.birthday = "Spring 15";
            farmer.dialogueSets = new System.Collections.Generic.List<NPCData.DialogueSet>
            {
                new NPCData.DialogueSet
                {
                    context = "default",
                    dialogueLines = new string[] { 
                        "Hello there! Nice day for farming, isn't it?",
                        "Have you tried growing tomatoes? They're great in summer!",
                        "Make sure to water your crops every day!" 
                    }
                }
            };
            farmer.portrait = LoadSprite("Sprites/Characters/npc_farmer.png");
            AssetDatabase.CreateAsset(farmer, "Assets/ScriptableObjects/NPCs/NPC_Bob_Farmer.asset");
            
            // Merchant NPC
            var merchant = ScriptableObject.CreateInstance<NPCData>();
            merchant.npcName = "Sarah";
            merchant.description = "A traveling merchant who sells seeds and tools.";
            merchant.biography = "Business-minded but fair, always ready to trade. Sarah travels between villages bringing goods from distant lands.";
            merchant.birthday = "Summer 22";
            merchant.dialogueSets = new System.Collections.Generic.List<NPCData.DialogueSet>
            {
                new NPCData.DialogueSet
                {
                    context = "default",
                    dialogueLines = new string[] { 
                        "Welcome! Take a look at my wares!",
                        "I've got the finest seeds in the region!",
                        "Need any tools? I've got you covered!" 
                    }
                }
            };
            merchant.portrait = LoadSprite("Sprites/Characters/npc_merchant.png");
            AssetDatabase.CreateAsset(merchant, "Assets/ScriptableObjects/NPCs/NPC_Sarah_Merchant.asset");
            
            // Blacksmith NPC
            var blacksmith = ScriptableObject.CreateInstance<NPCData>();
            blacksmith.npcName = "Marcus";
            blacksmith.description = "The village blacksmith who can upgrade your tools.";
            blacksmith.biography = "Gruff but kindhearted, takes pride in his work. Marcus learned blacksmithing from his father and grandfather.";
            blacksmith.birthday = "Fall 3";
            blacksmith.dialogueSets = new System.Collections.Generic.List<NPCData.DialogueSet>
            {
                new NPCData.DialogueSet
                {
                    context = "default",
                    dialogueLines = new string[] { 
                        "Need your tools upgraded? I can help with that.",
                        "Bring me ore and I'll make you something special.",
                        "My forge is always hot and ready!" 
                    }
                }
            };
            blacksmith.portrait = LoadSprite("Sprites/Characters/npc_blacksmith.png");
            AssetDatabase.CreateAsset(blacksmith, "Assets/ScriptableObjects/NPCs/NPC_Marcus_Blacksmith.asset");
            
            Debug.Log("NPC ScriptableObjects created.");
        }
        
        private static Sprite LoadSprite(string path)
        {
            // This will return null during initial generation since sprites haven't been imported yet
            // They'll be assigned properly after AssetDatabase.Refresh()
            return AssetDatabase.LoadAssetAtPath<Sprite>($"Assets/{path}");
        }
    }
}
