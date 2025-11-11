#!/bin/bash
# Advanced Unity Cache Cleanup Script
# Use this script when the standard cleanup doesn't fix TileTemplate errors
# This performs more aggressive cache clearing including global Unity caches

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROJECT_DIR="$SCRIPT_DIR"

echo "==========================================="
echo "Advanced Unity Cache Cleanup Script"
echo "==========================================="
echo ""
echo "⚠️  This script performs AGGRESSIVE cache clearing."
echo "Use this only if the standard cleanup-unity-cache script didn't work."
echo ""
echo "Project directory: $PROJECT_DIR"
echo ""

# Check if Unity is running
if pgrep -x "Unity" > /dev/null || pgrep -x "Unity Hub" > /dev/null 2>&1; then
    echo "⚠️  WARNING: Unity Editor or Unity Hub appears to be running!"
    echo "Please close BOTH Unity Editor AND Unity Hub before running this script."
    echo ""
    read -p "Press Enter to continue anyway, or Ctrl+C to exit..."
fi

echo ""
echo "This script will clean:"
echo "  1. Project Library folder"
echo "  2. Project Packages/packages-lock.json"
echo "  3. Global Unity Package Cache (if found)"
echo "  4. Project Temp folder"
echo ""
read -p "Continue with aggressive cleanup? (yes/no): " confirm

if [ "$confirm" != "yes" ]; then
    echo "Cleanup cancelled."
    exit 0
fi

echo ""
echo "========== Starting Aggressive Cleanup =========="
echo ""

# Step 1: Clean project Library
echo "[1/4] Removing project Library folder..."
if [ -d "$PROJECT_DIR/Library" ]; then
    rm -rf "$PROJECT_DIR/Library"
    echo "✓ Library folder removed"
else
    echo "ℹ Library folder does not exist"
fi

# Step 2: Clean packages-lock.json
echo ""
echo "[2/4] Removing Packages/packages-lock.json..."
if [ -f "$PROJECT_DIR/Packages/packages-lock.json" ]; then
    rm "$PROJECT_DIR/Packages/packages-lock.json"
    echo "✓ packages-lock.json removed"
else
    echo "ℹ packages-lock.json does not exist"
fi

# Step 3: Clean global Unity package cache
echo ""
echo "[3/4] Checking for global Unity package cache..."

# Try to find global cache locations
CACHE_CLEANED=false

# Windows (Git Bash/WSL): C:\Users\<username>\AppData\Local\Unity\cache
if [ -d "$LOCALAPPDATA/Unity/cache" ]; then
    echo "Found Windows global cache at: $LOCALAPPDATA/Unity/cache"
    read -p "Remove global Unity cache? This is safe and will be regenerated (yes/no): " remove_cache
    if [ "$remove_cache" = "yes" ]; then
        rm -rf "$LOCALAPPDATA/Unity/cache"
        echo "✓ Windows global cache removed"
        CACHE_CLEANED=true
    fi
fi

# macOS: ~/Library/Unity/cache
if [ -d "$HOME/Library/Unity/cache" ]; then
    echo "Found macOS global cache at: ~/Library/Unity/cache"
    read -p "Remove global Unity cache? This is safe and will be regenerated (yes/no): " remove_cache
    if [ "$remove_cache" = "yes" ]; then
        rm -rf "$HOME/Library/Unity/cache"
        echo "✓ macOS global cache removed"
        CACHE_CLEANED=true
    fi
fi

# Linux: ~/.config/unity3d/cache
if [ -d "$HOME/.config/unity3d/cache" ]; then
    echo "Found Linux global cache at: ~/.config/unity3d/cache"
    read -p "Remove global Unity cache? This is safe and will be regenerated (yes/no): " remove_cache
    if [ "$remove_cache" = "yes" ]; then
        rm -rf "$HOME/.config/unity3d/cache"
        echo "✓ Linux global cache removed"
        CACHE_CLEANED=true
    fi
fi

if [ "$CACHE_CLEANED" = false ]; then
    echo "ℹ No global Unity cache found (or skipped)"
fi

# Step 4: Clean Temp folder
echo ""
echo "[4/4] Removing project Temp folder..."
if [ -d "$PROJECT_DIR/Temp" ]; then
    rm -rf "$PROJECT_DIR/Temp"
    echo "✓ Temp folder removed"
else
    echo "ℹ Temp folder does not exist"
fi

echo ""
echo "========== Cleanup Complete =========="
echo ""
echo "✅ Advanced cleanup completed successfully!"
echo ""
echo "Next steps:"
echo "  1. Ensure Unity Hub is closed"
echo "  2. Open Unity Hub"
echo "  3. Open this project from Unity Hub"
echo "  4. Wait for Unity to:"
echo "     - Regenerate the Library folder"
echo "     - Download packages from the manifest"
echo "     - Reimport all assets (may take 5-10 minutes)"
echo "  5. Check the Console for any compilation errors"
echo ""
echo "If errors persist, see TROUBLESHOOTING.md for additional solutions."
echo ""
