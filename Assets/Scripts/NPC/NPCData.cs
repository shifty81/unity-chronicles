using UnityEngine;
using System.Collections.Generic;

namespace ChroniclesOfADrifter.NPC
{
    /// <summary>
    /// NPC data defining personality, schedule, and dialogue
    /// Inspired by Stardew Valley's NPC system
    /// </summary>
    [CreateAssetMenu(fileName = "New NPC", menuName = "Chronicles/NPC/NPC Data")]
    public class NPCData : ScriptableObject
    {
        [Header("Basic Info")]
        public string npcName = "Villager";
        public string description = "A friendly villager";
        public Sprite portrait;
        public GameObject npcPrefab;
        
        [Header("Personality")]
        [TextArea(3, 5)]
        public string biography;
        public string[] likes;
        public string[] dislikes;
        public string birthday; // Format: "Season Day" e.g., "Spring 7"
        
        [Header("Dialogue")]
        public List<DialogueSet> dialogueSets = new List<DialogueSet>();
        
        [Header("Schedule")]
        public List<ScheduleEntry> schedule = new List<ScheduleEntry>();
        
        [Header("Relationships")]
        public int baseRelationship = 0; // 0-100
        public string[] friends;
        public string[] family;
        
        [System.Serializable]
        public class DialogueSet
        {
            public string context = "default"; // default, rainy, festival, high_friendship, etc.
            [TextArea(2, 4)]
            public string[] dialogueLines;
        }
        
        [System.Serializable]
        public class ScheduleEntry
        {
            public int hour;
            public int minute;
            public string locationName;
            public Vector3 position;
            public string activity; // "work", "rest", "eat", "socialize", etc.
        }
        
        /// <summary>
        /// Get dialogue for current context
        /// </summary>
        public string[] GetDialogue(string context = "default")
        {
            DialogueSet set = dialogueSets.Find(d => d.context == context);
            if (set != null && set.dialogueLines.Length > 0)
                return set.dialogueLines;
            
            // Fallback to default
            set = dialogueSets.Find(d => d.context == "default");
            if (set != null && set.dialogueLines.Length > 0)
                return set.dialogueLines;
            
            return new string[] { "..." };
        }
        
        /// <summary>
        /// Get schedule entry for given time
        /// </summary>
        public ScheduleEntry GetScheduleEntryForTime(int hour, int minute)
        {
            ScheduleEntry currentEntry = null;
            int currentTime = hour * 60 + minute;
            
            foreach (var entry in schedule)
            {
                int entryTime = entry.hour * 60 + entry.minute;
                if (entryTime <= currentTime)
                {
                    if (currentEntry == null || (entry.hour * 60 + entry.minute) > (currentEntry.hour * 60 + currentEntry.minute))
                    {
                        currentEntry = entry;
                    }
                }
            }
            
            return currentEntry ?? (schedule.Count > 0 ? schedule[0] : null);
        }
    }
}
