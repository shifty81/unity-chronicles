#!/bin/bash
# Unity Package Cache Cleanup Script
# This script removes Unity's cached packages to force re-download of correct versions
# Use this when encountering TileTemplate or other package compilation errors

set -e

SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
PROJECT_DIR="$SCRIPT_DIR"

echo "==========================================="
echo "Unity Package Cache Cleanup Script"
echo "==========================================="
echo ""
echo "This script will remove cached Unity packages to fix compilation errors."
echo "Project directory: $PROJECT_DIR"
echo ""

# Check if Unity is running
if pgrep -x "Unity" > /dev/null || pgrep -x "Unity.exe" > /dev/null 2>&1; then
    echo "⚠️  WARNING: Unity Editor appears to be running!"
    echo "Please close Unity Editor before running this script."
    echo ""
    read -p "Press Enter to continue anyway, or Ctrl+C to exit..."
fi

echo ""
echo "Select cleanup option:"
echo "1) Remove Library/PackageCache only (recommended for package issues)"
echo "2) Remove entire Library folder (full clean)"
echo "3) Cancel"
echo ""
read -p "Enter your choice (1-3): " choice

case $choice in
    1)
        echo ""
        echo "Removing Library/PackageCache..."
        if [ -d "$PROJECT_DIR/Library/PackageCache" ]; then
            rm -rf "$PROJECT_DIR/Library/PackageCache"
            echo "✓ Library/PackageCache removed successfully"
        else
            echo "ℹ Library/PackageCache does not exist (already clean)"
        fi
        
        echo ""
        echo "Removing Packages/packages-lock.json..."
        if [ -f "$PROJECT_DIR/Packages/packages-lock.json" ]; then
            rm "$PROJECT_DIR/Packages/packages-lock.json"
            echo "✓ packages-lock.json removed successfully"
        else
            echo "ℹ packages-lock.json does not exist"
        fi
        
        echo ""
        echo "✅ Package cache cleanup complete!"
        echo ""
        echo "Next steps:"
        echo "1. Open the project in Unity"
        echo "2. Unity will re-download packages from Packages/manifest.json"
        echo "3. Wait for package resolution to complete"
        echo "4. Compilation errors should be resolved"
        ;;
    
    2)
        echo ""
        echo "⚠️  This will remove the ENTIRE Library folder!"
        echo "Unity will need to reimport all assets (this may take several minutes)."
        echo ""
        read -p "Are you sure? (yes/no): " confirm
        
        if [ "$confirm" = "yes" ]; then
            echo ""
            echo "Removing Library folder..."
            if [ -d "$PROJECT_DIR/Library" ]; then
                rm -rf "$PROJECT_DIR/Library"
                echo "✓ Library folder removed successfully"
            else
                echo "ℹ Library folder does not exist (already clean)"
            fi
            
            echo ""
            echo "✅ Full cleanup complete!"
            echo ""
            echo "Next steps:"
            echo "1. Open the project in Unity"
            echo "2. Unity will regenerate Library and reimport all assets"
            echo "3. This may take 5-10 minutes depending on project size"
            echo "4. All compilation errors should be resolved"
        else
            echo "Cleanup cancelled."
            exit 0
        fi
        ;;
    
    3)
        echo "Cleanup cancelled."
        exit 0
        ;;
    
    *)
        echo "Invalid choice. Exiting."
        exit 1
        ;;
esac

echo ""
echo "==========================================="
echo "Cleanup completed successfully!"
echo "==========================================="
echo ""
echo "You can now open the project in Unity."
echo "For more information, see TROUBLESHOOTING.md"
echo ""
