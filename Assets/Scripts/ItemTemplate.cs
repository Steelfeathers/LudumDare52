using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare52
{
    public enum ItemRarity
    {
        
    }
    
    [CreateAssetMenu(menuName = "LudumDare52/Item", fileName = "Item", order = 0)]
    public class ItemTemplate : ScriptableObject
    {
        [SerializeField] private string displayName;
        [SerializeField] private Sprite sprite;

        public string Id => name;
        public string DisplayName => displayName;
        public Sprite Sprite => sprite;
    }
}
