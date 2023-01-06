using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare52
{
    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
        private Camera cam;
        private GameObject player;

        private void Start()
        {
            cam = GetComponent<Camera>();
        }

        private void LateUpdate()
        {
            if (player == null || !player.activeInHierarchy)
                player = GameObject.FindWithTag("Player");
            
            if (player == null) return;
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        }
    }
}
