using System.Collections;
using System.Collections.Generic;
using FirebirdGames.Utilities;
using UnityEngine;

namespace LudumDare52
{
    public class PlayerControllerWater : MonoBehaviour
    {
        [SerializeField] private Transform spriteHolder;
        [SerializeField] private Animator animator;
        [SerializeField] private float moveSpeed = 1f;
        [SerializeField] private Collider2D selectionRangeCollider;
        [SerializeField] private float selectionDist = 512f;
        
        private Rigidbody2D body;
        private Vector2 moveDir;
        private float swimAngle;
        private float prevSwimAngle;


        private void Start()
        {
            body = gameObject.GetComponent<Rigidbody2D>();

        }

        private void Update()
        {
            UpdateMovementAndFacing();
            
            /*
            RaycastHit2D[] rayHits = Physics2D.GetRayIntersectionAll(Camera.main.ScreenPointToRay(Input.mousePosition), 512, LayerMask.GetMask("Harvestable"));
            if (rayHits != null && rayHits.Length > 0)
            {
                Debug.Log("Hit something!");
            }
            */
            /*
            Vector2 raycastDir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            var hit = Physics2D.Raycast(transform.position, raycastDir, selectionDist, LayerMask.GetMask("Harvestable"));
            if (hit)
            {
                var harvestableObj = hit.collider.gameObject.GetComponent<HarvestableObject>();
                if (harvestableObj != null)
                    harvestableObj.IsInRange = true;
            }
            */
            /*
            List<Collider2D> overlappedHarvestableColliders = new List<Collider2D>();
            selectionRangeCollider.OverlapCollider(new ContactFilter2D(){layerMask = LayerMask.GetMask("Harvestable")}, overlappedHarvestableColliders);
            */
        }

        private void UpdateMovementAndFacing()
        {
            //Calc new movement 
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            moveDir = new Vector2(x, y).normalized;

            bool isSwimming = moveDir != Vector2.zero;
            if (isSwimming)
            {
                if (moveDir.x > 0 && moveDir.y > 0) swimAngle = -45f; //UP_RIGHT 
                else if (moveDir.x < 0 && moveDir.y < 0) swimAngle = 135f; //DOWN_LEFT
                else if (moveDir.x > 0 && moveDir.y < 0) swimAngle = -135f; //DOWN_RIGHT
                else if (moveDir.x < 0 && moveDir.y > 0) swimAngle = 45f; //UP_LEFT
                else if (moveDir.x > 0) swimAngle = -90; //RIGHT
                else if (moveDir.x < 0) swimAngle = 90; //LEFT
                else if (moveDir.y > 0) swimAngle = 0f; //UP
                else if (moveDir.y < 0) swimAngle = 180f; //DOWN

                float xScaleMult = 1f;
                if ((prevSwimAngle >= 0 && swimAngle < 0) || (prevSwimAngle < 0 && swimAngle >= 0))
                    xScaleMult = -1f;

                spriteHolder.eulerAngles = Vector3.forward * swimAngle;
                Vector3 curScale = spriteHolder.localScale;
                spriteHolder.localScale = new Vector3(curScale.x * xScaleMult, curScale.y, curScale.z);

                prevSwimAngle = swimAngle;
            }

            if (animator.GetBool("IsSwimming") != isSwimming)
            {
                animator.SetBool("IsSwimming", isSwimming);
            }

            
        }

        private void LateUpdate()
        {
            body.velocity = moveDir * moveSpeed;
        }

       
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Interactable"))
            {
                other.GetComponent<InteractableObject>().IsInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Interactable"))
            {
                other.GetComponent<InteractableObject>().IsInRange = false;
            }
        }
       
    }
}
