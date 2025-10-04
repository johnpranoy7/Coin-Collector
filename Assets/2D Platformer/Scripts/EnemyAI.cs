using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class EnemyAI : MonoBehaviour
    {
        public float moveSpeed = 1f; 
        public LayerMask ground;
        public LayerMask wall;

        private Rigidbody2D rigidbody; 
        public Collider2D triggerCollider;
        private AudioSource enemySound;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();

            enemySound = GetComponent<AudioSource>();
        }

        void Update()
        {
            rigidbody.linearVelocity = new Vector2(moveSpeed, rigidbody.linearVelocity.y);
        }

        void FixedUpdate()
        {
            if(!triggerCollider.IsTouchingLayers(ground) || triggerCollider.IsTouchingLayers(wall))
            {
                Flip();
            }
        }
        
        private void Flip()
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            moveSpeed *= -1;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                AudioSource.PlayClipAtPoint(enemySound.clip, transform.position);
            }
        }
    }
}
