# Quick Fix Guide

## TileTemplate Compilation Error

**Error:**
```
Library\PackageCache\com.unity.2d.tilemap.extras@[hash]\Editor\Tiles\AutoTile\AutoTileTemplate.cs(12,37): 
error CS0246: The type or namespace name 'TileTemplate' could not be found
```

**Step 1: Verify the problem**
```bash
# Windows PowerShell
.\verify-packages.ps1

# macOS/Linux/Git Bash  
./verify-packages.sh
```

**Step 2: Standard Fix (Try this first)**
```bash
# Windows PowerShell
.\cleanup-unity-cache.ps1

# macOS/Linux/Git Bash  
./cleanup-unity-cache.sh
```

**Step 3: Advanced Fix (If standard fix didn't work)**

Still getting errors? Try the advanced cleanup:
```bash
# Windows PowerShell
.\advanced-cleanup.ps1

# macOS/Linux/Git Bash  
./advanced-cleanup.sh
```

**Important:** Close **both Unity Editor AND Unity Hub** before running cleanup scripts.

**Manual Fix:**
1. Close Unity Editor AND Unity Hub
2. Delete `Library` folder
3. Delete `Packages/packages-lock.json`
4. (Optional) Delete Unity global cache:
   - Windows: `%LOCALAPPDATA%\Unity\cache`
   - macOS: `~/Library/Unity/cache`
   - Linux: `~/.config/unity3d/cache`
5. Reopen project through Unity Hub

**Why it works:** Forces Unity to re-download the correct package version (6.0.1) instead of using old cached versions. The advanced cleanup also clears system-wide Unity caches that can persist across projects.

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
