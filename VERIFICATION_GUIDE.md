# Verification Guide: TileTemplate Fix

This guide helps you verify that the TileTemplate error has been resolved after applying the fix.

## Before You Start

Ensure you have:
- Pulled the latest changes from the repository
- Unity 6 LTS (6000.0.62f1 or later) installed
- Unity Hub installed

## Verification Steps

### Step 1: Check Package Version in Files

Verify the correct version is specified in the project files:

```bash
# Check manifest.json
grep "tilemap.extras" Packages/manifest.json
# Expected: "com.unity.2d.tilemap.extras": "7.0.0",

# Check packages-lock.json
grep -A 2 '"com.unity.2d.tilemap.extras"' Packages/packages-lock.json
# Expected: "version": "7.0.0",
```

✅ **Pass Criteria**: Both files show version 7.0.0

### Step 2: Clean Caches (If You Previously Had Errors)

If you previously experienced TileTemplate errors, clean your caches:

**Option A: Standard Cleanup (Recommended first)**
```bash
# Windows PowerShell
.\cleanup-unity-cache.ps1

# macOS/Linux
./cleanup-unity-cache.sh
```

**Option B: Advanced Cleanup (If standard didn't work)**
```bash
# Close Unity Hub before running this!

# Windows PowerShell
.\advanced-cleanup.ps1

# macOS/Linux
./advanced-cleanup.sh
```

### Step 3: Open Project in Unity

1. **Open Unity Hub**
2. **Open the project** (or add it if not already in the list)
3. **Wait for Unity to load and import assets** (5-10 minutes first time)
4. **Watch the Console window** for errors

### Step 4: Verify Package Version in Unity

Once Unity is open:

1. Open **Window → Package Manager**
2. Find **"2D Tilemap Extras"** in the list
3. Verify it shows version **7.0.0**

✅ **Pass Criteria**: Package Manager shows version 7.0.0

### Step 5: Check for Compilation Errors

In Unity Editor:

1. Open the **Console** window (Ctrl+Shift+C / Cmd+Shift+C)
2. Check for any compilation errors

✅ **Pass Criteria**: No TileTemplate-related errors in the Console

Specifically, you should NOT see:
```
error CS0246: The type or namespace name 'TileTemplate' could not be found
```

### Step 6: Verify Package Cache Location

Check what version is actually cached:

**Windows:**
```powershell
# Check project cache
Get-ChildItem "Library\PackageCache" -Filter "com.unity.2d.tilemap.extras*"
# Should show version 7.0.0

# Check global cache (if exists)
Get-ChildItem "$env:LOCALAPPDATA\Unity\cache\packages\packages.unity.com" -Filter "*tilemap.extras*" -Recurse
```

**macOS/Linux:**
```bash
# Check project cache
ls -la Library/PackageCache/ | grep tilemap.extras
# Should show version 7.0.0

# Check global cache (if exists)
find ~/Library/Unity/cache -name "*tilemap.extras*" 2>/dev/null
```

✅ **Pass Criteria**: Only version 7.0.0 is present in caches

### Step 7: Test Project Compilation

1. In Unity, go to **Assets → Reimport All**
2. Wait for reimport to complete
3. Check Console for errors

✅ **Pass Criteria**: Reimport completes without TileTemplate errors

### Step 8: Create a New Script (Optional Advanced Test)

Test that Unity is functioning correctly:

1. In Unity, go to **Assets → Create → C# Script**
2. Name it "TestScript"
3. Double-click to open in your editor
4. Add a simple using statement:
   ```csharp
   using UnityEngine.Tilemaps;
   ```
5. Save and return to Unity
6. Check Console for errors

✅ **Pass Criteria**: No compilation errors

## Troubleshooting Failed Verification

### If Package Manager Still Shows 6.0.1

1. Close Unity completely
2. Run advanced cleanup script
3. Verify `Packages/manifest.json` contains `7.0.0`
4. Verify `Packages/packages-lock.json` contains `7.0.0`
5. Delete `Library` folder manually
6. Reopen project

### If You Still See TileTemplate Errors

1. **Verify you pulled the latest changes** from git:
   ```bash
   git pull origin copilot/fix-tile-template-error
   ```

2. **Check you're on the correct branch**:
   ```bash
   git branch
   # Should show: copilot/fix-tile-template-error
   ```

3. **Run advanced cleanup** (closes both Unity and Unity Hub first):
   ```bash
   # Close Unity and Unity Hub completely
   # Then run:
   ./advanced-cleanup.sh  # or advanced-cleanup.ps1 on Windows
   ```

4. **Manually delete all caches**:
   ```bash
   # Windows
   Remove-Item -Recurse -Force Library
   Remove-Item Packages\packages-lock.json
   Remove-Item -Recurse -Force $env:LOCALAPPDATA\Unity\cache

   # macOS
   rm -rf Library
   rm Packages/packages-lock.json
   rm -rf ~/Library/Unity/cache

   # Linux
   rm -rf Library
   rm Packages/packages-lock.json
   rm -rf ~/.config/unity3d/cache
   ```

5. **Reopen Unity Hub and open project**

### If Errors Persist After All Steps

1. Check Unity version:
   - Must be Unity 6 LTS (6000.0.x)
   - Update Unity if necessary

2. Check network connectivity:
   - Ensure you can reach `packages.unity.com`
   - Check firewall/proxy settings

3. Check for Unity Hub updates:
   - Update Unity Hub to latest version

4. See [TROUBLESHOOTING.md](TROUBLESHOOTING.md) for additional solutions

## Success Indicators

✅ Your fix is successful if:

1. Package Manager shows version 7.0.0
2. No TileTemplate compilation errors in Console
3. Project opens and compiles without errors
4. Cache directories show version 7.0.0
5. Assets reimport without errors

## Reporting Issues

If you've followed all steps and still have issues:

1. **Document your environment**:
   - Unity version (exact build number)
   - Operating system and version
   - Unity Hub version

2. **Collect information**:
   - Console error messages (full text)
   - Package Manager screenshot showing version
   - Contents of `Packages/manifest.json`
   - Contents of cache directories

3. **Create a GitHub issue** with:
   - Steps you followed
   - Environment information
   - Error messages
   - What you expected vs. what happened

---

**Last Updated**: November 2025
**Fix Version**: 7.0.0
**Status**: Ready for testing
