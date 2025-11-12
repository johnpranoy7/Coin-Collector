using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class EnemyAI : MonoBehaviour
    {
        public float moveSpeed = 1f;
        public float pointAX; // X coordinate of point A
        public float pointBX; // X coordinate of point B

        private Rigidbody2D rigidbody2D;
        private float targetX;
        private bool movingToPointB = true;
        public Collider2D triggerCollider;
        private AudioSource enemySound;

        void Start()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            enemySound = GetComponent<AudioSource>();

            // Start at point A's X position, keep Y the same
            Vector2 startPos = rigidbody2D.position;
            rigidbody2D.position = new Vector2(pointAX, startPos.y);
            targetX = pointBX;
        }

        void Update()
        {
            Vector2 currentPos = rigidbody2D.position;
            float step = moveSpeed * Time.deltaTime;
            float newX = Mathf.MoveTowards(currentPos.x, targetX, step);

            // Move the Rigidbody2D
            rigidbody2D.MovePosition(new Vector2(newX, currentPos.y));

            // Check if within snapping distance
            if (Mathf.Abs(newX - targetX) < 0.05f)
            {
                // Snap exactly to targetX to prevent overshoot
                rigidbody2D.position = new Vector2(targetX, currentPos.y);

                // Switch direction
                movingToPointB = !movingToPointB;
                targetX = movingToPointB ? pointBX : pointAX;
                Flip();
            }
        }


        private void Flip()
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            //moveSpeed *= -1; // Optional keep speed direction aligned with facing direction
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

