using System.Collections;
using System.Collections.Generic;
using FirebirdGames.Utilities;
using FirebirdGames.Utilities.UI;
using UnityEngine;

namespace LudumDare52
{
    public class UIReferences : SingletonComponent<UIReferences>, IInitializable
    {
        [SerializeField] private Dialog titleDialogPrefab;
        [SerializeField] private Dialog diveHUDDialogPrefab;
        [SerializeField] private Dialog inventoryDialogPrefab;

        public Dialog TitleDialogPrefab => titleDialogPrefab;
        public Dialog DiveHUDDialogPrefab => diveHUDDialogPrefab;
        public Dialog InventoryDialogPrefab => inventoryDialogPrefab;
        
        protected override void Awake()
        {
            base.Awake();
            IsLoaded = true;
        }

        public void Initialize()
        {
            IsReady = true;
        }

        public bool IsLoaded { get; set; }
        public bool IsReady { get; set; }
    }
}
