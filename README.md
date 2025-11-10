# Chronicles of a Drifter - Unity Edition

A 2D top-down action RPG built with **Unity Engine**, inspired by The Legend of Zelda: A Link to the Past.

> **⚠️ IMPORTANT: This project has been converted to Unity!**
> 
> The original C++/.NET custom engine version has been replaced with Unity for better cross-platform support and easier development.
> 
> **See [README_UNITY.md](README_UNITY.md) for Unity-specific setup instructions.**

## 🎮 Platform Support

**This Unity project supports multiple platforms:**

- **Windows** (Primary development platform)
- **macOS** (Supported)
- **Linux** (Supported)
- **WebGL** (Planned)

## 🛠️ Technology Stack

### Unity 2022.3 LTS
- **2D Rendering** with sprite-based graphics
- **Unity Physics 2D** for collision detection
- **Tilemap System** for terrain
- **C# MonoBehaviours** for game logic

## 🎮 Game Concept

Chronicles of a Drifter features:
- **Procedurally generated world** with interconnected scenes
- **Extensive crafting system** for equipment and upgrades
- **Randomized loot** with varied weapon attributes
- **Dynamic weather** and day/night cycles
- **Home base building** with modular construction
- **Satisfying combat** with DoT effects and responsive feedback

## 🚀 Quick Start

### Prerequisites
- **Unity 2022.3 LTS** or newer (Download from [Unity Hub](https://unity.com/download))
- **Windows 10/11**, **macOS**, or **Linux**

### Setup

1. **Install Unity Hub and Unity 2022.3 LTS**
2. **Clone this repository:**
   ```bash
   git clone https://github.com/shifty81/unity-chronicles.git
   ```
3. **Open the project in Unity Hub**
4. **Open the main scene:** `Assets/Scenes/MainScene.unity`
5. **Press Play ▶️** to run the game

**For detailed setup instructions, see [README_UNITY.md](README_UNITY.md)**

### Controls

- **WASD** or **Arrow Keys**: Move
- **Space** or **Left Mouse**: Attack
- **I**: Inventory (coming soon)
- **C**: Crafting (coming soon)
- **ESC**: Pause

## 📚 Documentation

**Unity Version:**
- [Unity Setup Guide](README_UNITY.md) - Complete Unity project setup
- [Game Features](README_UNITY.md#-game-features) - Implemented features
- [Migration Status](README_UNITY.md#-migration-status) - Conversion progress

**Original Custom Engine Documentation** (for reference):
- The `docs/` folder contains documentation from the original C++/.NET engine version
- These are kept for reference but may not apply to the Unity version

## 🎯 Current Status: Implementation Phase

This repository contains the **initial implementation** of Chronicles of a Drifter. The following has been completed:

### ✅ Completed
- [x] Project structure defined
- [x] Architecture documentation
- [x] Procedural generation algorithm specifications
- [x] Lua scripting API design
- [x] C++/C# integration patterns
- [x] Build system configuration
- [x] **Entity Component System (ECS) implementation**
- [x] **Player movement with keyboard input**
- [x] **Lua scripting integration with NLua**
- [x] **Scene management system**
- [x] **Example AI scripts (Goblin patrol)**
- [x] **Sprite animation system with frame-by-frame support**
- [x] **Character customization system with clothing layers**
- [x] **High-resolution sprite support (64x64, 128x128)**
- [x] **Character creator with multiple customization options**
- [x] **Clothing color customization system**
- [x] **Armor/clothing visibility system**
- [x] **2D Camera system with smooth following and zoom**
- [x] **Parallax scrolling system for depth illusion**
- [x] **Camera look-ahead based on player velocity**
- [x] **2D Terrain Generation System**
  - [x] Chunk-based world (32×30 blocks per chunk)
  - [x] Perlin noise terrain generation
  - [x] 8 biomes (Plains, Desert, Forest, Snow, Swamp, Rocky, Jungle, Beach)
  - [x] Temperature/moisture-based biome distribution
  - [x] 20-layer underground system with ores
  - [x] Cave generation
  - [x] Dynamic chunk loading/unloading
- [x] **Vegetation Generation System**
  - [x] Biome-specific vegetation (trees, grass, bushes, cacti, flowers)
  - [x] Forest biome: 60% coverage with oak/pine trees
  - [x] Plains biome: 30% coverage with scattered vegetation
  - [x] Desert biome: 5% coverage with cacti and palm trees
  - [x] Snow biome: 30% coverage with pine trees
  - [x] Swamp biome: 40% coverage with oak trees and reeds
  - [x] Rocky biome: 10% coverage with hardy plants
  - [x] Jungle biome: 70% coverage with dense vegetation
  - [x] Beach biome: 15% coverage with palm trees
  - [x] Noise-based procedural placement
  - [x] Non-blocking vegetation (grass, flowers) vs blocking (trees)
- [x] **Mining and Building System**
  - [x] Block mining with tool requirements
  - [x] Inventory system for resource collection (40 slots)
  - [x] Tool progression (wood, stone, iron, steel)
  - [x] Block hardness and mining speed mechanics
  - [x] Resource drops from mined blocks
  - [x] Block placement from inventory
  - [x] Interactive mining demo scene
- [x] **Water Body Generation**
  - [x] Rivers with meandering patterns (2 blocks deep)
  - [x] Lakes in natural depressions (3 blocks deep)
  - [x] Ocean zones in beach biomes (5 blocks deep)
  - [x] Biome-specific water placement rules
  - [x] Noise-based natural water patterns
  - [x] Water generation test suite
- [x] **Advanced Camera System**
  - [x] Multi-layer parallax backgrounds (Sky, Clouds, Mountains, Stars, Mist)
  - [x] Screen shake effects for combat feedback (light, medium, heavy)
  - [x] Camera zones with dynamic behavior per area
  - [x] Smooth zoom transitions
  - [x] Camera look-ahead based on velocity
  - [x] Cinematic camera movements for cutscenes with easing functions
- [x] **Underground Lighting and Fog of War**
  - [x] Depth-based ambient lighting (bright surface, dark underground)
  - [x] Player personal lantern (8-block radius)
  - [x] Torch placement system (8-block radius per torch)
  - [x] Light intensity falloff with distance
  - [x] Fog of war with exploration tracking
  - [x] Dynamic lighting for all light sources
- [x] **Collision Detection System**
  - [x] AABB (Axis-Aligned Bounding Box) collision detection
  - [x] Entity-to-terrain collision with ChunkManager integration
  - [x] Entity-to-entity collision detection
  - [x] Collision layer system for filtering (Player, Enemy, Projectile, etc.)
  - [x] Sliding collision response (smooth wall sliding)
  - [x] Static vs. dynamic entity support
  - [x] Comprehensive collision test suite
  - [x] Interactive collision demo scene
- [x] **Crafting System**
  - [x] Recipe-based crafting with materials
  - [x] 8 initial recipes (wood planks, wood blocks, bricks, torches, etc.)
  - [x] Crafting categories (Tools, Building, Lighting)
  - [x] Inventory integration for crafting
  - [x] Craftable recipes viewer
  - [x] Comprehensive crafting system tests
  - [x] Interactive crafting demo scene
- [x] **Swimming and Water Mechanics**
  - [x] Swimming component with breath management
  - [x] Water flow system with different body types (River, Lake, Ocean)
  - [x] Drowning mechanics when out of breath
  - [x] Swim speed reduction in water
  - [x] Water flow affects entity movement
  - [x] Comprehensive swimming system tests
- [x] **Day/Night Cycle and Time System**
  - [x] 24-hour in-game day with configurable time scale (60x default)
  - [x] Four day phases (Dawn, Day, Dusk, Night) with smooth transitions
  - [x] Dynamic ambient lighting based on time of day
  - [x] Atmospheric color tinting (warm dawn/dusk, cool night)
  - [x] Creature spawn rate multipliers by time of day
  - [x] Integration with lighting system for surface/underground
  - [x] Time manipulation and query API
  - [x] Comprehensive time system tests
- [x] **UI Framework**
  - [x] Component-based UI system integrated with ECS
  - [x] UI element types (Panel, Button, custom elements)
  - [x] Inventory UI with 40-slot grid display
  - [x] Crafting UI with recipe browsing and crafting
  - [x] Mouse input handling (clicks, hover states)
  - [x] Keyboard shortcuts (I for inventory, C for crafting, ESC to close)
  - [x] Input handling fixed for DirectX 11/12 renderers
  - [x] UI rendering layer (always on top)
  - [x] UI demo scene
- [x] **Map Editor and Tileset System**
  - [x] In-game map editor for real-time scene editing
  - [x] Tileset system with JSON-based tile definitions
  - [x] Drag-and-drop style tileset support
  - [x] Map save/load functionality (JSON format)
  - [x] Tile placement and removal tools
  - [x] Editor toggle (F1/Tilde) in any scene
  - [x] Procedural terrain editing capabilities
  - [x] Zelda-style tileset included
  - [x] Map editor documentation
- [x] **Complete Game Loop Demo**
  - [x] Integrated all 24+ core systems in one playable scene
  - [x] Procedural world with 8 biomes and 20-layer underground
  - [x] Player with full capabilities (combat, mining, crafting, swimming)
  - [x] Enemy spawning with AI (goblins with Lua scripts)
  - [x] NPC system (merchant and quest giver)
  - [x] Quest system with combat objectives
  - [x] Day/night cycle and dynamic weather
  - [x] Inventory (40 slots) and crafting (8+ recipes)
  - [x] Camera system with parallax, look-ahead, and screen shake
  - [x] Lighting system with fog of war
  - [x] Full documentation of missing systems
  - [x] Analysis document: [COMPLETE_GAME_LOOP_ANALYSIS.md](COMPLETE_GAME_LOOP_ANALYSIS.md)

### 🔄 Next Steps
- [x] **Implement C++ rendering engine (DirectX 12)** (COMPLETED - see [DIRECTX12_RENDERER.md](docs/DIRECTX12_RENDERER.md))
- [x] **Create UI framework for crafting and inventory** (COMPLETED - see [UI_FRAMEWORK.md](docs/UI_FRAMEWORK.md))
- [x] **Add in-game map editor with tileset support** (COMPLETED - see [MAP_EDITOR.md](docs/MAP_EDITOR.md))
- [x] **Complete game loop demo** (COMPLETED - see [COMPLETE_GAME_LOOP_ANALYSIS.md](COMPLETE_GAME_LOOP_ANALYSIS.md))
- [ ] **Implement save/load system** (CRITICAL - Next priority)
- [ ] **Add player death and respawn mechanics** (CRITICAL)
- [ ] **Implement enemy loot drops** (HIGH)
- [ ] **Add player XP and leveling system** (HIGH)
- [ ] Add actual sprite assets (high-resolution character sprites)
- [ ] Enhance combat mechanics with ranged weapons and abilities

## 🎨 Game Features

### Map Editor
- **Real-time Scene Editing** - Edit maps while playing
- **Tileset System** - JSON-based tileset definitions with drag-and-drop support
- **Map Management** - Save and load custom maps
- **Editor Integration** - Toggle editor mode in any scene with F1 or ~
- **Tile Tools** - Place, remove, and modify tiles
- **Procedural Integration** - Edit procedurally generated terrain
- Run with: `dotnet run -c Release -- editor`
- See [MAP_EDITOR.md](docs/MAP_EDITOR.md) for full documentation

### Character Customization
- **Sprite Animation System** with frame-by-frame animations
- **Character Creator** with extensive customization options
  - 6 skin tones (pale to dark)
  - 7 hair styles (short, long, ponytail, bald, curly, braided, spiky)
  - 4 body types (slim, average, athletic, heavy)
- **Layered Clothing System**
  - Multiple clothing categories (shirts, pants, boots, gloves, hats)
  - 5+ styles per category
  - Dynamic color customization with primary and secondary colors
  - 8 preset color palettes (Earth Tones, Forest, Ocean, Crimson, Royal, Neutral, Midnight, Desert)
- **Armor System**
  - Armor overrides clothing visibility when equipped
  - Clothing automatically reappears when armor is removed
- **High-Resolution Sprites**
  - Support for 64x64 and 128x128 per-frame sprites
  - Smooth animations at 6-8 frames per second
  - Scalable rendering for different resolutions

### Procedural Generation
- **BSP Algorithm** for structured dungeons
- **Random Walkers** for organic caves
- **Cellular Automata** for natural terrain
- **Hybrid approach** for Zelda-like dungeons

### Crafting & Loot
- Material gathering from the world
- Equipment creation and upgrading
- Randomized weapon attributes
- Varied weapon types (swords, guns, magic)

### World Systems
- Scene-based world structure
- Hidden dungeon entrances
- Dynamic weather effects
- Day/night cycle with gameplay impact
- Seasonal progression

### Combat
- Responsive melee combat
- Ranged weapons with spread
- Status effects (bleeding, burning, poison)
- Damage-over-time mechanics

## 🤝 Contributing

This is currently in the planning phase. Contributions are welcome once the core systems are implemented.

## 📄 License

MIT License - See [LICENSE](LICENSE) for details

## 🙏 Acknowledgments

- Inspired by The Legend of Zelda: A Link to the Past
- Built with modern C++20, .NET 9, and Lua
- Procedural generation techniques from roguelike development

## 📬 Contact

For questions or discussions about the project architecture:
- GitHub Issues: [Report a bug or request a feature](https://github.com/shifty81/ChroniclesOfADrifter/issues)
- Discussions: [Join the conversation](https://github.com/shifty81/ChroniclesOfADrifter/discussions)

---

**Chronicles of a Drifter** - A modern 2D action RPG with classic Zelda inspiration
