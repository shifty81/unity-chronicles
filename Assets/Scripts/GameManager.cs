using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChroniclesOfADrifter
{
    /// <summary>
    /// Game Manager - singleton that manages game state and systems
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<GameManager>();
                    if (instance == null)
                    {
                        GameObject go = new GameObject("GameManager");
                        instance = go.AddComponent<GameManager>();
                        DontDestroyOnLoad(go);
                    }
                }
                return instance;
            }
        }
        
        [Header("Game State")]
        [SerializeField] private bool isPaused = false;
        [SerializeField] private float gameTime = 0f;
        
        [Header("Player")]
        [SerializeField] private GameObject playerPrefab;
        private GameObject currentPlayer;
        
        public bool IsPaused => isPaused;
        public float GameTime => gameTime;
        public GameObject Player => currentPlayer;
        
        // Events
        public System.Action OnGamePause;
        public System.Action OnGameResume;
        
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                // Silently destroy duplicate instances - this is expected behavior when scenes reload
                // Only log in development builds to avoid console spam
                #if UNITY_EDITOR
                Debug.Log($"[GameManager] Duplicate instance found on '{gameObject.name}', destroying. This is normal if scene was reloaded.");
                #endif
                Destroy(gameObject);
                return;
            }
            
            InitializeGame();
        }
        
        private void Update()
        {
            if (!isPaused)
            {
                gameTime += Time.deltaTime;
            }
            
            // Handle pause input
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }
        
        private void InitializeGame()
        {
            // Set up game systems
            Application.targetFrameRate = 60;
            
            // Find or create player
            FindOrCreatePlayer();
        }
        
        private void FindOrCreatePlayer()
        {
            currentPlayer = GameObject.FindGameObjectWithTag("Player");
            
            if (currentPlayer == null && playerPrefab != null)
            {
                // Spawn player at spawn point or origin
                GameObject spawnPoint = GameObject.FindGameObjectWithTag("SpawnPoint");
                Vector3 spawnPosition = spawnPoint != null ? spawnPoint.transform.position : Vector3.zero;
                
                currentPlayer = Instantiate(playerPrefab, spawnPosition, Quaternion.identity);
                currentPlayer.tag = "Player";
            }
        }
        
        public void TogglePause()
        {
            SetPause(!isPaused);
        }
        
        public void SetPause(bool pause)
        {
            isPaused = pause;
            Time.timeScale = pause ? 0f : 1f;
            
            if (pause)
                OnGamePause?.Invoke();
            else
                OnGameResume?.Invoke();
        }
        
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        
        public void LoadScene(int sceneIndex)
        {
            SceneManager.LoadScene(sceneIndex);
        }
        
        public void RestartCurrentScene()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.name);
        }
        
        public void QuitGame()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
        }
    }
}
