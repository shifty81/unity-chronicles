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
Unity is using a cached version of the `com.unity.2d.tilemap.extras` package that is incompatible with Unity 6 LTS. Despite the manifest specifying version 6.0.1, Unity may still be referencing an older cached version in the `Library/PackageCache` folder.

**Solution:**
1. **Close Unity Editor completely**
2. **Delete the Library folder:**
   ```bash
   # On Windows (PowerShell)
   Remove-Item -Recurse -Force Library

   # On macOS/Linux
   rm -rf Library
   ```
3. **Reopen the project in Unity**
   - Unity will regenerate the Library folder
   - The correct package version (6.0.1) will be downloaded from the Unity Package Registry
   - Compilation errors should be resolved

**Alternative Solution:**
If you want to preserve other cached data:
1. Close Unity Editor
2. Delete only the PackageCache folder:
   ```bash
   # On Windows (PowerShell)
   Remove-Item -Recurse -Force Library\PackageCache

   # On macOS/Linux
   rm -rf Library/PackageCache
   ```
3. Reopen Unity

**Prevention:**
- Always use Unity Hub to manage Unity versions
- Keep Unity 6 LTS updated to the latest patch version
- When updating packages, close and reopen Unity to ensure cache is refreshed

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
