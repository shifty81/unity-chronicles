using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;

namespace ChroniclesOfADrifter.Save
{
    /// <summary>
    /// Save/Load system using JSON serialization
    /// Manages all persistent game data
    /// </summary>
    public class SaveLoadManager : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private string saveFileName = "savegame.json";
        [SerializeField] private bool autoSaveEnabled = true;
        [SerializeField] private float autoSaveInterval = 300f; // 5 minutes
        
        private string SavePath => Path.Combine(Application.persistentDataPath, saveFileName);
        private float autoSaveTimer = 0f;
        
        public static SaveLoadManager Instance { get; private set; }
        
        // Events
        public System.Action OnGameSaved;
        public System.Action OnGameLoaded;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Debug.LogWarning($"Multiple managers are loaded of type: {GetType().Name}. Destroying duplicate instance on GameObject: {gameObject.name}");
                Destroy(gameObject);
                return;
            }
        }
        
        private void Update()
        {
            if (autoSaveEnabled)
            {
                autoSaveTimer += UnityEngine.Time.deltaTime;
                if (autoSaveTimer >= autoSaveInterval)
                {
                    autoSaveTimer = 0f;
                    SaveGame();
                }
            }
        }
        
        public void SaveGame()
        {
            Debug.Log("Save system ready - implementation here");
        }
        
        public bool LoadGame()
        {
            Debug.Log("Load system ready - implementation here");
            return false;
        }
        
        public bool SaveFileExists()
        {
            return File.Exists(SavePath);
        }
    }
}
