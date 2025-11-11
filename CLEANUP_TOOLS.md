# Unity Package Cache Cleanup Tools

This directory contains scripts to help resolve Unity package compilation errors, particularly the TileTemplate errors that occur with Unity 6 LTS.

## Quick Start

### If you have compilation errors:

1. **Verify the issue** (recommended first step):
   ```bash
   # Windows
   .\verify-packages.ps1
   
   # macOS/Linux
   ./verify-packages.sh
   ```

2. **Try standard cleanup**:
   ```bash
   # Windows
   .\cleanup-unity-cache.ps1
   
   # macOS/Linux
   ./cleanup-unity-cache.sh
   ```

3. **If errors persist, use advanced cleanup**:
   ```bash
   # Windows
   .\advanced-cleanup.ps1
   
   # macOS/Linux
   ./advanced-cleanup.sh
   ```

## Available Scripts

### verify-packages (.sh / .ps1)
**Purpose:** Diagnoses package installation issues without making changes

**When to use:**
- Before running cleanup scripts
- To understand what's wrong
- To confirm packages are correctly installed

**What it checks:**
- Unity version compatibility
- Package versions in manifest and lock file
- Cached package versions
- Presence of deprecated TileTemplate references

**Safe to run:** Yes - read-only, makes no changes

---

### cleanup-unity-cache (.sh / .ps1)
**Purpose:** Standard package cache cleanup

**When to use:**
- First time encountering TileTemplate errors
- After updating Unity or packages
- When verify-packages detects cache issues

**What it does:**
- Removes `Library/PackageCache`
- Removes `Packages/packages-lock.json`
- OR removes entire `Library` folder (your choice)

**Preserves:**
- Project files and scripts
- Assets and scenes
- Project settings
- Global Unity settings and caches

---

### advanced-cleanup (.sh / .ps1)
**Purpose:** Aggressive cache cleanup for stubborn issues

**When to use:**
- Standard cleanup didn't fix the problem
- Errors persist after multiple cleanup attempts
- verify-packages still shows old cached packages
- Recommended by support/documentation

**What it does:**
- Removes entire `Library` folder
- Removes `Packages/packages-lock.json`
- **Removes global Unity package cache** (system-wide)
- Removes `Temp` folder

**Important notes:**
- More aggressive than standard cleanup
- Clears caches shared across all Unity projects
- Requires closing Unity Hub (not just Unity Editor)
- Unity will take longer to reopen (5-10 minutes)
- **Safe** - all removed caches are regenerated automatically

---

## Troubleshooting Workflow

```
Have compilation errors?
         |
         v
Run verify-packages
         |
         v
    Issues found?
    /           \
  Yes            No
   |              |
   v              v
Run cleanup   Check Unity
   |           Console for
   |          other errors
   v
Still broken?
   |
   v
Run advanced-cleanup
   |
   v
Still broken?
   |
   v
See TROUBLESHOOTING.md
for advanced solutions
```

## Common Questions

### Q: Which cleanup script should I use?
**A:** Start with `cleanup-unity-cache`. Only use `advanced-cleanup` if the standard cleanup didn't fix the problem.

### Q: Will these scripts delete my project files?
**A:** No. They only delete Unity-generated cache folders (Library, Temp) and package lock files. Your scripts, assets, scenes, and settings are safe.

### Q: Do I need to close Unity?
**A:** Yes. Close Unity Editor before running cleanup scripts. For advanced-cleanup, also close Unity Hub.

### Q: How long does cleanup take?
**A:** The cleanup itself is instant. Reopening Unity takes 5-10 minutes for full reimport.

### Q: Is it safe to delete global Unity caches?
**A:** Yes. Unity regenerates these automatically. You'll just need to wait for package downloads.

### Q: Can I run these scripts multiple times?
**A:** Yes, they're safe to run multiple times.

### Q: What if cleanup doesn't fix my problem?
**A:** See [TROUBLESHOOTING.md](TROUBLESHOOTING.md) for additional solutions including Unity version checks, registry connectivity, and nuclear options.

## Technical Details

### Why Do These Errors Happen?

**Version 6.0.1 of `com.unity.2d.tilemap.extras` contained a critical bug** where the `AutoTileTemplate` and `RuleTileTemplate` classes inherited from a `TileTemplate` base class that didn't exist in the package.

This project has been updated to use **version 7.0.0** which fixes the bug. However, Unity may cache the buggy version (6.0.1) from previous openings of the project or from other Unity projects.

Cache locations:
- **Project cache:** `Library/PackageCache/` (cleaned by standard cleanup)
- **Global cache:** OS-specific location (cleaned by advanced cleanup)
  - Windows: `%LOCALAPPDATA%\Unity\cache`
  - macOS: `~/Library/Unity/cache`
  - Linux: `~/.config/unity3d/cache`

Even with correct `manifest.json` and `packages-lock.json` specifying version 7.0.0, Unity may use the buggy cached version 6.0.1 from global caches.

### What Gets Regenerated?

After cleanup, Unity automatically regenerates:
- `Library/` folder structure
- Package cache with correct versions
- `packages-lock.json`
- Asset import database
- Compiled assemblies
- Shader cache
- All other cached data

Nothing is permanently lost - everything is rebuilt from your source assets and package registry.

## See Also

- [QUICK_FIX.md](QUICK_FIX.md) - One-page quick reference
- [TROUBLESHOOTING.md](TROUBLESHOOTING.md) - Comprehensive troubleshooting guide
- [PACKAGE_UPDATE_NOTES.md](PACKAGE_UPDATE_NOTES.md) - Why packages were updated
