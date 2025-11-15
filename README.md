# Chronicles of a Drifter

A 2D top-down action RPG built with **Unity Engine**, inspired by The Legend of Zelda: A Link to the Past.

---

## 🚨 IMPORTANT: TileTemplate Compilation Error - FIXED!

If you previously saw **compilation errors** about `TileTemplate`:  
```
error CS0246: The type or namespace name 'TileTemplate' could not be found
```

**✅ THIS HAS BEEN FIXED!**

The issue was that Unity's `com.unity.2d.tilemap.extras` package (versions 6.0.1 and 7.0.0) was missing the `TileTemplate` base class. This project now includes the missing class at `Assets/Scripts/Editor/Tilemaps/TileTemplate.cs`.

**No cleanup scripts needed** - just open the project and it will compile correctly.

For technical details, see [TILETEMPLATE_BUG_EXPLANATION.md](TILETEMPLATE_BUG_EXPLANATION.md)

---

## 🎮 Platform Support

**This Unity project supports multiple platforms:**

- **Windows** (Primary development platform)
- **macOS** (Supported)
- **Linux** (Supported)
- **WebGL** (Planned)

## 🛠️ Technology Stack

### Unity 6 LTS (2023.3+)
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
- **Unity 6 LTS (2023.3+)** or newer (Download from [Unity Hub](https://unity.com/download))
- **Windows 10/11**, **macOS**, or **Linux**

### Setup

1. **Install Unity Hub and Unity 6 LTS**
2. **Clone this repository:**
   ```bash
   git clone https://github.com/shifty81/unity-chronicles.git
   ```
3. **Open the project in Unity Hub**
4. **Open the main scene:** `Assets/Scenes/MainScene.unity`
5. **Press Play ▶️** to run the game

**💡 Encountering TileTemplate compilation errors?**
1. Run the verification script: `.\verify-packages.ps1` (Windows) or `./verify-packages.sh` (macOS/Linux)
2. Follow the recommended cleanup steps
3. See [QUICK_FIX.md](QUICK_FIX.md) for detailed solutions

**💡 Visual Studio project compatibility issues?**
1. Unity auto-generates .csproj and .sln files when you open the project
2. See [VISUAL_STUDIO_SETUP.md](VISUAL_STUDIO_SETUP.md) for complete setup guide
3. Always open scripts by double-clicking them in Unity Editor

**For detailed setup instructions, see [README_UNITY.md](README_UNITY.md)**

### Controls

- **WASD** or **Arrow Keys**: Move
- **Space** or **Left Mouse**: Attack
- **I**: Inventory
- **C**: Crafting
- **ESC**: Pause

## 📚 Documentation

- [Unity Setup Guide](README_UNITY.md) - Complete Unity project setup
- [Visual Studio Setup Guide](VISUAL_STUDIO_SETUP.md) - **🔧 Fix Visual Studio compatibility issues**
- [Project Status](PROJECT_STATUS_UNITY.md) - Current implementation status
- [Unity Implementation Guide](UNITY_IMPLEMENTATION_GUIDE.md) - System details
- [Unity Asset Guide](UNITY_ASSET_GUIDE.md) - **📦 Complete guide to generating and adding assets to scenes**
- [Quick Fix Guide](QUICK_FIX.md) - **⚡ Fast solutions for common errors**
- [TileTemplate Bug Explanation](TILETEMPLATE_BUG_EXPLANATION.md) - **🐛 Technical details about the TileTemplate bug and fix**
- [Cleanup Tools Guide](CLEANUP_TOOLS.md) - **🧹 Package cache cleanup scripts documentation**
- [Troubleshooting Guide](TROUBLESHOOTING.md) - **🔧 Comprehensive solutions for issues and errors**


## 🎯 Current Status

This Unity project features a comprehensive farming and life simulation system similar to Stardew Valley:

### ✅ Implemented Systems
- **Health System** - Damage, healing, death events
- **Player Controller** - Movement, swimming, attack input
- **Enemy AI** - State machine (Idle, Wander, Chase, Attack)
- **Inventory System** - 40-slot storage with stacking
- **Camera System** - Smooth follow with look-ahead
- **Farming System** - Till, plant, water, harvest with crop growth stages
- **Time & Calendar** - 24-hour day cycle with seasons
- **Tool System** - 8 tool types with 5-tier upgrades
- **Crafting System** - Recipe-based crafting with ingredients
- **NPC System** - Dialogue, schedules, relationships
- **Save/Load System** - JSON-based save system with auto-save

### 🔄 Next Steps
- [ ] Create visual assets (sprites, tiles, UI elements)
- [ ] Implement Tilemap for world rendering
- [ ] Build UI system (inventory, crafting, HUD)
- [ ] Add procedural world generation
- [ ] Expand combat mechanics
- [ ] Implement building/construction system

## 🎨 Game Features

### Farming & Life Simulation
- **Crop System** - Plant, water, and harvest crops with growth stages
- **Seasonal Calendar** - 4 seasons with 28 days each
- **Tool Progression** - Upgrade tools from Basic to Iridium tier
- **NPC Interactions** - Build relationships with villagers
- **Time Management** - Day/night cycle affects gameplay

### Crafting & Resources
- **Recipe-based Crafting** - Unlock and craft items from recipes
- **Resource Collection** - Gather materials from the world
- **Inventory Management** - 40-slot inventory with stacking

### Combat & Exploration
- **Enemy AI** - Dynamic enemy behavior with state machines
- **Health System** - Damage and healing mechanics
- **Swimming** - Water navigation with stamina management

## 🤝 Contributing

Contributions are welcome! See [PROJECT_STATUS_UNITY.md](PROJECT_STATUS_UNITY.md) for current development priorities.

## 📄 License

MIT License - See [LICENSE](LICENSE) for details

## 🙏 Acknowledgments

- Inspired by The Legend of Zelda: A Link to the Past and Stardew Valley
- Built with Unity Engine and C#

## 📬 Contact

For questions or discussions:
- GitHub Issues: [Report a bug or request a feature](https://github.com/shifty81/unity-chronicles/issues)
- Discussions: [Join the conversation](https://github.com/shifty81/unity-chronicles/discussions)

---

**Chronicles of a Drifter** - A modern 2D action RPG with farming and life simulation
