using UnityEngine;

namespace Script.Core
{
    public class BirdMovement : MonoBehaviour
    {
        public float jumpForce;
        public float moveSpeed;

        Rigidbody2D rb;
        PlayerInput playerInput;
        GameStateController gameStateController;
        Animator anim;
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            playerInput = FindObjectOfType<PlayerInput>();
            gameStateController = FindObjectOfType<GameStateController>();
            anim = GetComponent<Animator>();
            playerInput.OnClicked += JumpForce;
            gameStateController.OnGameStateChanged += GameStart;
        }
        void FixedUpdate()
        {
            Move();
            Rotation();
        }
        void Move()
        {
            Vector2 velocity = new Vector2(moveSpeed, rb.velocity.y);
            rb.velocity = velocity;
        }
        void Rotation()
        {
            Vector2 velocityDirection = rb.velocity.normalized;
            float targetAngle = Mathf.Atan2(velocityDirection.y, velocityDirection.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, 0, targetAngle);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 10);
        }
        void JumpForce()
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        void GameStart(GameState gameState)
        {
            if (gameState==GameState.GameStarted)
            {
                anim.SetTrigger("Fly");
                rb.constraints = RigidbodyConstraints2D.None;
            }
           
        }
    }
}