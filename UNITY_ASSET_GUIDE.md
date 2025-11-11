# Unity Asset Generation & Scene Management Guide

**A Comprehensive Visual Guide for Chronicles of a Drifter**

This guide will walk you through everything you need to know about creating, importing, organizing, and adding assets to your Unity scenes.

---

## 📋 Table of Contents

1. [Understanding Unity Assets](#understanding-unity-assets)
2. [Unity Asset Workflow Overview](#unity-asset-workflow-overview)
3. [Creating Sprites & Textures](#creating-sprites--textures)
4. [Creating Scriptable Objects](#creating-scriptable-objects)
5. [Creating Prefabs](#creating-prefabs)
6. [Creating Tilemaps & Tile Palettes](#creating-tilemaps--tile-palettes)
7. [Creating Materials & Shaders](#creating-materials--shaders)
8. [Importing External Assets](#importing-external-assets)
9. [Organizing Your Assets](#organizing-your-assets)
10. [Adding Assets to Scenes](#adding-assets-to-scenes)
11. [Unity Asset Store](#unity-asset-store)
12. [Best Practices](#best-practices)
13. [Project-Specific Examples](#project-specific-examples)

---

## Understanding Unity Assets

### What Are Assets?

Assets are the building blocks of your Unity project. They include:

- **Sprites/Textures** - 2D images (`.png`, `.jpg`, `.psd`)
- **Models** - 3D objects (`.fbx`, `.obj`, `.blend`)
- **Audio** - Sounds and music (`.mp3`, `.wav`, `.ogg`)
- **Scripts** - C# code files (`.cs`)
- **Prefabs** - Reusable GameObject templates (`.prefab`)
- **Materials** - Define how objects look (`.mat`)
- **Animations** - Animation clips (`.anim`)
- **Scriptable Objects** - Custom data containers (`.asset`)
- **Scenes** - Game levels and menus (`.unity`)

### The Assets Folder

```
unity-chronicles/
├── Assets/
│   ├── Scenes/           ← Your game scenes
│   ├── Scripts/          ← C# code
│   ├── Sprites/          ← 2D images
│   ├── Prefabs/          ← Reusable GameObjects
│   ├── Materials/        ← Materials & shaders
│   ├── Audio/            ← Sound effects & music
│   ├── Animations/       ← Animation clips
│   ├── Resources/        ← Runtime-loaded assets
│   └── ScriptableObjects/ ← Data containers
```

**Important:** Only files inside the `Assets/` folder are visible to Unity!

---

## Unity Asset Workflow Overview

### Visual Workflow Diagram

```
┌─────────────────────────────────────────────────────────────┐
│                    ASSET CREATION WORKFLOW                   │
└─────────────────────────────────────────────────────────────┘

Step 1: CREATE OR IMPORT ASSET
├─ Option A: Create in Unity (Right-click → Create)
├─ Option B: Import external file (drag & drop)
└─ Option C: Unity Asset Store (download & import)
                    ↓
Step 2: CONFIGURE ASSET
├─ Select asset in Project window
├─ View properties in Inspector
└─ Adjust import settings
                    ↓
Step 3: ORGANIZE ASSET
├─ Move to appropriate folder
├─ Rename descriptively
└─ Add labels/tags (optional)
                    ↓
Step 4: USE IN SCENE
├─ Drag into Scene view, OR
├─ Drag into Hierarchy window, OR
└─ Assign to component property
                    ↓
Step 5: CONFIGURE IN SCENE
├─ Adjust Transform (position, rotation, scale)
├─ Add/modify components
└─ Set up references
```

### The Three Main Windows

1. **Project Window** (Bottom) - Your asset library
2. **Scene View** (Center) - Visual editor for your game
3. **Inspector** (Right) - Properties and settings

```
┌────────────────────────────────────────────────────────────┐
│  Hierarchy    │        Scene View         │   Inspector    │
│  (GameObjects)│    (Visual Editor)        │  (Properties)  │
├───────────────┼───────────────────────────┼────────────────┤
│  - MainCamera │                           │  Transform     │
│  - Player     │      [Visual Scene]       │  - Position    │
│  - Enemies    │                           │  - Rotation    │
│  - Tilemap    │                           │  - Scale       │
│               │                           │  Components    │
├───────────────┴───────────────────────────┴────────────────┤
│             Project Window (Asset Library)                  │
│  Assets/ ► Sprites/ ► Characters/ ► player_idle.png        │
└─────────────────────────────────────────────────────────────┘
```

---

## Creating Sprites & Textures

Sprites are 2D images used in your game (characters, items, tiles, UI).

### Method 1: Import External Image Files

**Step-by-Step:**

1. **Create your image** in external software:
   - Photoshop, GIMP, Aseprite, Krita, etc.
   - For pixel art: Use 16x16, 32x32, or 64x64 sizes
   - Save as `.png` (supports transparency)

2. **Import into Unity:**
   ```
   Option A: Drag & Drop
   ┌──────────────────────────────────────┐
   │ 1. Open file explorer                │
   │ 2. Find your .png file               │
   │ 3. Drag file into Unity Project     │
   │    window (Assets/Sprites folder)    │
   └──────────────────────────────────────┘
   
   Option B: Import via Menu
   ┌──────────────────────────────────────┐
   │ 1. Assets → Import New Asset...      │
   │ 2. Browse to your image file         │
   │ 3. Click Import                      │
   └──────────────────────────────────────┘
   ```

3. **Configure Import Settings:**
   ```
   In Inspector (with sprite selected):
   ┌──────────────────────────────────────┐
   │ Texture Type: Sprite (2D and UI)    │
   │ Sprite Mode: Single (or Multiple)    │
   │ Pixels Per Unit: 16 (for pixel art)  │
   │ Filter Mode: Point (no filter)       │
   │ Compression: None (best quality)     │
   │                                      │
   │ [Apply] [Revert]                     │
   └──────────────────────────────────────┘
   ```

4. **Click Apply** to save settings

### Method 2: Sprite Editor (for Sprite Sheets)

For multiple sprites in one image:

1. **Import sprite sheet** (large image with multiple sprites)
2. **Set Sprite Mode to Multiple** in Inspector
3. **Click "Sprite Editor" button**
4. **Slice the sheet:**
   ```
   Sprite Editor Window:
   ┌──────────────────────────────────────┐
   │ [Slice ▼] [Trim] [Pivot]            │
   ├──────────────────────────────────────┤
   │                                      │
   │  ┌──┬──┬──┬──┐                      │
   │  │1 │2 │3 │4 │  ← Click & drag     │
   │  ├──┼──┼──┼──┤     to create        │
   │  │5 │6 │7 │8 │     sprite boxes     │
   │  └──┴──┴──┴──┘                      │
   │                                      │
   │ Slice: Automatic / Grid / By Cell   │
   │ Cell Size: 32 x 32                  │
   │                                      │
   │ [Apply] [Revert]                     │
   └──────────────────────────────────────┘
   ```

5. **Click Apply** to create individual sprites

### Method 3: Generate Procedurally (Using Scripts)

Create textures at runtime:

```csharp
// Example: Create a 64x64 colored texture
Texture2D CreateTexture(Color color)
{
    Texture2D texture = new Texture2D(64, 64);
    Color[] pixels = new Color[64 * 64];
    
    for (int i = 0; i < pixels.Length; i++)
        pixels[i] = color;
    
    texture.SetPixels(pixels);
    texture.Apply();
    return texture;
}
```

### Visual: Sprite Import Workflow

```
External Software           Unity Engine
┌──────────────┐          ┌────────────────────────┐
│  Photoshop   │          │  Project Window        │
│  GIMP        │  Save    │  ┌──────────────────┐  │
│  Aseprite    │  ────→   │  │ player_idle.png  │  │
│  Krita       │  .png    │  └──────────────────┘  │
└──────────────┘          │         ↓              │
                          │  [Select & Configure]  │
                          │         ↓              │
                          │  Inspector Settings:   │
                          │  - Texture Type        │
                          │  - Sprite Mode         │
                          │  - Pixels Per Unit     │
                          │  - Filter Mode         │
                          │         ↓              │
                          │  [Apply] → Ready!      │
                          └────────────────────────┘
```

---

## Creating Scriptable Objects

Scriptable Objects are custom data containers (used for crops, items, recipes, etc. in Chronicles of a Drifter).

### Step-by-Step Creation

1. **Right-click in Project window**
2. **Select Create → Chronicles → [Type]**
   ```
   Right-Click Menu:
   ┌────────────────────────────────┐
   │ Create                      ▶  │
   ├────────────────────────────────┤
   │ ► Folder                       │
   │ ► C# Script                    │
   │ ► Scene                        │
   │ ────────────────────────────   │
   │ ► Chronicles               ▶   │
   │   ├─ Farming           ▶       │
   │   │  ├─ Crop                   │
   │   │  └─ Planted Crop           │
   │   ├─ Crafting          ▶       │
   │   │  └─ Recipe                 │
   │   ├─ Tools             ▶       │
   │   │  └─ Tool                   │
   │   └─ NPC               ▶       │
   │      └─ NPC Data               │
   └────────────────────────────────┘
   ```

3. **Name your new asset** (e.g., "Tomato_Crop")
4. **Select asset and configure in Inspector**

### Example: Creating a Crop

```
Creating "Tomato" Crop Asset:

1. Right-click → Create → Chronicles → Farming → Crop
2. Name it: "Crop_Tomato"
3. Configure in Inspector:

┌────────────────────────────────────────┐
│ Crop Data (Script)                     │
├────────────────────────────────────────┤
│ Crop Name: Tomato                      │
│ Description: A juicy red tomato        │
│                                        │
│ Growth Properties:                     │
│ ├─ Days To Mature: 8                  │
│ ├─ Regrows: Yes                       │
│ └─ Days To Regrow: 3                  │
│                                        │
│ Growth Stages (Array):                 │
│ ├─ Stage 0: [Sprite: seedling]        │
│ ├─ Stage 1: [Sprite: young_plant]     │
│ ├─ Stage 2: [Sprite: growing]         │
│ └─ Stage 3: [Sprite: mature_tomato]   │
│                                        │
│ Season:                                │
│ ├─ Valid Seasons: Spring, Summer      │
│ └─ Invalid Seasons: Fall, Winter      │
│                                        │
│ Harvest:                               │
│ ├─ Harvest Item: Tomato (Item)        │
│ ├─ Min Yield: 1                       │
│ └─ Max Yield: 3                       │
│                                        │
│ Watering:                              │
│ └─ Needs Water Daily: Yes              │
└────────────────────────────────────────┘
```

### Scriptable Object Workflow

```
┌─────────────────────────────────────────────────────┐
│         SCRIPTABLE OBJECT CREATION FLOW             │
└─────────────────────────────────────────────────────┘

1. Define C# ScriptableObject Class
   ↓
2. Add [CreateAssetMenu] Attribute
   ↓
3. Right-Click → Create → [Your Menu Path]
   ↓
4. Name the Asset
   ↓
5. Configure Values in Inspector
   ↓
6. Reference in Other Scripts/Components
   ↓
7. Use at Runtime (data is read-only)
```

---

## Creating Prefabs

Prefabs are reusable GameObject templates (like a blueprint).

### Why Use Prefabs?

- **Reusability**: Create once, use everywhere
- **Consistency**: All instances stay synchronized
- **Easy Updates**: Change prefab → all instances update
- **Perfect for**: Enemies, items, projectiles, UI elements

### Method 1: Create Prefab from Scene Object

**Step-by-Step:**

1. **Create GameObject in Scene:**
   ```
   Hierarchy Window:
   Right-click → Create Empty (or 2D Object → Sprite)
   Name it: "Enemy_Slime"
   ```

2. **Add Components:**
   ```
   Inspector (with Enemy_Slime selected):
   ┌────────────────────────────────────┐
   │ Enemy_Slime                        │
   ├────────────────────────────────────┤
   │ Transform                          │
   │ Sprite Renderer                    │
   │ ├─ Sprite: slime_sprite           │
   │ └─ Color: Green                    │
   │ Box Collider 2D                    │
   │ Rigidbody 2D                       │
   │ Health (Script)                    │
   │ └─ Max Health: 50                  │
   │ Enemy AI (Script)                  │
   │ └─ Move Speed: 2.5                 │
   └────────────────────────────────────┘
   ```

3. **Drag from Hierarchy to Project window:**
   ```
   ┌─────────────────────────────────────┐
   │ Hierarchy          Project          │
   ├─────────────┬───────────────────────┤
   │ Enemy_Slime │  Assets/Prefabs/      │
   │     │       │                       │
   │     └─────────→ [Drop here]         │
   │             │                       │
   │             │  Enemy_Slime.prefab   │
   │             │  (now appears)        │
   └─────────────┴───────────────────────┘
   ```

4. **Prefab is created!** The hierarchy object turns blue (prefab instance)

### Method 2: Create Empty Prefab

1. **Right-click in Project → Create → Prefab**
2. **Double-click prefab** to enter Prefab Mode
3. **Add GameObjects and components** in Prefab Mode
4. **Click back arrow** to exit Prefab Mode

### Working with Prefabs

```
┌──────────────────────────────────────────────────┐
│           PREFAB EDITING WORKFLOW                │
└──────────────────────────────────────────────────┘

Edit Prefab Asset:           Edit Instance:
┌────────────────┐          ┌─────────────────┐
│ Double-click   │          │ Select in Scene │
│ prefab in      │          │ Modify values   │
│ Project window │          │ in Inspector    │
│      ↓         │          │       ↓         │
│ Prefab Mode    │          │ [Apply] button  │
│ Edit original  │          │ to save to      │
│      ↓         │          │ prefab asset    │
│ Exit (back ←)  │          └─────────────────┘
│ All instances  │          OR                
│ updated!       │          ┌─────────────────┐
└────────────────┘          │ [Revert] button │
                            │ to discard      │
                            │ changes         │
                            └─────────────────┘
```

### Prefab Variants

Create variations of existing prefabs:

1. **Right-click on prefab → Create → Prefab Variant**
2. **Modify the variant** (changes only affect variant)
3. **Base prefab changes still apply** to variant

Example:
```
Base Prefab: "Enemy"
├─ Variant: "Enemy_Slime" (green, 50 HP)
├─ Variant: "Enemy_Goblin" (red, 100 HP)
└─ Variant: "Enemy_Boss" (purple, 500 HP)

Change base "Enemy" → affects all variants!
```

---

## Creating Tilemaps & Tile Palettes

Tilemaps are perfect for creating 2D grid-based levels (terrain, walls, floors).

### Setting Up a Tilemap

**Step 1: Create Tilemap GameObject**

```
Hierarchy → Right-click → 2D Object → Tilemap → Rectangular

This creates:
┌─────────────────────────────┐
│ Grid (parent)               │
│ └─ Tilemap                  │
│    ├─ Tilemap (Component)   │
│    └─ Tilemap Renderer      │
└─────────────────────────────┘
```

**Step 2: Create Tile Assets**

You need to convert sprites into Tile assets:

1. **Select your tile sprites** in Project window
2. **Drag sprites into a Tile Palette** (creates tiles automatically), OR
3. **Right-click → Create → 2D → Tiles → Rule Tile** (advanced)

**Step 3: Create Tile Palette**

```
Window → 2D → Tile Palette

Tile Palette Window:
┌────────────────────────────────────────┐
│ Create New Palette                     │
│ Name: Terrain                          │
│ Grid: Rectangular                      │
│ Cell Size: Automatic                   │
│ [Create]                               │
└────────────────────────────────────────┘
```

**Step 4: Add Tiles to Palette**

```
Drag sprites from Project window into Tile Palette:

Tile Palette:
┌─────────────────────────────────────────┐
│ Active Tilemap: [Tilemap ▼]            │
├─────────────────────────────────────────┤
│ ┌──┬──┬──┬──┬──┬──┐                    │
│ │🟩│🟫│🌊│🪨│🌸│🌳│ ← Your tiles       │
│ └──┴──┴──┴──┴──┴──┘                    │
│                                         │
│ Tools: [Brush] [Fill] [Pick] [Erase]   │
└─────────────────────────────────────────┘
```

**Step 5: Paint Tiles in Scene**

1. **Select Brush tool** in Tile Palette
2. **Click a tile** to select it
3. **Click in Scene view** to paint
4. **Hold Shift + Click** to fill area
5. **Hold Ctrl + Click** to erase

### Visual: Tilemap Painting Workflow

```
┌───────────────────────────────────────────────────┐
│              TILEMAP WORKFLOW                      │
└───────────────────────────────────────────────────┘

1. Import Tile Sprites
   └─ Assets/Sprites/Tiles/grass.png

2. Create Tile Palette
   └─ Window → 2D → Tile Palette

3. Drag Sprites to Palette
   └─ Creates Tile assets automatically

4. Create Tilemap in Scene
   └─ Hierarchy → 2D Object → Tilemap

5. Select Tilemap & Paint!
   ┌──────────────────────────┐
   │ Scene View               │
   │ ┌──┬──┬──┬──┬──┐         │
   │ │🟩│🟩│🟩│🟩│🟩│         │
   │ ├──┼──┼──┼──┼──┤         │
   │ │🟩│🟫│🟫│🟫│🟩│         │
   │ ├──┼──┼──┼──┼──┤         │
   │ │🟩│🟩│🟩│🟩│🟩│         │
   │ └──┴──┴──┴──┴──┘         │
   └──────────────────────────┘
```

### Tilemap Layers

Organize terrain with multiple tilemaps:

```
Hierarchy:
┌─────────────────────────────┐
│ Grid                        │
│ ├─ Tilemap_Ground (layer 0) │
│ ├─ Tilemap_Details (layer 1)│
│ ├─ Tilemap_Collision (layer 2) │
│ └─ Tilemap_Overlay (layer 3)│
└─────────────────────────────┘

Set Sorting Layer and Order in Layer
to control rendering order!
```

---

## Creating Materials & Shaders

Materials define how objects look (color, texture, effects).

### Creating a Material

1. **Right-click in Project → Create → Material**
2. **Name it** (e.g., "Water_Material")
3. **Configure in Inspector:**

```
Inspector (Material selected):
┌────────────────────────────────────┐
│ Water_Material                     │
├────────────────────────────────────┤
│ Shader: [Universal Render... ▼]   │
│                                    │
│ Surface Inputs:                    │
│ ├─ Base Map: [water_texture]      │
│ ├─ Base Color: Light Blue         │
│ ├─ Metallic: 0.5                  │
│ └─ Smoothness: 0.8                │
│                                    │
│ Emission:                          │
│ └─ [Checkbox] Enable               │
│    └─ Color: Cyan (glow)          │
└────────────────────────────────────┘
```

### Applying Materials

**To 3D Objects:**
- Drag material onto object in Scene view, OR
- Select object → assign in Renderer component

**To 2D Sprites:**
- Select sprite → Material property in Sprite Renderer

### Built-in Shaders

Unity provides many shader options:

```
Common Shaders:
├─ Universal Render Pipeline
│  ├─ Lit (default, with lighting)
│  └─ Unlit (no lighting, faster)
├─ Sprites
│  ├─ Default (2D sprites)
│  └─ Diffuse (sprites with lighting)
└─ UI
   └─ Default (UI elements)
```

### Custom Shaders (Advanced)

Create shader code for special effects:

1. **Right-click → Create → Shader → [Type]**
2. **Edit in code editor** (ShaderLab/HLSL)
3. **Assign to material**

---

## Importing External Assets

### Supported File Formats

| Asset Type | Formats |
|-----------|---------|
| **Images** | `.png`, `.jpg`, `.psd`, `.tga`, `.tiff`, `.gif`, `.bmp` |
| **3D Models** | `.fbx`, `.obj`, `.blend`, `.ma`, `.max`, `.dae` |
| **Audio** | `.mp3`, `.wav`, `.ogg`, `.aiff` |
| **Video** | `.mp4`, `.mov`, `.avi`, `.webm` |
| **Fonts** | `.ttf`, `.otf` |

### Import Methods

**Method 1: Drag & Drop**
```
1. Open file explorer
2. Select files
3. Drag into Unity Project window
4. Release in desired folder
```

**Method 2: Import via Menu**
```
Assets → Import New Asset...
└─ Browse to files
   └─ Select and Import
```

**Method 3: Copy to Assets Folder**
```
1. Copy files in file explorer
2. Paste into:
   unity-chronicles/Assets/[folder]/
3. Unity auto-detects and imports
```

### Import Settings

After importing, configure settings:

**For Sprites:**
```
- Texture Type: Sprite (2D and UI)
- Sprite Mode: Single/Multiple
- Pixels Per Unit: 16-100
- Filter Mode: Point (pixel art) / Bilinear (smooth)
- Compression: None/Low/High
```

**For Audio:**
```
- Load Type: Compressed in Memory (default)
- Compression Format: Vorbis (quality)
- Quality: 70-100%
- Preload Audio Data: Checked (small files)
```

**For 3D Models:**
```
- Scale Factor: 1 (adjust if needed)
- Mesh Compression: Off/Low/Medium/High
- Read/Write: Unchecked (performance)
- Optimize Mesh: Checked
- Import Materials: Yes
```

---

## Organizing Your Assets

Good organization is crucial for large projects!

### Recommended Folder Structure

```
Assets/
├── Audio/
│   ├── Music/
│   │   ├── MainTheme.mp3
│   │   └── BattleMusic.mp3
│   └── SFX/
│       ├── Footsteps/
│       ├── Combat/
│       └── UI/
├── Animations/
│   ├── Player/
│   ├── Enemies/
│   └── NPCs/
├── Materials/
│   ├── Terrain/
│   ├── Characters/
│   └── Effects/
├── Prefabs/
│   ├── Characters/
│   │   ├── Player.prefab
│   │   └── NPCs/
│   ├── Enemies/
│   ├── Items/
│   └── UI/
├── Resources/
│   └── RuntimeLoaded/
├── Scenes/
│   ├── MainMenu.unity
│   ├── Game.unity
│   └── TestScenes/
├── Scripts/
│   ├── Components/
│   ├── Systems/
│   ├── UI/
│   └── Utilities/
├── ScriptableObjects/
│   ├── Crops/
│   ├── Items/
│   ├── Recipes/
│   └── NPCs/
└── Sprites/
    ├── Characters/
    │   ├── Player/
    │   ├── Enemies/
    │   └── NPCs/
    ├── Tiles/
    │   ├── Terrain/
    │   ├── Buildings/
    │   └── Decorations/
    ├── Items/
    └── UI/
```

### Organization Tips

1. **Use Consistent Naming:**
   ```
   Good: player_idle_0, player_idle_1, player_walk_0
   Bad: idle1, playe walk, WALK_ANIMATION
   ```

2. **Group Related Assets:**
   ```
   Enemy_Slime/
   ├── slime_sprite.png
   ├── slime_prefab.prefab
   ├── slime_animation.anim
   └── slime_material.mat
   ```

3. **Use Labels:**
   - Select asset → Inspector → bottom
   - Add labels: "Essential", "Testing", "WIP"
   - Search by label in Project window

4. **Use Favorites:**
   - Drag frequently-used folders to Favorites
   - Quick access in Project window

---

## Adding Assets to Scenes

### Method 1: Drag from Project to Scene View

```
Visual Workflow:
┌────────────────────────────────────────┐
│ Project Window                         │
│ Player.prefab                          │
│     ↓ (click & drag)                   │
├────────────────────────────────────────┤
│ Scene View                             │
│         [Drop Here]                    │
│            ↓                           │
│    GameObject created at drop position │
└────────────────────────────────────────┘
```

**Best for**: Positioning objects visually

### Method 2: Drag from Project to Hierarchy

```
Project Window:
  Player.prefab
      ↓ (drag)
Hierarchy Window:
  [Drop Here]
      ↓
  New GameObject appears (at position 0,0,0)
```

**Best for**: Adding objects that need precise Transform values

### Method 3: Assign to Component Property

For referencing assets in scripts/components:

```
Example: Assigning a Sprite

1. Select GameObject in Hierarchy
2. View in Inspector
3. Find Sprite Renderer component
4. Drag sprite from Project → "Sprite" field

┌────────────────────────────────────┐
│ Sprite Renderer                    │
├────────────────────────────────────┤
│ Sprite: [Drag sprite here] 🎯     │
│ Color: White                       │
│ Flip: X☐ Y☐                       │
│ Draw Mode: Simple                  │
└────────────────────────────────────┘
```

### Method 4: Instantiate at Runtime (Code)

Load and create objects via scripts:

```csharp
// Load prefab from Resources folder
GameObject prefab = Resources.Load<GameObject>("Enemies/Slime");

// Instantiate at position
Vector3 spawnPos = new Vector3(10, 0, 0);
GameObject instance = Instantiate(prefab, spawnPos, Quaternion.identity);
```

### Adding Multiple Instances

**Quick Duplication:**
```
1. Add first instance to scene
2. Select it
3. Press Ctrl+D (Cmd+D on Mac) to duplicate
4. Move duplicate to new position
5. Repeat as needed
```

**Grid Snap:**
```
Enable grid snapping:
1. Top toolbar: Grid icon
2. Hold Ctrl while moving objects
3. Objects snap to grid
4. Adjust grid size in: Edit → Grid and Snap Settings
```

---

## Unity Asset Store

The Unity Asset Store provides thousands of free and paid assets.

### Accessing the Asset Store

**Method 1: In Unity Editor**
```
Window → Asset Store
(Opens in browser)
```

**Method 2: Web Browser**
```
Visit: https://assetstore.unity.com
Sign in with Unity account
```

### Finding Assets

```
Asset Store Interface:
┌─────────────────────────────────────────┐
│ Search: [2D sprites]  [🔍]              │
├─────────────────────────────────────────┤
│ Filters:                                │
│ ☑ Free         ☐ On Sale               │
│ ☐ Paid         ☐ Plus/Pro              │
│                                         │
│ Category:                               │
│ ▶ 2D                                    │
│   ├─ Characters                         │
│   ├─ Environments                       │
│   └─ Sprites                           │
└─────────────────────────────────────────┘
```

### Downloading Assets

1. **Find asset** on Asset Store
2. **Click "Add to My Assets"** (free) or **"Buy Now"** (paid)
3. **Open Package Manager** in Unity: `Window → Package Manager`
4. **Select "My Assets"** from dropdown
5. **Find your asset** in list
6. **Click "Download"**
7. **Click "Import"** after download
8. **Select what to import** (checkboxes)
9. **Click "Import"** button

```
Package Manager:
┌────────────────────────────────────────┐
│ [Packages: My Assets ▼]               │
├────────────────────────────────────────┤
│ 🎨 Fantasy 2D Tileset                  │
│    by ArtistName                       │
│    [Download] or [Import]              │
│                                        │
│ 🌲 Nature Sprite Pack                  │
│    by StudioName                       │
│    [Downloaded] [Import]               │
└────────────────────────────────────────┘
```

### Asset Store Best Practices

✅ **Do:**
- Read reviews and ratings
- Check Unity version compatibility
- Download asset documentation
- Test in a sample scene first
- Keep assets organized in folders

❌ **Don't:**
- Import everything (select only needed files)
- Mix incompatible asset styles
- Forget to credit artists (if required)

### Recommended Free Assets for 2D Games

**Sprites & Tilesets:**
- "2D Pixel Art Platformer Tileset"
- "Free 2D Mega Pack"
- "Free Pixel Font"

**Tools:**
- "ProBuilder" (level design)
- "Cinemachine" (camera control)
- "TextMesh Pro" (better text)

**Effects:**
- "Particle Effect Pack"
- "2D Laser Pack"

---

## Best Practices

### Asset Naming Conventions

```
Format: [Type]_[Name]_[Variant]_[Number]

Examples:
✅ sprite_player_idle_0.png
✅ prefab_enemy_slime.prefab
✅ audio_footstep_grass_1.wav
✅ mat_water_animated.mat

❌ pLAYer1.png
❌ NEW SPRITE FINAL FINAL.png
❌ temp123.prefab
```

### File Size Management

**Optimize Textures:**
```
- Use appropriate sizes (don't import 4K for mobile)
- Enable compression for large files
- Use sprite atlases for many small sprites
- Use appropriate format (PNG for transparency)
```

**Optimize Audio:**
```
- Compress music files (Vorbis)
- Use WAV only for short, critical sounds
- Reduce sample rate if quality allows (22kHz)
```

**Optimize Models:**
```
- Reduce polygon count
- Remove unused animations
- Combine materials where possible
```

### Version Control

If using Git:

```
.gitignore should include:
/[Ll]ibrary/
/[Tt]emp/
/[Oo]bj/
/[Bb]uild/
/[Bb]uilds/
/[Ll]ogs/
*.csproj
*.sln
*.user
*.userprefs
```

**Commit Assets:**
- ✅ Source files (`.blend`, `.psd`)
- ✅ Imported assets (sprites, audio)
- ✅ Prefabs, materials, scenes
- ✅ Scriptable Object assets
- ❌ Library folder
- ❌ Build outputs

### Performance Tips

1. **Use Object Pooling** for frequently spawned prefabs
2. **Texture Atlases** reduce draw calls
3. **Sprite Packing** combines sprites automatically
4. **Lazy Loading** via Resources.Load() or Addressables
5. **Unload Unused Assets** with Resources.UnloadUnusedAssets()

### Common Pitfalls

❌ **Too Many Draw Calls**
- Solution: Use sprite atlases, combine meshes

❌ **Missing References**
- Solution: Use prefabs, avoid deleting referenced assets

❌ **Huge File Sizes**
- Solution: Compress textures and audio

❌ **Unorganized Project**
- Solution: Follow folder structure, use naming conventions

---

## Project-Specific Examples

### For Chronicles of a Drifter

Based on the current project structure, here are specific workflows:

#### Example 1: Creating a New Crop

```
Step-by-Step Workflow:
┌──────────────────────────────────────────┐
│ 1. CREATE SPRITES                        │
│    └─ growth_stage_0.png (seedling)      │
│    └─ growth_stage_1.png (young)         │
│    └─ growth_stage_2.png (growing)       │
│    └─ growth_stage_3.png (mature)        │
│                                          │
│ 2. IMPORT INTO UNITY                     │
│    └─ Drag into Assets/Sprites/Crops/    │
│    └─ Set as Sprite (2D and UI)          │
│    └─ Pixels Per Unit: 16                │
│                                          │
│ 3. CREATE CROP SCRIPTABLE OBJECT        │
│    └─ Right-click Project window         │
│    └─ Create → Chronicles → Farming →    │
│       Crop                               │
│    └─ Name: "Crop_Tomato"                │
│                                          │
│ 4. CONFIGURE CROP DATA                   │
│    └─ Assign growth stage sprites        │
│    └─ Set days to mature: 8              │
│    └─ Set valid seasons: Spring, Summer  │
│    └─ Set harvest yield: 1-3             │
│                                          │
│ 5. TEST IN SCENE (via FarmingManager)   │
│    └─ Reference Crop_Tomato in script    │
│    └─ Call PlantSeed() at runtime        │
└──────────────────────────────────────────┘
```

#### Example 2: Creating an Enemy Prefab

```
1. CREATE ENEMY SPRITE
   └─ Import slime.png → Assets/Sprites/Enemies/

2. CREATE GAMEOBJECT IN SCENE
   Hierarchy → Create Empty → "Enemy_Slime"

3. ADD COMPONENTS
   ├─ Sprite Renderer
   │  └─ Assign slime.png sprite
   ├─ Circle Collider 2D
   ├─ Rigidbody 2D
   │  └─ Body Type: Dynamic
   │  └─ Gravity Scale: 0 (top-down)
   ├─ Health (Script)
   │  └─ Max Health: 50
   └─ Enemy AI (Script)
      ├─ Move Speed: 2.0
      ├─ Wander Range: 5.0
      ├─ Detection Range: 8.0
      └─ Attack Range: 1.5

4. CREATE PREFAB
   └─ Drag "Enemy_Slime" from Hierarchy →
      Assets/Prefabs/Enemies/

5. DELETE FROM SCENE
   (Keep only prefab, spawn at runtime)
```

#### Example 3: Setting Up Farm Tilemap

```
TILEMAP SETUP FOR FARMING:
┌──────────────────────────────────────────┐
│ 1. CREATE SPRITES                        │
│    └─ dirt_tile.png (base soil)          │
│    └─ tilled_dirt.png (after using hoe) │
│    └─ watered_dirt.png (after watering)  │
│                                          │
│ 2. IMPORT & CREATE TILES                 │
│    └─ Import into Assets/Sprites/Tiles/  │
│    └─ Create Tile Palette: "Farm"        │
│    └─ Drag sprites into palette          │
│                                          │
│ 3. CREATE TILEMAPS IN SCENE              │
│    Hierarchy:                            │
│    └─ Grid                               │
│       ├─ Tilemap_Ground (base)           │
│       ├─ Tilemap_Farm (farmable area)    │
│       └─ Tilemap_Crops (planted crops)   │
│                                          │
│ 4. CONFIGURE TILEMAPS                    │
│    FarmingManager script:                │
│    └─ Assign Tilemap_Farm                │
│    └─ Assign tile references             │
│       ├─ Tilled Tile                     │
│       └─ Watered Tile                    │
│                                          │
│ 5. PAINT BASE TERRAIN                    │
│    └─ Use Tile Palette → Brush           │
│    └─ Paint dirt on Tilemap_Ground       │
│                                          │
│ 6. TEST FARMING                          │
│    └─ Run game                           │
│    └─ Call TillSoil() on tile            │
│    └─ Tile should change to tilled       │
└──────────────────────────────────────────┘
```

#### Example 4: Creating a Tool Icon

```
TOOL ICON WORKFLOW:
┌──────────────────────────────────────────┐
│ 1. DESIGN ICON                           │
│    └─ Create 64x64 PNG (hoe_icon.png)    │
│    └─ Transparent background             │
│    └─ Clear, recognizable design         │
│                                          │
│ 2. IMPORT                                │
│    └─ Drag into Assets/Sprites/UI/Icons/ │
│    └─ Texture Type: Sprite (2D and UI)   │
│    └─ Pixels Per Unit: 64                │
│                                          │
│ 3. CREATE TOOL DATA                      │
│    └─ Right-click → Create → Chronicles  │
│       → Tools → Tool                     │
│    └─ Name: "Tool_Hoe"                   │
│                                          │
│ 4. ASSIGN ICON                           │
│    Tool_Hoe Inspector:                   │
│    └─ Tool Name: "Hoe"                   │
│    └─ Tool Type: Hoe                     │
│    └─ Icon: [hoe_icon sprite]            │
│    └─ Tier: Basic                        │
│    └─ Stamina Cost: 2                    │
│                                          │
│ 5. USE IN UI                             │
│    └─ Reference Tool_Hoe in inventory    │
│    └─ Display icon in hotbar UI          │
└──────────────────────────────────────────┘
```

### Recommended Asset Creation Order

For Chronicles of a Drifter development:

```
Priority 1 (Essential):
├─ Player sprites (idle, walk animations)
├─ Basic terrain tiles (grass, dirt)
├─ Crop sprites (3-4 growth stages each)
├─ Tilled/watered dirt tiles
└─ UI elements (inventory slots, buttons)

Priority 2 (Core Gameplay):
├─ Enemy sprites (2-3 types)
├─ Tool sprites (hoe, watering can, etc.)
├─ Item icons (crops, materials)
├─ NPC character sprites
└─ Building tiles (walls, floors, roof)

Priority 3 (Polish):
├─ Particle effects (water splash, dig dust)
├─ Environmental decorations (flowers, rocks)
├─ Weather effects (rain, snow)
├─ UI animations
└─ Sound effects

Priority 4 (Enhancement):
├─ Additional biome tiles
├─ Seasonal variants
├─ Boss enemy sprites
├─ Advanced visual effects
└─ Music tracks
```

---

## Quick Reference Cheat Sheet

### Keyboard Shortcuts

```
Project Window:
├─ Ctrl+D: Duplicate selected asset
├─ F2: Rename asset
├─ Delete: Delete asset
└─ Ctrl+F: Search/Filter

Scene View:
├─ F: Frame selected object
├─ W: Move tool
├─ E: Rotate tool
├─ R: Scale tool
├─ T: Rect transform tool (2D)
├─ Ctrl+D: Duplicate object
└─ Ctrl+Shift+F: Align view to object

General:
├─ Ctrl+S: Save scene
├─ Ctrl+N: New scene
├─ Ctrl+O: Open scene
├─ Ctrl+Z: Undo
├─ Ctrl+Y: Redo
├─ Ctrl+P: Play/Stop
└─ Ctrl+Shift+P: Pause
```

### Common Asset Locations

```
Character sprites:    Assets/Sprites/Characters/
Enemy sprites:        Assets/Sprites/Enemies/
Tile sprites:         Assets/Sprites/Tiles/
UI sprites:           Assets/Sprites/UI/
Item icons:           Assets/Sprites/Items/

Character prefabs:    Assets/Prefabs/Characters/
Enemy prefabs:        Assets/Prefabs/Enemies/
Item prefabs:         Assets/Prefabs/Items/
UI prefabs:           Assets/Prefabs/UI/

Crop data:            Assets/ScriptableObjects/Crops/
Tool data:            Assets/ScriptableObjects/Tools/
Recipe data:          Assets/ScriptableObjects/Recipes/
NPC data:             Assets/ScriptableObjects/NPCs/
```

### File Type Reference

```
.unity          Scene file
.prefab         Prefab asset
.asset          Scriptable Object
.mat            Material
.anim           Animation clip
.controller     Animator Controller
.cs             C# Script
.png/.jpg       Image/Sprite
.mp3/.wav/.ogg  Audio
.fbx/.obj       3D Model
.ttf/.otf       Font
.shader         Shader code
```

---

## Troubleshooting

### Common Issues & Solutions

**Issue: Sprite appears blurry**
```
Solution:
1. Select sprite in Project
2. Inspector → Filter Mode: Point (no filter)
3. Click Apply
```

**Issue: Imported sprite is too small/large**
```
Solution:
1. Select sprite
2. Inspector → Pixels Per Unit: Adjust value
   (Lower = larger, Higher = smaller)
3. Click Apply
```

**Issue: Can't see asset in Project window**
```
Solutions:
- Check search filter (clear search box)
- Check if hidden folder (click eye icon)
- Refresh Project: Assets → Refresh
- Reimport: Right-click asset → Reimport
```

**Issue: Prefab instances won't update**
```
Solutions:
- Select prefab in Project → Open Prefab
- Edit and save
- OR: Override instance → Apply to prefab
```

**Issue: Tilemap not painting**
```
Solutions:
- Ensure Tilemap selected in Tile Palette
- Check if correct layer (not locked)
- Verify Tile Palette has tiles
- Try different brush tool
```

**Issue: Asset reference is missing (shows "None")**
```
Solutions:
- Asset was deleted or moved
- Reassign the asset manually
- Check if asset is in Resources folder
```

---

## Additional Resources

### Official Unity Documentation

- **Unity Manual**: https://docs.unity3d.com/Manual/
- **Scripting API**: https://docs.unity3d.com/ScriptReference/
- **2D Tilemap**: https://docs.unity3d.com/Manual/Tilemap.html
- **Sprites**: https://docs.unity3d.com/Manual/Sprites.html
- **Asset Workflow**: https://docs.unity3d.com/Manual/AssetWorkflow.html

### Learning Resources

- **Unity Learn**: https://learn.unity.com
- **YouTube**: Brackeys, Sebastian Lague, Code Monkey
- **Reddit**: r/Unity2D, r/Unity3D
- **Discord**: Unity Community Server

### Free Asset Resources

**Sprites & Graphics:**
- OpenGameArt.org
- Itch.io (free game assets)
- Kenney.nl (huge free library)
- CraftPix.net (free section)

**Audio:**
- Freesound.org
- OpenGameArt.org (audio section)
- Incompetech (Kevin MacLeod music)

**Fonts:**
- Google Fonts
- DaFont.com
- FontSquirrel.com

---

## Conclusion

You now have a comprehensive guide to generating and managing assets in Unity! Remember:

✅ **Key Takeaways:**
1. **Organization is crucial** - Use consistent folder structure and naming
2. **Import settings matter** - Configure sprites, audio, and models correctly
3. **Prefabs save time** - Use them for reusable objects
4. **Tilemaps are powerful** - Perfect for grid-based 2D levels
5. **Test iteratively** - Import small batches, test, then continue
6. **Asset Store is your friend** - Don't reinvent the wheel

### Next Steps

For **Chronicles of a Drifter**:
1. Start with player and crop sprites
2. Set up farming Tilemap
3. Create tool prefabs
4. Build UI assets
5. Test each system incrementally

Happy game developing! 🎮

---

**Document Version:** 1.0  
**Last Updated:** 2025-11-11  
**For:** Unity 6 LTS (6000.0.x)  
**Project:** Chronicles of a Drifter
