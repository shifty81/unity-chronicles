# Troubleshooting Guide

This document addresses common issues when working with the Unity Chronicles project.

## Compilation Errors

### TileTemplate Type Not Found

**Error Message:**
```
Library\PackageCache\com.unity.2d.tilemap.extras@[hash]\Editor\Tiles\AutoTile\AutoTileTemplate.cs(12,37): 
error CS0246: The type or namespace name 'TileTemplate' could not be found (are you missing a using directive or an assembly reference?)

Library\PackageCache\com.unity.2d.tilemap.extras@[hash]\Editor\Tiles\RuleTile\RuleTileTemplate.cs(13,37): 
error CS0246: The type or namespace name 'TileTemplate' could not be found (are you missing a using directive or an assembly reference?)
```

**Cause:**
Unity is using a cached version of the `com.unity.2d.tilemap.extras` package from version 6.0.1, which has a bug where `AutoTileTemplate` and `RuleTileTemplate` inherit from a non-existent `TileTemplate` base class. Despite the manifest specifying version 7.0.0 (which fixes the bug), Unity may still be referencing an older cached version in the `Library/PackageCache` folder or even a system-wide Unity package cache.

**Solution:**

**Step 1: Verify the issue**
First, run the verification script to confirm the problem:
```bash
# On Windows (PowerShell)
.\verify-packages.ps1

# On macOS/Linux/Git Bash
./verify-packages.sh
```
This will check your package installation and identify the specific issue.

**Step 2: Choose the appropriate cleanup method**

**Option A: Standard cleanup (Try this first)**
```bash
# On Windows (PowerShell)
.\cleanup-unity-cache.ps1

# On macOS/Linux/Git Bash
./cleanup-unity-cache.sh
```
These interactive scripts will guide you through cleaning the package cache safely.

**Option B: Advanced cleanup (If standard cleanup didn't work)**

If you're **still getting errors after running the standard cleanup**, use the advanced script:
```bash
# On Windows (PowerShell)
.\advanced-cleanup.ps1

# On macOS/Linux/Git Bash
./advanced-cleanup.sh
```

The advanced cleanup script performs more aggressive cache clearing:
- Removes project Library folder completely
- Cleans packages-lock.json
- **Also cleans global Unity package caches** (system-wide cache that persists across projects)
- Removes Temp folder

**Important Notes:**
- **Close Unity Hub** in addition to Unity Editor before running cleanup scripts
- The global cache cleanup is **safe** - Unity will regenerate it automatically
- Allow 5-10 minutes for Unity to reimport all assets after cleanup

**Option C: Manual cleanup**
If you prefer to do it manually:

1. **Close Unity Editor AND Unity Hub completely**
2. **Delete the Library folder:**
   ```bash
   # On Windows (PowerShell)
   Remove-Item -Recurse -Force Library

   # On macOS/Linux
   rm -rf Library
   ```
3. **Delete packages-lock.json:**
   ```bash
   # On Windows (PowerShell)
   Remove-Item Packages\packages-lock.json

   # On macOS/Linux
   rm Packages/packages-lock.json
   ```
4. **(Optional but recommended) Clean global Unity cache:**
   ```bash
   # On Windows (PowerShell)
   Remove-Item -Recurse -Force $env:LOCALAPPDATA\Unity\cache

   # On macOS
   rm -rf ~/Library/Unity/cache

   # On Linux
   rm -rf ~/.config/unity3d/cache
   ```
5. **Reopen Unity Hub, then open the project**
   - Unity will regenerate the Library folder
   - The correct package version (6.0.1) will be downloaded from the Unity Package Registry
   - Wait for asset reimport to complete (5-10 minutes)
   - Compilation errors should be resolved

**Still Having Issues?**

If errors persist after advanced cleanup:

1. **Verify Unity version:**
   - Ensure you're using Unity 6 LTS (6000.0.x)
   - Check in Unity Hub → Installs
   - This project requires Unity 6000.0.62f1 or later

2. **Check for Unity Hub updates:**
   - Update Unity Hub to the latest version
   - Sometimes old Unity Hub versions cache packages incorrectly

3. **Try opening from Unity Hub:**
   - Don't open Unity directly
   - Always open through Unity Hub
   - Let Unity Hub manage the package resolution

4. **Check Unity Registry connectivity:**
   - Ensure you can reach packages.unity.com
   - Check firewall/proxy settings
   - Try toggling "Enable Pre-release Packages" in Package Manager

5. **Last resort - Nuclear option:**
   ```bash
   # Close Unity and Unity Hub completely
   # Delete ALL Unity caches
   
   # Windows
   Remove-Item -Recurse -Force $env:LOCALAPPDATA\Unity
   Remove-Item -Recurse -Force $env:APPDATA\Unity
   
   # macOS
   rm -rf ~/Library/Unity
   rm -rf ~/Library/Preferences/com.unity3d.*
   
   # Linux
   rm -rf ~/.config/unity3d
   rm -rf ~/.local/share/unity3d
   
   # Then reopen project through Unity Hub
   ```

**Prevention:**
- Always use Unity Hub to manage Unity versions and projects
- Keep Unity 6 LTS updated to the latest patch version
- When updating packages, close and reopen Unity to ensure cache is refreshed
- Don't manually edit PackageCache - let Unity manage it
- Close Unity Hub when running cleanup scripts

## Runtime Warnings

### Multiple Managers Loaded

**Warning Message:**
```
Multiple managers are loaded of type: TimeManager
```

**Cause:**
This warning indicates that multiple instances of the TimeManager MonoBehaviour exist in the scene or across multiple loaded scenes. This violates the singleton pattern used by manager scripts.

**Solution:**

1. **Check the current scene:**
   - Open `Assets/Scenes/MainScene.unity` in Unity Editor
   - In the Hierarchy window, search for "TimeManager"
   - If multiple TimeManager GameObjects exist, delete all but one
   - If none exist, create one:
     1. Right-click in Hierarchy → Create Empty
     2. Name it "TimeManager"
     3. Add Component → Scripts → Time → Time Manager

2. **Check for additively loaded scenes:**
   - If you're loading scenes additively, ensure only the base scene contains manager singletons
   - Use `DontDestroyOnLoad` for managers that should persist across scenes (already implemented)

3. **Check prefabs:**
   - Search your prefabs for any that include TimeManager components
   - Manager components should only be in the scene, not in prefabs that are instantiated

4. **Clean scene reload:**
   - File → New Scene (don't save changes)
   - File → Open Scene → MainScene.unity
   - This ensures you start with a clean scene state

**Prevention:**
- Only create one GameObject for each manager type per scene
- Don't duplicate manager GameObjects when setting up the scene
- Use the singleton pattern's built-in protection (already implemented in code)
- When loading scenes additively, use one "Manager Scene" that persists

## Package Update Issues

### Packages Not Updating

If packages aren't updating correctly after modifying `Packages/manifest.json`:

1. Close Unity Editor
2. Delete the `Library/PackageCache` folder
3. Delete `Packages/packages-lock.json`
4. Reopen Unity - packages will be re-resolved from the manifest

### Package Version Conflicts

If you see warnings about package version conflicts:

1. Check `Packages/manifest.json` for version requirements
2. Verify Unity version compatibility: This project requires Unity 6 LTS (6000.0.x)
3. Check Unity documentation for package compatibility matrix
4. Update or downgrade conflicting packages as needed

## Build Issues

### Missing Assembly References

If you see errors about missing assembly references when building:

1. Check that all required packages are installed
2. Verify Package Manager (Window → Package Manager) shows all packages as downloaded
3. Try Assets → Reimport All
4. If issue persists, delete Library folder and reopen project

### Platform-Specific Issues

**WebGL builds:**
- Not yet supported in this project
- Planned for future release

**Mobile platforms:**
- Ensure the correct build target is selected in Build Settings
- Some packages may require platform-specific setup

## Editor Issues

### Unity Editor Crashes on Opening Project

1. Ensure you're using Unity 6 LTS (6000.0.x) or later
2. Delete the Library folder before opening
3. Check system requirements for Unity 6 LTS
4. Update graphics drivers
5. Try opening in safe mode: Unity.exe -force-d3d11 (Windows)

### Slow Editor Performance

1. Close other Unity projects
2. Exclude project folders from antivirus scanning
3. Use an SSD for better performance
4. Increase Unity's cache size (Preferences → Cache Server)

## Development Workflow Tips

### Before Committing Changes

- Never commit the `Library/` folder (already in .gitignore)
- Don't commit `Temp/` or build folders
- Keep `Packages/manifest.json` and `Packages/packages-lock.json` in version control
- Test your changes in a clean environment before committing

### When Pulling Changes

If others have updated packages:
1. Pull changes from git
2. Close Unity if open
3. Delete `Library/PackageCache`
4. Reopen Unity to download updated packages

### Using Different Unity Versions

This project is designed for Unity 6 LTS. If you must use a different version:
- Check package compatibility in the Unity Package Manager
- Some features may not work correctly
- Consider using Unity Hub to manage multiple Unity versions

## Getting Help

If you continue to experience issues:

1. **Check the logs:**
   - Unity logs are in `Library/Logs/`
   - Console errors often provide detailed information

2. **Search existing issues:**
   - [GitHub Issues](https://github.com/shifty81/unity-chronicles/issues)
   - Unity Forums
   - Unity Answers

3. **Create a new issue:**
   - Include Unity version
   - Include error messages (full text)
   - Include steps to reproduce
   - Include system information (OS, hardware)

## Quick Reference

### Clean Project Start
```bash
# Full clean (safest for major issues)
rm -rf Library/
rm -rf Temp/
# Reopen in Unity

# Package-only clean (for package issues)
rm -rf Library/PackageCache/
rm Packages/packages-lock.json
# Reopen in Unity
```

### Verify Project Health
1. Open project in Unity 6 LTS
2. Check Console for errors (Ctrl+Shift+C / Cmd+Shift+C)
3. Check Package Manager (Window → Package Manager)
4. Verify all packages show "Up to date"
5. Try Play mode to test runtime functionality

---

**Last Updated:** November 2025  
**Unity Version:** 6 LTS (6000.0.x)  
**Project:** Chronicles of a Drifter
