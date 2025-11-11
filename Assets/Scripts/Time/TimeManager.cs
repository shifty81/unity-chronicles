using UnityEngine;

namespace ChroniclesOfADrifter.Time
{
    /// <summary>
    /// Time and calendar system inspired by Stardew Valley
    /// Manages day/night cycle, seasons, and time progression
    /// </summary>
    public class TimeManager : MonoBehaviour
    {
        [Header("Time Settings")]
        [SerializeField] private float realSecondsPerGameMinute = 0.7f; // ~10 minutes per game day
        [SerializeField] private int startHour = 6; // Start at 6 AM
        [SerializeField] private int startMinute = 0;
        
        [Header("Calendar")]
        [SerializeField] private Season currentSeason = Season.Spring;
        [SerializeField] private int currentDay = 1;
        [SerializeField] private int currentYear = 1;
        [SerializeField] private int daysPerSeason = 28;
        
        private float currentTime; // Time in hours (0-24)
        private float timer = 0f;
        
        public static TimeManager Instance { get; private set; }
        
        // Properties
        public int CurrentHour => Mathf.FloorToInt(currentTime);
        public int CurrentMinute => Mathf.FloorToInt((currentTime - CurrentHour) * 60);
        public Season CurrentSeason => currentSeason;
        public int CurrentDay => currentDay;
        public int CurrentYear => currentYear;
        public float TimeOfDay => currentTime / 24f; // 0 to 1
        
        // Events
        public System.Action<int, int> OnTimeChanged; // hour, minute
        public System.Action OnNewDay;
        public System.Action<Season> OnSeasonChanged;
        public System.Action<int> OnYearChanged;
        
        public enum Season
        {
            Spring,
            Summer,
            Fall,
            Winter
        }
        
        public enum TimeOfDayPeriod
        {
            Dawn,    // 6-8 AM
            Morning, // 8-12 PM
            Noon,    // 12-2 PM
            Afternoon, // 2-6 PM
            Evening, // 6-8 PM
            Night    // 8 PM - 6 AM
        }
        
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
            
            currentTime = startHour + (startMinute / 60f);
        }
        
        private void Update()
        {
            // Progress time
            timer += UnityEngine.Time.deltaTime;
            
            if (timer >= realSecondsPerGameMinute)
            {
                timer -= realSecondsPerGameMinute;
                AdvanceTime(1f / 60f); // Advance by 1 minute
            }
        }
        
        /// <summary>
        /// Advance time by hours
        /// </summary>
        public void AdvanceTime(float hours)
        {
            float previousTime = currentTime;
            currentTime += hours;
            
            // Check for new day
            if (currentTime >= 24f)
            {
                currentTime -= 24f;
                AdvanceDay();
            }
            
            // Notify time changed
            if (Mathf.FloorToInt(previousTime * 60) != Mathf.FloorToInt(currentTime * 60))
            {
                OnTimeChanged?.Invoke(CurrentHour, CurrentMinute);
            }
        }
        
        /// <summary>
        /// Advance to the next day
        /// </summary>
        public void AdvanceDay()
        {
            currentDay++;
            
            // Check for new season
            if (currentDay > daysPerSeason)
            {
                currentDay = 1;
                AdvanceSeason();
            }
            
            OnNewDay?.Invoke();
        }
        
        /// <summary>
        /// Advance to the next season
        /// </summary>
        private void AdvanceSeason()
        {
            currentSeason = currentSeason switch
            {
                Season.Spring => Season.Summer,
                Season.Summer => Season.Fall,
                Season.Fall => Season.Winter,
                Season.Winter => Season.Spring,
                _ => Season.Spring
            };
            
            OnSeasonChanged?.Invoke(currentSeason);
            
            // Check for new year
            if (currentSeason == Season.Spring)
            {
                currentYear++;
                OnYearChanged?.Invoke(currentYear);
            }
        }
        
        /// <summary>
        /// Get current time of day period
        /// </summary>
        public TimeOfDayPeriod GetTimeOfDayPeriod()
        {
            int hour = CurrentHour;
            
            if (hour >= 6 && hour < 8) return TimeOfDayPeriod.Dawn;
            if (hour >= 8 && hour < 12) return TimeOfDayPeriod.Morning;
            if (hour >= 12 && hour < 14) return TimeOfDayPeriod.Noon;
            if (hour >= 14 && hour < 18) return TimeOfDayPeriod.Afternoon;
            if (hour >= 18 && hour < 20) return TimeOfDayPeriod.Evening;
            return TimeOfDayPeriod.Night;
        }
        
        /// <summary>
        /// Get formatted time string (12-hour format)
        /// </summary>
        public string GetFormattedTime(bool use24Hour = false)
        {
            int hour = CurrentHour;
            int minute = CurrentMinute;
            
            if (use24Hour)
            {
                return $"{hour:D2}:{minute:D2}";
            }
            else
            {
                int hour12 = hour % 12;
                if (hour12 == 0) hour12 = 12;
                string period = hour >= 12 ? "PM" : "AM";
                return $"{hour12}:{minute:D2} {period}";
            }
        }
        
        /// <summary>
        /// Get formatted date string
        /// </summary>
        public string GetFormattedDate()
        {
            return $"{currentSeason} {currentDay}, Year {currentYear}";
        }
        
        /// <summary>
        /// Set time directly (useful for debugging or cutscenes)
        /// </summary>
        public void SetTime(int hour, int minute)
        {
            currentTime = hour + (minute / 60f);
            OnTimeChanged?.Invoke(CurrentHour, CurrentMinute);
        }
    }
}
