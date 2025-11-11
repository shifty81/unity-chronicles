# Quick Fix Guide

## TileTemplate Compilation Error

**Error:**
```
Library\PackageCache\com.unity.2d.tilemap.extras@[hash]\Editor\Tiles\AutoTile\AutoTileTemplate.cs(12,37): 
error CS0246: The type or namespace name 'TileTemplate' could not be found
```

**Quick Fix:**
```bash
# Windows PowerShell
.\cleanup-unity-cache.ps1

# macOS/Linux/Git Bash  
./cleanup-unity-cache.sh
```

**Manual Fix:**
1. Close Unity Editor
2. Delete `Library` folder
3. Reopen project in Unity

**Why it works:** Forces Unity to re-download the correct package version (6.0.1) instead of using the old cached version.

---

## Multiple TimeManager Warning

**Warning:**
```
Multiple managers are loaded of type: TimeManager
```

**Quick Fix:**
1. Open `Assets/Scenes/MainScene.unity`
2. Search Hierarchy for "TimeManager"
3. Delete duplicate instances (keep only one)
4. If none exist, create one:
   - Right-click Hierarchy → Create Empty
   - Name it "TimeManager"
   - Add Component → Scripts → Time → Time Manager

**Why it happens:** Multiple TimeManager GameObjects exist in the scene or are created across scene loads.

---

## More Help

See [TROUBLESHOOTING.md](TROUBLESHOOTING.md) for detailed solutions.
