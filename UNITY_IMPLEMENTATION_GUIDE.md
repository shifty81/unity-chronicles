# Unity Chronicles - Implementation Guide

## Overview

Chronicles of a Drifter has been successfully converted to Unity with comprehensive game systems inspired by Zelda, Stardew Valley, and Core Keeper.

## Project Structure

```
Assets/
├── Scripts/
│   ├── Components/          # Core MonoBehaviour components
│   │   ├── Health.cs
│   │   ├── PlayerController.cs
│   │   ├── EnemyAI.cs
│   │   ├── Inventory.cs
│   │   └── CameraFollow.cs
│   ├── Farming/            # Stardew Valley-inspired farming system
│   │   ├── CropData.cs      # Scriptable Object for crop definitions
│   │   ├── PlantedCrop.cs   # Individual planted crop behavior
│   │   └── FarmingManager.cs # Handles tilling, planting, watering
│   ├── Tools/              # Tool system (hoe, axe, pickaxe, etc.)
│   │   └── ToolData.cs
│   ├── Crafting/           # Recipe-based crafting
│   │   ├── CraftingRecipe.cs
│   │   └── CraftingManager.cs
│   ├── NPC/                # NPC system with schedules and dialogue
│   │   └── NPCData.cs
│   ├── Time/               # Day/night cycle and calendar
│   │   └── TimeManager.cs
│   ├── Save/               # Save/load system
│   │   └── SaveLoadManager.cs
│   ├── World/              # World generation (to be implemented)
│   ├── Combat/             # Combat systems (to be implemented)
│   ├── Building/           # Building placement (to be implemented)
│   ├── UI/                 # User interface (to be implemented)
│   ├── GameManager.cs
│   └── GameConstants.cs
├── Scenes/
│   └── MainScene.unity
├── Prefabs/
├── Materials/
├── Textures/
└── Resources/
```

## Implemented Systems

### 1. Farming System (Stardew Valley Style)

**Components:**
- `CropData` - Scriptable Object defining crop properties
  - Growth stages with sprites
  - Watering requirements
  - Seasonal validity
  - Harvest yields
  
- `PlantedCrop` - Manages individual crop growth
  - Daily progress tracking
  - Watering state
  - Growth stage visualization
  - Harvest mechanics with regrowth support
  
- `FarmingManager` - Central farming system
  - Til soil for planting
  - Plant seeds on tilled soil
  - Water crops
  - Harvest mature crops
  - Integration with Tilemap system

**Usage:**
```csharp
// Till a tile
FarmingManager.Instance.TillSoil(tilePosition);

// Plant a seed
FarmingManager.Instance.PlantSeed(tilePosition, cropData);

// Water the tile
FarmingManager.Instance.WaterTile(tilePosition);

// Harvest
var result = FarmingManager.Instance.HarvestCrop(tilePosition);
```

### 2. Time & Calendar System

**Features:**
- 24-hour day cycle with configurable speed
- Four seasons (Spring, Summer, Fall, Winter)
- 28 days per season
- Formatted time display (12/24 hour)
- Time-of-day periods (Dawn, Morning, Afternoon, etc.)
- Events for day/season/year changes

**Usage:**
```csharp
// Get current time
string time = TimeManager.Instance.GetFormattedTime();
string date = TimeManager.Instance.GetFormattedDate();

// Subscribe to events
TimeManager.Instance.OnNewDay += HandleNewDay;
TimeManager.Instance.OnSeasonChanged += HandleSeasonChange;
```

### 3. Tool System

**Tool Types:**
- Hoe - Till soil
- Watering Can - Water crops
- Axe - Chop trees
- Pickaxe - Mine rocks
- Sword - Combat weapon
- Scythe - Harvest crops
- Fishing Rod - Catch fish
- Hammer - Break structures

**Features:**
- Tier system (Basic, Copper, Iron, Gold, Iridium)
- Stamina cost per use
- Damage/power ratings
- Animation sprites

### 4. Crafting System

**Components:**
- `CraftingRecipe` - Scriptable Object for recipes
  - Ingredient requirements
  - Output items and quantities
  - Crafting categories
  - Unlock conditions
  
- `CraftingManager` - Handles crafting operations
  - Recipe unlocking
  - Resource checking
  - Item creation
  - Inventory integration

**Usage:**
```csharp
// Unlock a recipe
CraftingManager.Instance.UnlockRecipe("Torch");

// Craft an item
bool success = CraftingManager.Instance.TryCraft(recipe, playerInventory);
```

### 5. NPC System

**Features:**
- NPC data with personality traits
- Daily schedules (time-based movement)
- Contextual dialogue system
- Relationship tracking
- Likes/dislikes for gifts
- Birthday system

**NPCData includes:**
- Biography and personality
- Dialogue sets for different contexts
- Hourly schedule with locations
- Relationships with other NPCs

### 6. Save/Load System

**Features:**
- JSON-based serialization
- Auto-save functionality
- Persistent data storage
- Saves:
  - Player position, health, inventory
  - Time and calendar state
  - Game progress

**Usage:**
```csharp
// Save game
SaveLoadManager.Instance.SaveGame();

// Load game
SaveLoadManager.Instance.LoadGame();

// Check for existing save
if (SaveLoadManager.Instance.SaveFileExists())
{
    // Continue option available
}
```

### 7. Core Components

**Health System:**
- Max and current health tracking
- Damage and healing methods
- Death event handling
- Visual health percentage

**Player Controller:**
- Top-down 4-way movement
- Swimming mechanics
- Attack system with cooldown
- Input handling (WASD + Arrow keys)

**Enemy AI:**
- State machine (Idle, Wandering, Chasing, Attacking)
- Detection and attack ranges
- Pathfinding toward player
- Wander behavior around spawn point

**Inventory System:**
- 40-slot inventory (configurable)
- Item stacking
- Add/remove/check items
- Change event notifications

**Camera Follow:**
- Smooth camera following
- Look-ahead based on velocity
- Boundary constraints
- Configurable smoothness

## To Be Implemented

### High Priority
1. **Tilemap Integration** - Set up Unity Tilemap for terrain
2. **Sprite Assets** - Create pixel art assets (Stardew Valley style)
3. **UI System** - Inventory, crafting, dialogue interfaces
4. **Tool Controller** - Player tool usage implementation
5. **World Generation** - Procedural terrain (Core Keeper style)

### Medium Priority
6. **Animation System** - Character and sprite animations
7. **Combat Mechanics** - Full combat system with weapons
8. **Building System** - Place and manage structures
9. **Mining System** - Resource extraction
10. **Quest System** - Objectives and rewards

### Lower Priority
11. **Audio System** - Music and sound effects
12. **Weather System** - Rain, snow, etc.
13. **Fishing System** - Mini-game for fishing
14. **Relationships** - NPC friendship levels
15. **Multiplayer** - Co-op gameplay (stretch goal)

## Integration with Unity Editor

All Scriptable Objects can be created via:
- **Right-click in Project** → Create → Chronicles → [System] → [Type]

Examples:
- Create → Chronicles → Farming → Crop
- Create → Chronicles → Crafting → Recipe
- Create → Chronicles → Tools → Tool
- Create → Chronicles → NPC → NPC Data

## Next Steps for Developers

1. **Set up Tilemap:**
   - Create Tilemap GameObject
   - Import tile sprites
   - Create tile palette
   - Connect to FarmingManager

2. **Create Crop Assets:**
   - Design crop sprites (multiple growth stages)
   - Create CropData Scriptable Objects
   - Define growth rates and requirements

3. **Implement Tool Usage:**
   - Add tool switching to PlayerController
   - Implement raycast/grid detection
   - Connect tools to farming/mining systems

4. **Build UI:**
   - Inventory grid display
   - Crafting menu
   - Dialogue boxes
   - HUD (health, stamina, time)

5. **Add Sprites and Animations:**
   - Character sprite sheets
   - Tile sprites
   - UI elements
   - Animation clips

## Testing

Currently, the systems can be tested by:
1. Opening MainScene.unity
2. Running the game in Play mode
3. Using the Unity Inspector to test Scriptable Objects
4. Adding test GameObjects with components

## Performance Considerations

- Farming Manager uses dictionaries for O(1) tile lookups
- Inventory uses arrays for fast access
- Time system updates only on meaningful changes
- Save system uses async/coroutines for large saves (future)

## Code Style

- C# coding conventions
- XML documentation on public APIs
- Scriptable Objects for data-driven design
- Event-driven architecture for decoupling
- Singleton pattern for managers

---

**For questions or contributions**, refer to the main README or open an issue on GitHub.
