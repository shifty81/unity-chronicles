# Unity 6 LTS Package Fix - Testing Guide

## How to Verify the Fix

This guide helps you verify that the package compatibility issues have been resolved.

### Prerequisites
- Unity 6 LTS (version 6000.0.x or later)
- Git access to the repository

### Testing Steps

#### 1. Fresh Clone Test (Recommended)
This simulates a new developer joining the project:

```bash
# Clone the repository
git clone https://github.com/shifty81/unity-chronicles.git
cd unity-chronicles

# Checkout the fix branch
git checkout copilot/fix-tiletemplate-errors

# Open in Unity Hub
# (Or open the project folder directly in Unity 6 LTS)
```

**Expected Results:**
- ✅ Unity opens without compilation errors
- ✅ No errors about `TileTemplate` type not found
- ✅ No warnings about deprecated packages
- ✅ Console shows "Compilation completed successfully"
- ✅ `packages-lock.json` has the correct version (6.0.1) locked

#### 2. Existing Project Update Test
If you already have the project open:

```bash
# Pull the latest changes
git pull origin copilot/fix-tiletemplate-errors

# Unity will detect package changes and prompt to reimport
# Click "Reimport" or restart Unity
```

**Expected Results:**
- ✅ Unity detects package changes
- ✅ Packages are re-resolved automatically
- ✅ No compilation errors after reimport
- ✅ Existing scenes open without errors

#### 3. Package Verification
Check that the correct packages are installed:

1. Open Unity
2. Go to **Window > Package Manager**
3. Verify the following:
   - `2D Tilemap Extras` is version **6.0.1** or higher
   - `Visual Studio Code Editor` is **NOT** in the list
   - `Visual Studio Editor` is version **2.0.22** (this should remain)

#### 4. Script Compilation Test
Verify that all scripts compile correctly:

1. In Unity, go to **Assets > Open C# Project** (or press Ctrl+Alt+O / Cmd+Alt+O)
2. Wait for the solution to open in your IDE
3. Check for any compilation errors
4. Verify these scripts load without errors:
   - `Assets/Scripts/Farming/FarmingManager.cs`
   - `Assets/Scripts/Farming/PlantedCrop.cs`

**Expected Results:**
- ✅ No red squiggly lines in C# files
- ✅ IntelliSense works for `UnityEngine.Tilemaps` namespace
- ✅ No missing type errors

#### 5. Scene Loading Test
Verify that existing scenes load correctly:

1. In Unity, go to **File > Open Scene**
2. Open `Assets/Scenes/MainScene.unity`
3. Check the Console window for any errors

**Expected Results:**
- ✅ Scene loads without errors
- ✅ No "Could not extract GUID" errors
- ✅ No "Broken text PPtr" errors
- ✅ All GameObjects and components are intact

#### 6. Tilemap Functionality Test
Verify that tilemap features work:

1. In the Hierarchy, check if there are any Tilemap objects
2. If they exist, select one and verify in the Inspector:
   - ✅ Tilemap component loads without errors
   - ✅ TileBase references (if any) are valid

3. Create a new Tilemap (optional):
   - Right-click in Hierarchy > **2D Object > Tilemap > Rectangular**
   - ✅ Creates without errors

### Visual Studio Code Users

If you use VS Code, you'll need to install new extensions:

1. Open VS Code
2. Go to Extensions (Ctrl+Shift+X / Cmd+Shift+X)
3. Install:
   - **Unity for Visual Studio Code** (by Microsoft)
   - **C# Dev Kit** (by Microsoft)
4. Restart VS Code
5. Open a C# file from the project

**Expected Results:**
- ✅ IntelliSense works
- ✅ Unity symbols are recognized
- ✅ Can debug Unity projects (with proper configuration)

### Common Issues and Solutions

#### Issue: "Package resolution error"
**Solution:** Delete `Library/` folder and reopen the project. Unity will regenerate it.

#### Issue: VS Code shows errors but Unity compiles fine
**Solution:** 
1. Install the Microsoft Unity extension (see above)
2. In VS Code, run command: **Preferences: Open Settings (UI)**
3. Search for "omnisharp" and disable it if you have the new C# Dev Kit

#### Issue: "packages-lock.json has merge conflicts"
**Solution:** Accept the incoming changes (from this branch). Unity will regenerate this file.

### Success Criteria

The fix is successful if:
- ✅ Project opens in Unity 6 LTS without errors
- ✅ No `TileTemplate` compilation errors
- ✅ No deprecated package warnings
- ✅ All existing scripts compile
- ✅ MainScene.unity loads without errors
- ✅ Package Manager shows correct versions

### Rollback (If Needed)

If you need to rollback:
```bash
git checkout main  # or the previous working branch
# Delete Library/ folder
# Reopen in Unity
```

### Report Issues

If you encounter any issues not covered here:
1. Check the Console window for specific error messages
2. Verify you're using Unity 6 LTS (6000.0.x)
3. Try deleting the `Library/` folder
4. Report the issue with:
   - Unity version (`Help > About Unity`)
   - Error message from Console
   - Steps to reproduce

---

**Last Updated:** November 11, 2025
**Related PR:** Fix Unity 6 LTS package compatibility issues
