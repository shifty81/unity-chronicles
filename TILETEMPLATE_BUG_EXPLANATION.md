# TileTemplate Bug - Technical Explanation

## What Was The Bug?

Version 6.0.1 of Unity's `com.unity.2d.tilemap.extras` package contained a critical bug:

- The `AutoTileTemplate.cs` file contained: `public class AutoTileTemplate : TileTemplate`
- The `RuleTileTemplate.cs` file contained: `public class RuleTileTemplate : TileTemplate`
- **BUT** the `TileTemplate` base class did not exist in the package!

This caused compilation errors:
```
error CS0246: The type or namespace name 'TileTemplate' could not be found
```

## The Fix

Unity released version **7.0.0** of the package which fixes this bug. This project has been updated to use 7.0.0.

## Why Cleaning Caches Is Still Necessary

Even though the project specifies version 7.0.0 in `Packages/manifest.json`, you may still encounter the error because:

1. **Unity caches packages** in multiple locations:
   - Project-level: `Library/PackageCache/`
   - System-level: `%LOCALAPPDATA%\Unity\cache` (Windows), `~/Library/Unity/cache` (macOS), `~/.config/unity3d/cache` (Linux)

2. **Unity may prefer cached versions** over downloading fresh ones from the registry

3. **The buggy version (6.0.1) may still be cached** from previous projects or Unity versions

## Solution

Run the cleanup scripts provided with this project:
- **Standard cleanup**: `cleanup-unity-cache.ps1` / `cleanup-unity-cache.sh`
- **Advanced cleanup** (if standard doesn't work): `advanced-cleanup.ps1` / `advanced-cleanup.sh`

These scripts clear the caches, forcing Unity to download version 7.0.0 from the Unity Package Registry.

## Version History

- **6.0.1** (September 2025): Released with TileTemplate bug
- **7.0.0** (September 2025): Bug fixed
- **This project**: Updated to 7.0.0 to avoid the bug

## Verification

After cleaning caches and reopening the project, you can verify the correct version is loaded:

1. Open Unity Package Manager (Window → Package Manager)
2. Find "2D Tilemap Extras" in the list
3. Verify it shows version **7.0.0**
4. Check Console - no TileTemplate errors should appear

## Why This Document Exists

Many users reported being unable to fix this error despite trying all the documented solutions. The issue was that the documentation focused on cache cleanup without explaining that version 6.0.1 itself was buggy. This document clarifies:

1. The bug is in the package itself (version 6.0.1)
2. The project has been updated to use the fixed version (7.0.0)
3. Cache cleanup is still needed to ensure Unity uses the fixed version

---

**Last Updated**: November 2025
**Package**: com.unity.2d.tilemap.extras
**Buggy Version**: 6.0.1
**Fixed Version**: 7.0.0+
