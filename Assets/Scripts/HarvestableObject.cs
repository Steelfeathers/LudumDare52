using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LudumDare52
{
    public class HarvestableObject : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private GameObject highlightObj;
        [SerializeField][Range(1, 10)] private int damageToBreak = 1;
        [SerializeField] private Animator animator;
        
        [SerializeField] private ItemTemplate itemTemplate;

        private int curDamage;

        private bool isPointerHovered;
        private bool isInRange;
        public bool IsInRange
        {
            get => isInRange;
            set
            {
                isInRange = value;
                if (isInRange && isPointerHovered)
                    SetHighlighted(true);
                else if (!isInRange) 
                    SetHighlighted(false);
            }
        }
        
        private void Start()
        {
            SetHighlighted(false);
        }
        

        public void OnPointerClick(PointerEventData eventData)
        {
            if (!isInRange) return;
            //Debug.Log("Clicked on object!");
            DamageObject(1);
        }

        private void DamageObject(int amt)
        {
            curDamage += amt;
            if (curDamage >= damageToBreak)
            {
                //Harvest
                var itemObj = GameObject.Instantiate(GameManager.Instance.ItemWorldObjectPrefab.gameObject).GetComponent<ItemWorldObject>();
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

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!isInRange) return;
            isPointerHovered = true;
            SetHighlighted(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isPointerHovered = false;
            SetHighlighted(false);
        }

        private void SetHighlighted(bool enable)
        {
            if (highlightObj != null)  highlightObj.SetActive(enable);
        }
    }
}
