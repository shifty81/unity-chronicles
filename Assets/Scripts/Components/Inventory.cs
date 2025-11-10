using UnityEngine;

namespace ChroniclesOfADrifter.Components
{
    /// <summary>
    /// Inventory component - manages item storage
    /// </summary>
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private int maxSlots = 40;
        
        // Simple item structure for now
        [System.Serializable]
        public class ItemStack
        {
            public string itemId;
            public int quantity;
            
            public ItemStack(string id, int qty)
            {
                itemId = id;
                quantity = qty;
            }
        }
        
        private ItemStack[] slots;
        
        public int MaxSlots => maxSlots;
        public ItemStack[] Slots => slots;
        
        // Events
        public System.Action OnInventoryChanged;
        
        private void Awake()
        {
            slots = new ItemStack[maxSlots];
        }
        
        /// <summary>
        /// Add an item to the inventory
        /// </summary>
        public bool AddItem(string itemId, int quantity = 1)
        {
            // Try to stack with existing items first
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] != null && slots[i].itemId == itemId)
                {
                    slots[i].quantity += quantity;
                    OnInventoryChanged?.Invoke();
                    return true;
                }
            }
            
            // Find first empty slot
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] == null)
                {
                    slots[i] = new ItemStack(itemId, quantity);
                    OnInventoryChanged?.Invoke();
                    return true;
                }
            }
            
            return false; // Inventory full
        }
        
        /// <summary>
        /// Remove an item from the inventory
        /// </summary>
        public bool RemoveItem(string itemId, int quantity = 1)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i] != null && slots[i].itemId == itemId)
                {
                    slots[i].quantity -= quantity;
                    
                    if (slots[i].quantity <= 0)
                    {
                        slots[i] = null;
                    }
                    
                    OnInventoryChanged?.Invoke();
                    return true;
                }
            }
            
            return false;
        }
        
        /// <summary>
        /// Check if inventory contains an item
        /// </summary>
        public bool HasItem(string itemId, int quantity = 1)
        {
            int totalQuantity = 0;
            
            foreach (var slot in slots)
            {
                if (slot != null && slot.itemId == itemId)
                {
                    totalQuantity += slot.quantity;
                    if (totalQuantity >= quantity)
                        return true;
                }
            }
            
            return false;
        }
        
        /// <summary>
        /// Get total count of an item
        /// </summary>
        public int GetItemCount(string itemId)
        {
            int count = 0;
            
            foreach (var slot in slots)
            {
                if (slot != null && slot.itemId == itemId)
                {
                    count += slot.quantity;
                }
            }
            
            return count;
        }
    }
}
