using UnityEngine;

namespace MonoBehaviours.Movement
{
    public abstract class CreatureMovement : MonoBehaviour
    {
        protected Rigidbody2D _rigidBody;
        protected SpriteRenderer _spriteRenderer;
        public float horizontalSpeed = 0.7f;
        public float verticalSpeed = 20f;
        protected bool _isJumping;

        public void Start()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        protected void MoveVertical()
        {
            if (_isJumping)
                return;
            
            _isJumping = true;
            _rigidBody.AddForce(new Vector2(0, verticalSpeed), ForceMode2D.Impulse);
        }

        protected void MoveHorizontal(float horizontalMovement)
        {
            _spriteRenderer.flipX = horizontalMovement < 0;

            _rigidBody.AddForce(horizontalSpeed * horizontalMovement * transform.right, ForceMode2D.Impulse);
        }

        protected void OnCollisionEnter2D(Collision2D hit)
        {
            _isJumping = false;
        }
    }
}