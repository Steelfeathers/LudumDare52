using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FirebirdGames.Utilities.UI
{
    public class TooltipPopup : DialogPopup
    {
        public class Config
        {
            public string tooltipStr;
            public float fadeoutTime;
            public Vector2 targetPosition;
        }
        
        [SerializeField] private TextMeshProUGUI tooltipText;

        private float timer;

        public override void Initialize(object config = null, Action onClosedCallback = null)
        {
            base.Initialize(config, onClosedCallback);

            var c = config as Config;
            if (c == null) return;

            tooltipText.text = c.tooltipStr;
            if (c.fadeoutTime > 0) timer = c.fadeoutTime;

            transform.position = c.targetPosition;
        }

        public override float AnimateIn()
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(tooltipText.gameObject.RectTransform());
            return base.AnimateIn();
        }

        private void Update()
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                if (timer <= 0)
                {
                    OnCloseClicked();
                }
            }
        }
    }
}
