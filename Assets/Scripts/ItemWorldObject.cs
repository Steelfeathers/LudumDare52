using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace LudumDare52
{
    public class ItemWorldObject : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidBody;
        [SerializeField] private Collider2D pickupTriggerCollider;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private float dropBounceForce = 5f;
        [SerializeField] private float pickupDelay = 1f;
        [SerializeField] private float pickupMoveSpeed = 5f;
        [SerializeField] private float maxPickupDist = 10f;

        private ItemTemplate myItem;
        private bool isPickingUp;
        private float pickupTimer;
        
        public void Initialize(ItemTemplate template)
        {
            myItem = template;
            
            pickupTriggerCollider.enabled = false;
            spriteRenderer.sprite = template.Sprite;

            pickupTimer = pickupDelay;

            float randX = Random.Range(-0.3f, 0.3f);
            Vector2 dir = new Vector2(randX, 1f);
            rigidBody.AddForce(dir * dropBounceForce, ForceMode2D.Impulse);
        }

        private void Update()
        {
            if (!isPickingUp)
            {
                pickupTimer -= Time.deltaTime;
                if (pickupTimer <= 0)
                {
                    isPickingUp = true;
                    pickupTriggerCollider.enabled = true;
                }
            }
            else
            {
                float distToPlayer = Vector2.Distance(transform.position, GameManager.Instance.PlayerObj.transform.position);
                if (distToPlayer > maxPickupDist) //player out of range
                {
                    rigidBody.isKinematic = false; 
                }
                else
                {
                    rigidBody.isKinematic = true;
                    
                    Vector2 moveDir = (GameManager.Instance.PlayerObj.transform.position - transform.position).normalized;
                    moveDir *= pickupMoveSpeed * Time.deltaTime;
                    Vector3 targetPos = new Vector3(transform.position.x + moveDir.x, transform.position.y + moveDir.y, transform.position.z);
                    rigidBody.MovePosition(targetPos);
                }
                
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("PickupRadius"))
            {
                GameManager.Instance.AddItemToInventory(myItem.Id);
                GameObject.Destroy(gameObject);
            }
        }
    }
}
