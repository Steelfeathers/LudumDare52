using System;
using System.Collections;
using System.Collections.Generic;
using FirebirdGames.Utilities;
using FirebirdGames.Utilities.UI;
using UnityEngine;

namespace LudumDare52
{
    public class GameManager : SingletonComponent<GameManager>, IInitializable
    {
        [Header("Stats")]
        [SerializeField] private int playerOxygenStart = 60;
        [SerializeField] private int playerStaminaStart = 100;
        
        private GameObject playerObj;
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

        protected override void Awake()
        {
            base.Awake();
            IsLoaded = true;
        }

        public void Initialize()
        {
            IsReady = true;
        }

        //----------------------------------------------------------------------------------
        public void StartDive()
        {
            curPlayerOxygen = playerOxygenMax;
            isDiving = true;
            
           // diveHUDDialog.gameObject.SetActive(true);
           // diveHUDDialog.UpdateOxygenMeter(curPlayerOxygen, playerOxygenMax);
            //diveHUDDialog.UpdateStaminaMeter(curPlayerStamina, playerStaminaMax);
        }

        public void EndDive()
        {
            isDiving = false;
            //diveHUDDialog.gameObject.SetActive(false);
        }

        private void Update()
        {
            if (Utils.IsPaused) return;

            //Open inventory
            if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Tab))
            {
                UIManager.Instance.ShowOverlayDialog(UIReferences.Instance.InventoryDialogPrefab);
            }
            
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
        
        public bool IsLoaded { get; set; }
        public bool IsReady { get; set; }
    }
}
