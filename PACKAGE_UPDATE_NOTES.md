# Package Update Notes - November 2025

## Unity 6 LTS Compatibility Fix - Version 7.0.0 Update

### Problem
The project was experiencing compilation errors when opened in Unity 6 LTS (6000.0.62f1):

```
Library\PackageCache\com.unity.2d.tilemap.extras@[hash]\Editor\Tiles\AutoTile\AutoTileTemplate.cs(12,37): 
error CS0246: The type or namespace name 'TileTemplate' could not be found (are you missing a using directive or an assembly reference?)

Library\PackageCache\com.unity.2d.tilemap.extras@[hash]\Editor\Tiles\RuleTile\RuleTileTemplate.cs(13,37): 
error CS0246: The type or namespace name 'TileTemplate' could not be found (are you missing a using directive or an assembly reference?)
```

### Root Cause
**Version 6.0.1 of `com.unity.2d.tilemap.extras` contained a critical bug**: The `AutoTileTemplate` and `RuleTileTemplate` classes inherited from a `TileTemplate` base class that didn't exist in the package. This was a bug in the Unity package itself on the Unity Package Registry.

Even after upgrading from version 4.2.3 to 6.0.1, users continued to experience this error because:
1. Version 6.0.1 itself was buggy
2. Unity caches packages in multiple locations
3. Cached versions persisted even after deleting the Library folder

### Solution
Updated `Packages/manifest.json` to use version **7.0.0** which fixes the TileTemplate bug:

1. **Updated tilemap.extras**: Changed from `6.0.1` to `7.0.0`
   - Version 7.0.0 fixes the TileTemplate inheritance bug
   - Released September 2025 by Unity Technologies
   - Fully compatible with Unity 6 LTS

### Changes Made
- `Packages/manifest.json`: Updated `com.unity.2d.tilemap.extras` from `6.0.1` to `7.0.0`
- `Packages/packages-lock.json`: Updated locked package version to match
- `TILETEMPLATE_BUG_EXPLANATION.md`: New document explaining the bug and fix
- Updated all documentation to reflect the correct solution

### Impact
- ✅ No breaking changes to existing code
- ✅ All C# scripts continue to work
- ✅ Project will now open without TileTemplate compilation errors in Unity 6 LTS
- ✅ `packages-lock.json` has been updated to lock version 7.0.0

### Next Steps for Developers
1. **If you encounter TileTemplate compilation errors:**
   - **Important**: The error is caused by cached version 6.0.1 (which was buggy)
   - **Quick Fix:** Run the cleanup script (recommended):
     - Windows PowerShell: `.\cleanup-unity-cache.ps1`
     - macOS/Linux/Git Bash: `./cleanup-unity-cache.sh`
   - **Advanced Fix** (if standard cleanup doesn't work):
     - Windows PowerShell: `.\advanced-cleanup.ps1`
     - macOS/Linux/Git Bash: `./advanced-cleanup.sh`
   - Unity will download the correct fixed version (7.0.0)
   - See [TILETEMPLATE_BUG_EXPLANATION.md](TILETEMPLATE_BUG_EXPLANATION.md) for technical details
   - See [TROUBLESHOOTING.md](TROUBLESHOOTING.md) for detailed instructions

2. **Normal setup (no errors):**
   - Open the project in Unity 6 LTS
   - Unity will automatically resolve and download version 7.0.0

3. **If using Visual Studio Code**, install the recommended extensions:
   - [Unity for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=visualstudiotoolsforunity.vstuc)
   - [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit)

### Version History
- **4.2.3**: Original version, incompatible with Unity 6
- **6.0.1**: First Unity 6 compatible version, but contained TileTemplate bug
- **7.0.0**: Current version, bug fixed ✅

### References
- [Unity 6 2D Tilemap Extras Documentation](https://docs.unity3d.com/Packages/com.unity.2d.tilemap.extras@7.0/manual/index.html)
- [TileTemplate Bug Explanation](TILETEMPLATE_BUG_EXPLANATION.md)
- [Unity Forum: VS Code Package Update](https://forum.unity.com/threads/update-on-the-visual-studio-code-package.1302621/)
