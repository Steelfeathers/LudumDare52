using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare52
{
    public class PlayerControllerWater : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1f;
        
        private Rigidbody2D body;
        private Vector2 moveDir;


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
            if (Input.GetMouseButtonDown(0))
            {
               
            }
*/
        }

        private void UpdateMovementAndFacing()
        {
            //Calc new movement 
            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");
            moveDir = new Vector2(x, y).normalized;
            
        }

        private void LateUpdate()
        {
            body.velocity = moveDir * moveSpeed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Harvestable"))
            {
                other.GetComponent<HarvestableObject>().IsInRange = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Harvestable"))
            {
                other.GetComponent<HarvestableObject>().IsInRange = false;
            }
        }
    }
}
