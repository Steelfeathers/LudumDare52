using System;
using System.Collections;
using System.Collections.Generic;
using FirebirdGames.Utilities;
using UnityEngine;

namespace LudumDare52
{
    public class GameManager : SingletonComponent<GameManager>, IInitializable
    {
        [Header("Stats")]
        [SerializeField] private int playerOxygenStart = 60;
        [SerializeField] private int playerStaminaStart = 100;
        
        [Space][Header("Inventory")]
        [SerializeField] private ItemWorldObject itemWorldObjectPrefab;
        [SerializeField] private int playerInventorySlotCountStart = 8;
        
        public ItemWorldObject ItemWorldObjectPrefab => itemWorldObjectPrefab;
        
        private GameObject playerObj;
        
        private int playerInventorySlotCount;
        private Dictionary<string, int> playerInventoryMap = new Dictionary<string, int>();
        
        private int playerStaminaMax;
        private int curPlayerStamina;
        
        private int playerOxygenMax;
        private float curPlayerOxygen;
        private bool isDiving;
        
        public GameObject PlayerObj
        {
            get
            {
                if (playerObj == null || !playerObj.activeInHierarchy)
                    playerObj = GameObject.FindWithTag("Player");

                return playerObj;
            }
        }
        
        //----------------------------------------------------------------------------------
        //---INVENTORY---
        //----------------------------------------------------------------------------------
        public void AddItemToInventory(string itemId, int count=1)
        {
            if (playerInventoryMap.ContainsKey(itemId))
                playerInventoryMap[itemId] += count;
            else
            {
                if (playerInventoryMap.Keys.Count >= playerInventorySlotCount)
                {
                    //TODO: No room message
                }
                else
                {
                    playerInventoryMap.Add(itemId, count);
                }
            }
        }

        //----------------------------------------------------------------------------------
        public void StartDive()
        {
            curPlayerOxygen = playerOxygenMax;
            isDiving = true;
        }

        public void EndDive()
        {
            isDiving = false;
        }

        private void Update()
        {
            if (Utils.IsPaused) return;
            if (isDiving)
            {
                curPlayerOxygen -= Time.deltaTime;
                if (curPlayerOxygen <= 0)
                {
                    //TODO: Gameover
                }
            }
            
#if UNITY_EDITOR
            //TESTING
            if (Input.GetKeyDown(KeyCode.P))
            {
                
            }
#endif
        }

        public void Initialize()
        {
        }

        public bool IsLoaded { get; set; }
        public bool IsReady { get; set; }
    }
}
