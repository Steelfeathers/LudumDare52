using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LudumDare52
{
    public class HarvestableObject : InteractableObject
    {
        [SerializeField][Range(1, 10)] private int damageToBreak = 1;
        [SerializeField] private Animator animator;
        
        [SerializeField] private ItemTemplate itemTemplate;

        private int curDamage;

        protected override void HandleOnPointerClick()
        {
            DamageObject(1);
        }

        public void DamageObject(int amt)
        {
            curDamage += amt;
            if (curDamage >= damageToBreak)
            {
                //Harvest
                var itemObj = GameObject.Instantiate(InventoryManager.Instance.ItemWorldObjectPrefab.gameObject).GetComponent<ItemWorldObject>();
                itemObj.gameObject.transform.position = transform.position;
                itemObj.Initialize(itemTemplate);
                
                GameObject.Destroy(gameObject);
            }
            else
            {
                //Wobble
                animator.SetTrigger("Damage");
            }
        }

       
    }
}
