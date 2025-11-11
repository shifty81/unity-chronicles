# Placeholder Assets Documentation

## Overview

This document describes the placeholder assets that have been generated for the Chronicles of a Drifter Unity project. These assets provide a foundation for testing and development while proper artwork is being created.

## Generated Assets

### Directory Structure

```
Assets/
├── Materials/                    # Empty, ready for material assets
├── Prefabs/                      # Empty, ready for prefab assets
│   ├── Characters/
│   ├── Enemies/
│   ├── Items/
│   └── UI/
├── ScriptableObjects/            # Game data assets
│   ├── Crops/                    # 4 crop definitions
│   ├── NPCs/                     # 3 NPC definitions
│   ├── Recipes/                  # 3 crafting recipes
│   └── Tools/                    # 6 tool definitions
└── Sprites/                      # Placeholder sprite images
    ├── Characters/               # 4 character sprites
    ├── Items/                    # 11 item sprites
    ├── Tiles/                    # 6 tile sprites
    └── UI/Icons/                 # 6 tool icons
```

### Sprite Assets (27 total)

All sprites are 32x32 pixel solid-color PNG images optimized for pixel-art games.

#### Tile Sprites (6)
- **grass_tile.png** - Green (51, 153, 51) - Base terrain
- **dirt_tile.png** - Brown (153, 102, 51) - Farmable soil
- **tilled_dirt.png** - Dark brown (127, 76, 38) - Prepared farmland
- **watered_dirt.png** - Darker brown (102, 64, 25) - Watered farmland
- **stone_tile.png** - Gray (127, 127, 127) - Stone pathways
- **water_tile.png** - Blue (51, 102, 204) - Water areas

#### Crop Growth Stages (4)
- **crop_stage1.png** - Light green (204, 230, 179) - Seedling
- **crop_stage2.png** - Medium green (127, 204, 102) - Growing
- **crop_stage3.png** - Dark green (76, 179, 76) - Almost mature
- **crop_stage4.png** - Red (230, 76, 76) - Mature/harvestable

#### Tool Icons (6)
- **hoe_icon.png** - Brown (153, 102, 51)
- **watering_can_icon.png** - Light blue (102, 153, 204)
- **axe_icon.png** - Gray (127, 127, 127)
- **pickaxe_icon.png** - Light gray (153, 153, 153)
- **sword_icon.png** - Silver (204, 204, 230)
- **scythe_icon.png** - Gray (179, 179, 179)

#### Item Icons (7)
- **tomato_icon.png** - Red (230, 51, 51)
- **wheat_icon.png** - Yellow (230, 204, 102)
- **carrot_icon.png** - Orange (230, 127, 51)
- **potato_icon.png** - Tan (179, 153, 102)
- **wood_icon.png** - Brown (153, 102, 51)
- **stone_icon.png** - Gray (127, 127, 127)
- **iron_ore_icon.png** - Dark gray (102, 76, 76)

#### Character Sprites (4)
- **player_placeholder.png** - Blue (76, 127, 230)
- **npc_farmer.png** - Brown (179, 127, 76)
- **npc_merchant.png** - Purple (153, 76, 179)
- **npc_blacksmith.png** - Dark gray (76, 76, 76)

### ScriptableObject Assets (16 total)

#### Crops (4)

**Crop_Tomato.asset**
- Name: Tomato
- Growth: 8 days (2+2+2+2)
- Seasons: Spring, Summer
- Harvest: 1-3 tomatoes
- Regrows: Yes (3 days)
- Seed Price: 50g, Sell Price: 100g

**Crop_Wheat.asset**
- Name: Wheat
- Growth: 8 days (3+3+2)
- Seasons: Spring, Fall
- Harvest: 1 wheat
- Regrows: No
- Seed Price: 30g, Sell Price: 60g

**Crop_Carrot.asset**
- Name: Carrot
- Growth: 7 days (2+2+3)
- Seasons: Spring
- Harvest: 1-2 carrots
- Regrows: No
- Seed Price: 40g, Sell Price: 80g

**Crop_Potato.asset**
- Name: Potato
- Growth: 9 days (3+3+3)
- Seasons: Spring
- Harvest: 2-4 potatoes
- Regrows: No
- Seed Price: 60g, Sell Price: 100g

#### Tools (6)

**Tool_Hoe.asset**
- Type: Hoe (till soil)
- Tier: 1 (Basic)
- Power: 1, Stamina: 2

**Tool_WateringCan.asset**
- Type: Watering Can (water crops)
- Tier: 1 (Basic)
- Power: 1, Stamina: 2

**Tool_Axe.asset**
- Type: Axe (chop wood)
- Tier: 1 (Basic)
- Power: 5, Stamina: 4

**Tool_Pickaxe.asset**
- Type: Pickaxe (mine rocks)
- Tier: 1 (Basic)
- Power: 5, Stamina: 4

**Tool_Sword.asset**
- Type: Sword (combat)
- Tier: 1 (Basic)
- Power: 10, Stamina: 3

**Tool_Scythe.asset**
- Type: Scythe (harvest/cut grass)
- Tier: 1 (Basic)
- Power: 1, Stamina: 2

#### Recipes (3)

**Recipe_WoodPlank.asset**
- Name: Wood Plank
- Category: Materials
- Input: 1 wood
- Output: 4 wood planks
- Unlocked by default

**Recipe_StoneBlock.asset**
- Name: Stone Block
- Category: Materials
- Input: 5 stone
- Output: 1 stone block
- Unlocked by default

**Recipe_BasicChest.asset**
- Name: Basic Chest
- Category: Furniture
- Input: 20 wood
- Output: 1 chest
- Unlocked by default

#### NPCs (3)

**NPC_Bob_Farmer.asset**
- Name: Bob
- Title: Farmer
- Birthday: Spring 15
- Personality: Friendly and helpful
- Dialogue: 3 farming-related messages

**NPC_Sarah_Merchant.asset**
- Name: Sarah
- Title: Merchant
- Birthday: Summer 22
- Personality: Business-minded but fair
- Dialogue: 3 merchant-related messages

**NPC_Marcus_Blacksmith.asset**
- Name: Marcus
- Title: Blacksmith
- Birthday: Fall 3
- Personality: Gruff but kindhearted
- Dialogue: 3 blacksmith-related messages

## Unity Import Settings

All sprite textures are configured with the following import settings:
- **Texture Type**: Sprite (2D and UI)
- **Sprite Mode**: Single
- **Pixels Per Unit**: 16 (optimized for pixel art)
- **Filter Mode**: Point (no filter) - maintains sharp pixel art look
- **Compression**: None (best quality for placeholders)
- **Max Size**: 2048

## Usage in Unity

### Viewing Assets

1. Open the Unity Editor
2. Navigate to the **Project** window
3. Browse to `Assets/ScriptableObjects/` to see game data
4. Browse to `Assets/Sprites/` to see placeholder images

### Testing Crops

1. Open a scene with a FarmingManager component
2. Assign one of the Crop assets (e.g., Crop_Tomato) to test
3. Call FarmingManager methods to plant, water, and harvest

### Testing Tools

1. Create a script to reference ToolData assets
2. Assign Tool assets to test different tool types
3. Use tool properties (power, stamina cost, etc.) in gameplay

### Testing Recipes

1. Open the CraftingManager
2. Load Recipe assets to test crafting system
3. Verify ingredient checking and output generation

### Testing NPCs

1. Create NPC GameObjects in a scene
2. Assign NPCData assets to NPC components
3. Test dialogue systems and NPC interactions

## Replacing Placeholders

To replace placeholder assets with final artwork:

### Sprites
1. Create or import final sprite artwork
2. Import with same settings (Sprite 2D, 16 PPU, Point filter)
3. Replace references in ScriptableObject assets
4. Delete old placeholder sprites

### ScriptableObjects
1. Keep existing .asset files (they contain game data)
2. Update sprite references to point to new artwork
3. Adjust values (growth times, prices, etc.) as needed
4. Add additional crops, tools, recipes, or NPCs as needed

## Generation Scripts

The following Python scripts were used to generate these assets:

1. **generate_placeholder_assets.py** - Created folder structure and PNG sprites
2. **generate_meta_files.py** - Created Unity .meta files for proper import
3. **generate_scriptableobjects.py** - Created ScriptableObject .asset files

These scripts are available in `/tmp/` if regeneration is needed.

## Next Steps

1. **Test in Unity Editor** - Open project and verify all assets load correctly
2. **Create Prefabs** - Build prefabs using the placeholder sprites
3. **Build UI** - Use placeholder icons in inventory and tool UI
4. **Set up Tilemaps** - Use tile sprites to create test levels
5. **Connect Systems** - Link ScriptableObjects to game managers
6. **Replace Art** - Gradually replace placeholders with final artwork

## Notes

- All sprites use solid colors for easy identification
- Colors are chosen to visually represent their function (green for grass, brown for dirt, etc.)
- ScriptableObject assets have minimal but functional data
- Sprite references in ScriptableObjects are currently null and need manual assignment in Unity
- All assets follow the project's naming conventions
- .meta files ensure Unity recognizes and imports assets correctly

## File Count Summary

- **Sprites**: 27 PNG files + 27 .meta files = 54 files
- **Folders**: 13 directories + 13 .meta files = 26 files
- **ScriptableObjects**: 16 .asset files + 16 .meta files = 32 files
- **Total**: 112 asset-related files

---

**Last Updated**: 2025-11-11
**Unity Version**: 6.0 LTS (6000.0.27f1)
**Project**: Chronicles of a Drifter
