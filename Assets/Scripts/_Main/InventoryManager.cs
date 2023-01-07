using System.Collections;
using System.Collections.Generic;
using FirebirdGames.Utilities;
using UnityEngine;

namespace LudumDare52
{
    public class InventoryManager : SingletonComponent<InventoryManager>, IInitializable
    {
        [Header("Item Database")] 
        [SerializeField] private List<ItemTemplate> allItemTemplates;
        
        [Space][Header("Player Inventory")]
        [SerializeField] private ItemWorldObject itemWorldObjectPrefab;
        [SerializeField] private ItemUIObject itemUIObjectPrefab;
        [SerializeField] private int inventorySlotCountStart = 8;
        
        public ItemWorldObject ItemWorldObjectPrefab => itemWorldObjectPrefab;
        public ItemUIObject ItemUIObjectPrefab => itemUIObjectPrefab;
        public Dictionary<string, int> InventoryMap => inventoryMap;
        public Dictionary<string, ItemTemplate> ItemTemplateMap => itemTemplateMap;
        public int InventorySlotCount => inventorySlotCount;
        
        
        private int inventorySlotCount;
        private Dictionary<string, ItemTemplate> itemTemplateMap = new Dictionary<string, ItemTemplate>();
        private Dictionary<string, int> inventoryMap = new Dictionary<string, int>();

        //----------------------------------------------------------------------------------
        protected override void Awake()
        {
            base.Awake();
            IsLoaded = true;
        }
        
        public void Initialize()
        {
            //init inventory size
            inventorySlotCount = inventorySlotCountStart;
            
            //Load all item templates and store them in a map by their Ids
            foreach (var template in allItemTemplates)
            {
                if (itemTemplateMap.ContainsKey(template.Id))
                {
                    Debug.LogError($"Duplicate item {template.Id} found!");
                    continue;
                }
                
                itemTemplateMap.Add(template.Id, template);
            }
            
            IsReady = true;
        }

        //----------------------------------------------------------------------------------
        //---INVENTORY---
        //----------------------------------------------------------------------------------
        public void AddItemToInventory(string itemId, int count=1)
        {
            if (inventoryMap.ContainsKey(itemId))
                inventoryMap[itemId] += count;
            else
            {
                if (inventoryMap.Keys.Count >= inventorySlotCount)
                {
                    //TODO: No room message
                }
                else
                {
                    inventoryMap.Add(itemId, count);
                }
            }
        }
        
        public bool IsLoaded { get; set; }
        public bool IsReady { get; set; }
    }
}
