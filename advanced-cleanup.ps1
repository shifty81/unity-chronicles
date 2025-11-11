# Advanced Unity Cache Cleanup Script (PowerShell)
# Use this script when the standard cleanup doesn't fix TileTemplate errors
# This performs more aggressive cache clearing including global Unity caches

$ErrorActionPreference = "Stop"

$ProjectDir = $PSScriptRoot

Write-Host "==========================================="
Write-Host "Advanced Unity Cache Cleanup Script"
Write-Host "==========================================="
Write-Host ""
Write-Host "⚠️  This script performs AGGRESSIVE cache clearing."
Write-Host "Use this only if the standard cleanup-unity-cache script didn't work."
Write-Host ""
Write-Host "Project directory: $ProjectDir"
Write-Host ""

# Check if Unity is running
$unityProcesses = Get-Process -Name "Unity" -ErrorAction SilentlyContinue
$unityHubProcesses = Get-Process -Name "Unity Hub" -ErrorAction SilentlyContinue

if ($unityProcesses -or $unityHubProcesses) {
    Write-Host "⚠️  WARNING: Unity Editor or Unity Hub appears to be running!"
    Write-Host "Please close BOTH Unity Editor AND Unity Hub before running this script."
    Write-Host ""
    $continue = Read-Host "Press Enter to continue anyway, or Ctrl+C to exit"
}

Write-Host ""
Write-Host "This script will clean:"
Write-Host "  1. Project Library folder"
Write-Host "  2. Project Packages/packages-lock.json"
Write-Host "  3. Global Unity Package Cache (if found)"
Write-Host "  4. Project Temp folder"
Write-Host ""
$confirm = Read-Host "Continue with aggressive cleanup? (yes/no)"

if ($confirm -ne "yes") {
    Write-Host "Cleanup cancelled."
    exit 0
}

Write-Host ""
Write-Host "========== Starting Aggressive Cleanup =========="
Write-Host ""

# Step 1: Clean project Library
Write-Host "[1/4] Removing project Library folder..."
$libraryPath = Join-Path $ProjectDir "Library"
if (Test-Path $libraryPath) {
    Remove-Item -Recurse -Force $libraryPath
    Write-Host "✓ Library folder removed"
} else {
    Write-Host "ℹ Library folder does not exist"
}

# Step 2: Clean packages-lock.json
Write-Host ""
Write-Host "[2/4] Removing Packages/packages-lock.json..."
$lockFilePath = Join-Path $ProjectDir "Packages\packages-lock.json"
if (Test-Path $lockFilePath) {
    Remove-Item -Force $lockFilePath
    Write-Host "✓ packages-lock.json removed"
} else {
    Write-Host "ℹ packages-lock.json does not exist"
}

# Step 3: Clean global Unity package cache
Write-Host ""
Write-Host "[3/4] Checking for global Unity package cache..."

$cachesCleaned = $false

# Windows: %LOCALAPPDATA%\Unity\cache
$globalCachePath = Join-Path $env:LOCALAPPDATA "Unity\cache"
if (Test-Path $globalCachePath) {
    Write-Host "Found global Unity cache at: $globalCachePath"
    $removeCache = Read-Host "Remove global Unity cache? This is safe and will be regenerated (yes/no)"
    if ($removeCache -eq "yes") {
        Remove-Item -Recurse -Force $globalCachePath
        Write-Host "✓ Global Unity cache removed"
        $cachesCleaned = $true
    }
}

if (-not $cachesCleaned) {
    Write-Host "ℹ No global Unity cache found (or skipped)"
}

# Step 4: Clean Temp folder
Write-Host ""
Write-Host "[4/4] Removing project Temp folder..."
$tempPath = Join-Path $ProjectDir "Temp"
if (Test-Path $tempPath) {
    Remove-Item -Recurse -Force $tempPath
    Write-Host "✓ Temp folder removed"
} else {
    Write-Host "ℹ Temp folder does not exist"
}

Write-Host ""
Write-Host "========== Cleanup Complete =========="
Write-Host ""
Write-Host "✅ Advanced cleanup completed successfully!"
Write-Host ""
Write-Host "Next steps:"
Write-Host "  1. Ensure Unity Hub is closed"
Write-Host "  2. Open Unity Hub"
Write-Host "  3. Open this project from Unity Hub"
Write-Host "  4. Wait for Unity to:"
Write-Host "     - Regenerate the Library folder"
Write-Host "     - Download packages from the manifest"
Write-Host "     - Reimport all assets (may take 5-10 minutes)"
Write-Host "  5. Check the Console for any compilation errors"
Write-Host ""
Write-Host "If errors persist, see TROUBLESHOOTING.md for additional solutions."
Write-Host ""
