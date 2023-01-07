using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare52
{
    public class TrashSpawnNode : MonoBehaviour
    {
        [SerializeField] private int spawnMin;
        [SerializeField] private int spawnMax;
        [SerializeField] private List<HarvestableObject> trashPrefabs;
        [SerializeField] private List<int> trashSpawnWeights;
        private void Start()
        {
            
        }
    }
}
