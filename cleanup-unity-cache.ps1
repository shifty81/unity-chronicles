# Unity Package Cache Cleanup Script (PowerShell)
# This script removes Unity's cached packages to force re-download of correct versions
# Use this when encountering TileTemplate or other package compilation errors

$ErrorActionPreference = "Stop"

$ScriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path
$ProjectDir = $ScriptDir

Write-Host "==========================================="
Write-Host "Unity Package Cache Cleanup Script"
Write-Host "==========================================="
Write-Host ""
Write-Host "This script will remove cached Unity packages to fix compilation errors."
Write-Host "Project directory: $ProjectDir"
Write-Host ""

# Check if Unity is running
$unityProcesses = Get-Process -Name "Unity" -ErrorAction SilentlyContinue
if ($unityProcesses) {
    Write-Host "⚠️  WARNING: Unity Editor is currently running!" -ForegroundColor Yellow
    Write-Host "Please close Unity Editor before running this script."
    Write-Host ""
    Pause
}

Write-Host ""
Write-Host "Select cleanup option:"
Write-Host "1) Remove Library/PackageCache only (recommended for package issues)"
Write-Host "2) Remove entire Library folder (full clean)"
Write-Host "3) Cancel"
Write-Host ""
$choice = Read-Host "Enter your choice (1-3)"

switch ($choice) {
    "1" {
        Write-Host ""
        Write-Host "Removing Library/PackageCache..."
        $packageCachePath = Join-Path $ProjectDir "Library\PackageCache"
        if (Test-Path $packageCachePath) {
            Remove-Item -Recurse -Force $packageCachePath
            Write-Host "✓ Library/PackageCache removed successfully" -ForegroundColor Green
        } else {
            Write-Host "ℹ Library/PackageCache does not exist (already clean)" -ForegroundColor Cyan
        }
        
        Write-Host ""
        Write-Host "Removing Packages/packages-lock.json..."
        $lockFilePath = Join-Path $ProjectDir "Packages\packages-lock.json"
        if (Test-Path $lockFilePath) {
            Remove-Item -Force $lockFilePath
            Write-Host "✓ packages-lock.json removed successfully" -ForegroundColor Green
        } else {
            Write-Host "ℹ packages-lock.json does not exist" -ForegroundColor Cyan
        }
        
        Write-Host ""
        Write-Host "✅ Package cache cleanup complete!" -ForegroundColor Green
        Write-Host ""
        Write-Host "Next steps:"
        Write-Host "1. Open the project in Unity"
        Write-Host "2. Unity will re-download packages from Packages/manifest.json"
        Write-Host "3. Wait for package resolution to complete"
        Write-Host "4. Compilation errors should be resolved"
    }
    
    "2" {
        Write-Host ""
        Write-Host "⚠️  This will remove the ENTIRE Library folder!" -ForegroundColor Yellow
        Write-Host "Unity will need to reimport all assets (this may take several minutes)."
        Write-Host ""
        $confirm = Read-Host "Are you sure? (yes/no)"
        
        if ($confirm -eq "yes") {
            Write-Host ""
            Write-Host "Removing Library folder..."
            $libraryPath = Join-Path $ProjectDir "Library"
            if (Test-Path $libraryPath) {
                Remove-Item -Recurse -Force $libraryPath
                Write-Host "✓ Library folder removed successfully" -ForegroundColor Green
            } else {
                Write-Host "ℹ Library folder does not exist (already clean)" -ForegroundColor Cyan
            }
            
            Write-Host ""
            Write-Host "✅ Full cleanup complete!" -ForegroundColor Green
            Write-Host ""
            Write-Host "Next steps:"
            Write-Host "1. Open the project in Unity"
            Write-Host "2. Unity will regenerate Library and reimport all assets"
            Write-Host "3. This may take 5-10 minutes depending on project size"
            Write-Host "4. All compilation errors should be resolved"
        } else {
            Write-Host "Cleanup cancelled." -ForegroundColor Yellow
            exit 0
        }
    }
    
    "3" {
        Write-Host "Cleanup cancelled." -ForegroundColor Yellow
        exit 0
    }
    
    default {
        Write-Host "Invalid choice. Exiting." -ForegroundColor Red
        exit 1
    }
}

Write-Host ""
Write-Host "==========================================="
Write-Host "Cleanup completed successfully!"
Write-Host "==========================================="
Write-Host ""
Write-Host "You can now open the project in Unity."
Write-Host "For more information, see TROUBLESHOOTING.md"
Write-Host ""
Pause
