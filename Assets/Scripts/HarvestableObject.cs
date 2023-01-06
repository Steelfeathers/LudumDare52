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
            Debug.Log("Clicked on object!");
            GameObject.Destroy(gameObject);
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
