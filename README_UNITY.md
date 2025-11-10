# Chronicles of a Drifter - Unity Edition

A 2D top-down action RPG built with **Unity**, inspired by The Legend of Zelda: A Link to the Past.

## 🎮 Game Concept

Chronicles of a Drifter features:
- **Procedurally generated world** with interconnected scenes
- **Extensive crafting system** for equipment and upgrades
- **Randomized loot** with varied weapon attributes
- **Dynamic weather** and day/night cycles
- **Home base building** with modular construction
- **Satisfying combat** with DoT effects and responsive feedback

## 🛠️ Technology Stack

### Unity 2022.3 LTS
- **2D rendering pipeline** with sprite-based graphics
- **Unity Physics 2D** for collision detection
- **Tilemap system** for terrain generation
- **Cinemachine** for advanced camera controls (optional)
- **Lua scripting** via MoonSharp for AI and gameplay

### .NET / C# Game Logic
- MonoBehaviour-based component architecture
- Scene management
- Gameplay systems
- UI framework with Unity UI

## 📁 Project Structure

```
unity-chronicles/
├── Assets/
│   ├── Scripts/         # C# game scripts
│   │   ├── Components/  # MonoBehaviour components
│   │   ├── Systems/     # Game systems
│   │   ├── World/       # World generation
│   │   ├── UI/          # User interface
│   │   └── Combat/      # Combat systems
│   ├── Scenes/          # Unity scenes
│   ├── Prefabs/         # Reusable game objects
│   ├── Materials/       # Materials and shaders
│   ├── Textures/        # Sprite sheets and textures
│   ├── Audio/           # Sound effects and music
│   └── Resources/       # Runtime-loaded assets
├── ProjectSettings/     # Unity project settings
└── Packages/            # Unity package dependencies
```

## 📚 Documentation

### Getting Started
- **[Unity Setup](#unity-setup)** - How to open and run the project in Unity
- **[Build Instructions](#building)** - How to build the game
- **[Game Features](#-game-features)** - Overview of implemented features

## 🚀 Quick Start

### Prerequisites
- **Unity 2022.3 LTS** or newer (2022.3.10f1 recommended)
- **Windows 10/11**, **macOS**, or **Linux**
- **Git** for version control

### Unity Setup

1. **Install Unity Hub**
   - Download from: https://unity.com/download

2. **Install Unity 2022.3 LTS**
   - Open Unity Hub
   - Go to "Installs" tab
   - Click "Install Editor"
   - Select version 2022.3.10f1 or newer
   - Include these modules:
     - Windows Build Support (for Windows builds)
     - Mac Build Support (for macOS builds)  
     - Linux Build Support (for Linux builds)

3. **Clone the Repository**
   ```bash
   git clone https://github.com/shifty81/unity-chronicles.git
   cd unity-chronicles
   ```

4. **Open Project in Unity**
   - Open Unity Hub
   - Click "Open" or "Add"
   - Navigate to the cloned `unity-chronicles` folder
   - Select the folder (Unity will detect it as a project)
   - Wait for Unity to import all assets (first time may take a few minutes)

5. **Run the Game**
   - In Unity, open the main scene: `Assets/Scenes/MainScene.unity`
   - Click the Play button ▶️ in the Unity Editor
   - Use WASD or Arrow Keys to move
   - Press Space or Left Mouse to attack

### Building

To build the game as a standalone executable:

1. **Open Build Settings**
   - In Unity, go to `File > Build Settings`

2. **Add Scenes**
   - Click "Add Open Scenes" to add the current scene
   - Or drag scenes from the Project window

3. **Select Target Platform**
   - Choose your platform (PC, Mac & Linux Standalone)
   - Click "Switch Platform" if needed

4. **Build**
   - Click "Build" or "Build And Run"
   - Choose output folder
   - Wait for build to complete

### Controls

- **WASD** or **Arrow Keys**: Move player
- **Space** or **Left Mouse**: Attack
- **I**: Open inventory (when implemented)
- **C**: Open crafting menu (when implemented)
- **ESC**: Pause/Menu

## 🎯 Current Status: Unity Conversion Phase

This project has been converted from a custom C++/.NET engine to Unity.

### ✅ Completed
- [x] Unity project structure created
- [x] Core component system (Health, PlayerController, EnemyAI, Inventory)
- [x] Camera follow system with look-ahead
- [x] Basic game constants and settings
- [x] Project configuration for Unity 2022.3 LTS

### 🔄 In Progress
- [ ] Terrain generation system (convert from custom to Unity Tilemap)
- [ ] Lua scripting integration (MoonSharp)
- [ ] Animation system (Unity Animator)
- [ ] Combat system (full implementation)
- [ ] UI system (Unity UI/Canvas)
- [ ] Scene management
- [ ] Audio system
- [ ] Save/Load system
- [ ] Complete game loop scene

### 📋 Migration Status

**From Custom Engine to Unity:**
- ✅ Project structure → Unity folder layout
- ✅ Custom ECS → Unity MonoBehaviours  
- ✅ C++ Renderer → Unity 2D Rendering
- 🔄 128 C# files → Being converted to Unity scripts
- 🔄 28 ECS Systems → Being converted to Unity systems
- 🔄 Assets → Being converted to Unity formats

## 🎨 Game Features

### Character System
- **Player Controller** with smooth movement
- **Health system** with damage and healing
- **Inventory system** with 40 slots
- **Equipment and upgrades**

### AI System
- **Enemy AI** with states (Idle, Wandering, Chasing, Attacking)
- **Detection ranges** for player awareness
- **Attack patterns** and cooldowns
- **Lua-scriptable behaviors** (coming soon)

### Camera System
- **Smooth following** with configurable speed
- **Look-ahead** based on player velocity
- **Boundary constraints** for scene limits
- **Zoom support** (configurable)

### World Generation (Coming Soon)
- **Procedural terrain** with multiple biomes
- **Chunk-based loading** for infinite worlds
- **Cave systems** and underground layers
- **Dynamic vegetation**

### Combat System (Coming Soon)
- **Melee combat** with combos
- **Ranged weapons**
- **Status effects** (burning, poison, etc.)
- **Damage numbers** and visual feedback

## 🤝 Contributing

Contributions are welcome! This project is in active development as we complete the Unity conversion.

## 📄 License

MIT License - See [LICENSE](LICENSE) for details

## 🙏 Acknowledgments

- Inspired by The Legend of Zelda: A Link to the Past
- Built with Unity Engine
- Originally a custom C++/.NET game engine project

## 📬 Contact

For questions or discussions:
- GitHub Issues: [Report a bug or request a feature](https://github.com/shifty81/unity-chronicles/issues)
- Discussions: [Join the conversation](https://github.com/shifty81/unity-chronicles/discussions)

---

**Chronicles of a Drifter** - A modern 2D action RPG with classic Zelda inspiration, now powered by Unity!
