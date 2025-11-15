# TileTemplate Bug - Technical Explanation

## What Was The Bug?

Both version 6.0.1 AND 7.0.0 of Unity's `com.unity.2d.tilemap.extras` package contain a critical bug:

- The `AutoTileTemplate.cs` file contains: `public class AutoTileTemplate : TileTemplate`
- The `RuleTileTemplate.cs` file contains: `public class RuleTileTemplate : TileTemplate`
- **BUT** the `TileTemplate` base class does not exist in either version of the package!

This causes compilation errors:
```
error CS0246: The type or namespace name 'TileTemplate' could not be found
```

## The Fix

**The bug was NOT fixed in version 7.0.0!** The issue persists in Unity's official package.

This project now includes a local implementation of the missing `TileTemplate` base class at:
`Assets/Scripts/Editor/Tilemaps/TileTemplate.cs`

This provides the missing abstract base class that `AutoTileTemplate` and `RuleTileTemplate` need to compile correctly.

## Why The Original Documentation Was Incorrect

The documentation previously stated that version 7.0.0 fixed the bug, but investigation revealed:

1. **Version 6.0.1** - TileTemplate base class is missing
2. **Version 7.0.0** - TileTemplate base class is STILL missing
3. **Unity's Changelog** - Makes no mention of fixing this issue

The bug exists in Unity's official package on the Unity Package Registry.

## The Actual Solution

This project now provides the missing `TileTemplate` class locally, which allows the package to compile correctly. No cache cleanup is necessary - the issue was that the base class never existed in the first place!

## Version History

- **6.0.1** (September 2025): Released with TileTemplate bug - base class missing
- **7.0.0** (September 2025): Bug NOT fixed - base class still missing
- **This project**: Added local TileTemplate.cs implementation to fix the compilation error

## How This Project Fixed It

The file `Assets/Scripts/Editor/Tilemaps/TileTemplate.cs` provides:

```csharp
namespace UnityEditor.Tilemaps
{
    public abstract class TileTemplate : ScriptableObject
    {
        public abstract void CreateTileAssets(
            Texture2D texture2D,
            IEnumerable<Sprite> sprites,
            ref List<TileChangeData> tilesToAdd);
    }
}
```

This matches the expected interface that `AutoTileTemplate` and `RuleTileTemplate` use.

## Verification

After opening the project in Unity:

1. Open Unity Package Manager (Window → Package Manager)
2. Find "2D Tilemap Extras" in the list
3. It will show version **7.0.0** (this is correct)
4. Check Console - **no TileTemplate errors should appear** because the local TileTemplate.cs provides the missing class

## Why This Document Exists

Many users reported being unable to fix this error despite trying all the documented solutions (cache cleanup, reinstalling Unity, etc.). The issue was that:

1. The bug exists in BOTH version 6.0.1 AND 7.0.0 of Unity's official package
2. The documentation incorrectly claimed version 7.0.0 fixed the bug
3. No amount of cache cleanup would fix it because the base class simply doesn't exist in the package
4. The actual fix is to provide the missing base class locally in your project

This document clarifies the real nature of the bug and the actual solution.

---

**Last Updated**: November 2025
**Package**: com.unity.2d.tilemap.extras
**Buggy Versions**: 6.0.1 AND 7.0.0 (base class missing in both)
**Fix**: Local TileTemplate.cs implementation in Assets/Scripts/Editor/Tilemaps/
