using System;
using System.Collections;
using System.Collections.Generic;
using FirebirdGames.Utilities;
using FirebirdGames.Utilities.UI;
using UnityEngine;

namespace LudumDare52
{
    public class InventoryDialog : DialogPopup
    {
        [SerializeField] private GameObject itemSlotPrefab;
        [SerializeField] private Transform itemGrid;
        private List<ItemUIObject> items = new List<ItemUIObject>();
        private List<GameObject> slots = new List<GameObject>();

        public override void Initialize(object config = null, Action onClosedCallback = null)
        {
            base.Initialize(config, onClosedCallback);
            
            for (int i = 0; i < InventoryManager.Instance.InventorySlotCount; i++)
            {
                var slot = GameObject.Instantiate(itemSlotPrefab, itemGrid);
                slots.Add(slot);
            }

            //Populate inventory slots with items
            int index = 0;
            foreach (var itemId in InventoryManager.Instance.InventoryMap.Keys)
            {
                var item = GameObject.Instantiate(InventoryManager.Instance.ItemUIObjectPrefab.gameObject, slots[index].transform).GetComponent<ItemUIObject>();
                item.Initialize(InventoryManager.Instance.ItemTemplateMap[itemId], InventoryManager.Instance.InventoryMap[itemId]);
                items.Add(item);

                index += 1;
            }
            
            Utils.PauseApplication(true, flagOnly: false);
        }

        public override void OnCloseClicked()
        {
            Utils.PauseApplication(false, flagOnly: false);
            base.OnCloseClicked();
        }
    }
}
