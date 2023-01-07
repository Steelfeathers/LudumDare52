using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace LudumDare52
{
    public class InteractableObject : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] protected Material materialNormal;
        [SerializeField] protected Material materialHighlighted;

        protected List<SpriteRenderer> spriteRenderers;
        protected bool isPointerHovered;
        public bool IsInRange; 
        
        private void Start()
        {
            SetHighlighted(false);
        }

        private void Update()
        {
            SetHighlighted(IsInRange && isPointerHovered);
        }


        public void OnPointerClick(PointerEventData eventData)
        {
            if (!IsInRange) return;
            HandleOnPointerClick();
        }

        protected virtual void HandleOnPointerClick()
        {
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            isPointerHovered = true;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            isPointerHovered = false;
        }

        protected void SetHighlighted(bool enable)
        {
            if (spriteRenderers == null)
            {
                spriteRenderers = new List<SpriteRenderer>();
                spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>().ToList();
            }

            foreach (var spriteRenderer in spriteRenderers)
            {
                spriteRenderer.material = enable ? materialHighlighted : materialNormal;
            }

        }
    }
}
