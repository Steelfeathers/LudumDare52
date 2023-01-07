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

        private void Start()
        {
            cam = GetComponent<Camera>();
        }

        private void LateUpdate()
        {
            if (GameManager.Instance.PlayerObj == null) return;
            transform.position = new Vector3(GameManager.Instance.PlayerObj.transform.position.x, GameManager.Instance.PlayerObj.transform.position.y, transform.position.z);
        }
    }
}
