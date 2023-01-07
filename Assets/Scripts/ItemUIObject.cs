using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LudumDare52
{
    public class ItemUIObject : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TextMeshProUGUI amountText;

        private ItemTemplate template;
        private int amount;

        public void Initialize(ItemTemplate _template, int _amount)
        {
            template = _template;
            amount = _amount;

            image.sprite = template.Sprite;
            amountText.text = amount.ToString();
        }
    }
}
