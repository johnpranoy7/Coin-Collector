using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using myUIEvents;


namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        public float movingSpeed;
        public float jumpForce;
        private float moveInput;
        private bool jumpFlag = false;
        private bool keyboardControlFlag = false;

        private bool facingRight = false;
        [HideInInspector]
        public bool deathState = false;

        private bool isGrounded;
        public Transform groundCheck;

        private Rigidbody2D rigidbody;
        private Animator animator;
        private GameManager gameManager;
        public HealthBar healthBar;
        [SerializeField] private AudioSource coinSound;
        [SerializeField] private AudioSource deathSound;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            //coinSound = GetComponent<AudioSource>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            //healthBar = GameObject.Find("HealthBar").GetComponent<HealthBar>();
            healthBar.setMaxHealth(100);
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        private void OnEnable()
        {
            MobileHandler.goLeftEvent.AddListener(updateLeftMove);
            MobileHandler.goRightEvent.AddListener(updateRightMove);
            MobileHandler.stopMovingEvent.AddListener(stopMove);
            MobileHandler.goUpEvent.AddListener(jump);
            Debug.Log("All listeners added");
        }

        private void OnDisable()
        {
            MobileHandler.goLeftEvent.RemoveListener(updateLeftMove);
            MobileHandler.goRightEvent.RemoveListener(updateRightMove);
            MobileHandler.stopMovingEvent.RemoveListener(stopMove);
            MobileHandler.goUpEvent.RemoveListener(jump);
            Debug.Log("All listeners removed");
        }

        private void updateLeftMove() // new
        {
            moveInput = -1;
            Debug.Log("Left event received");
        }

        private void updateRightMove() // new
        {
            moveInput = 1;
        }

        private void stopMove() // new
        {
            moveInput = 0;
        }

        private void jump()
        {
            Debug.Log("Jump event received");
            jumpFlag = true;
        }


        void Update()
        {
            if (Input.GetButton("Horizontal"))
            {
                moveInput = Input.GetAxis("Horizontal");
                keyboardControlFlag = true;
            }
            else 
            {
                keyboardControlFlag = false;
            }


            if (moveInput!=0) 
            {
                Vector3 direction = transform.right * moveInput;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
                animator.SetInteger("playerState", 1); // Turn on run animation
            }
            else
            {
                if (isGrounded) animator.SetInteger("playerState", 0); // Turn on idle animation
            }

            

            if ((Input.GetKeyDown(KeyCode.Space) || jumpFlag) && isGrounded)
            {
                rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                AudioSource.PlayClipAtPoint(coinSound.clip, transform.position);
                jumpFlag = false;
            }
            if (!isGrounded)animator.SetInteger("playerState", 2); // Turn on jump animation


            if(facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if(facingRight == true && moveInput < 0)
            {
                Flip();
            }


            /* The eventListener method is triggered only once even if we keep holding the button on UI. 
             * Whereas for the keyboard navigation it keeps sending the event. 
             * So setup custom flag to reset moveInput for every frame in case of Keyboard */
            if(keyboardControlFlag)
                moveInput = 0; // reset moveInput after processing
        }

        private void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
            isGrounded = colliders.Length > 1;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                //deathState = true; // Say to GameManager that player is dead
                healthBar.setHealth(healthBar.healthSlider.value - 20);
                rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse); 
                Debug.Log("Player hit by enemy. Health: " + healthBar.healthSlider.value);
            }
            
            if(healthBar.healthSlider.value <= 0)
            {
                deathState = true;
                AudioSource.PlayClipAtPoint(deathSound.clip, transform.position);
            }
            else
            {
                deathState = false;
            }

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Coin")
            {
                gameManager.coinsCounter += 1;
                Destroy(other.gameObject);
            }
        }
    }
}
