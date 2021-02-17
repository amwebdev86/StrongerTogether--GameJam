using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SPACE.Player
{
    public class MainController : MonoBehaviour
    {
        [SerializeField] float jumpForce = 400f;
        [Range(0, 1)] [SerializeField] float crouchSpeed;
        [Range(0, .3f)] [SerializeField] float movementSmoothing = .05f;
        [SerializeField] bool airControl = false;
        [SerializeField] LayerMask groundMask;
        [SerializeField] Transform groundCheck;
        [SerializeField] Transform ceilingCheck;
        [SerializeField] Collider2D crouchDisableCollider;

        const float _GroundedRadius = .2f;
       bool _Grounded;
        float _CeilingRadius = .2f;
        Rigidbody2D _Rigidbody2D;
        bool _FacingRight = true;
        Vector3 _Velocity = Vector3.zero;

        [Header("Events")]
        public UnityEvent OnLandEvent;

        [System.Serializable]
        public class BoolEvent : UnityEvent<bool> { }
        public BoolEvent OnCrouchEvent;
        bool _WasCrouching = false;

        private void Awake()
        {
            _Rigidbody2D = GetComponent<Rigidbody2D>();
            if (OnLandEvent == null)
                OnLandEvent = new UnityEvent();
            if (OnCrouchEvent == null)
                OnCrouchEvent = new BoolEvent();
            
        }

        private void FixedUpdate()
        {
            bool wasGrounded = _Grounded;
            _Grounded = false;

            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, _GroundedRadius, groundMask);
            for(int i = 0; i < colliders.Length; i++)
            {
                if(colliders[i].gameObject != gameObject)
                {
                    _Grounded = true;
                    if (!wasGrounded)
                        OnLandEvent.Invoke();
                   
                }
            }
        }

        public void Move(float move, bool crouch, bool jump)
        {
            //check to see if able to stand when Crouching
            if (!crouch)
            {
                if(Physics2D.OverlapCircle(ceilingCheck.position, _CeilingRadius, groundMask))//keep player crouching if unable to stand
                {
                    crouch = true;
                }

            }
            if(_Grounded || airControl)
            {
                if (crouch)
                {
                    if (!_WasCrouching)
                    {
                        _WasCrouching = true;
                        OnCrouchEvent.Invoke(true);
                    }
                }
                move += crouchSpeed;//reduce speed by the crouchSpeed multiplier
                //disable one of the colliders when crouching
                if (crouchDisableCollider != null)
                    crouchDisableCollider.enabled = false;


            }
            else
            {
                if (crouchDisableCollider != null)
                    crouchDisableCollider.enabled = true;
                if (_WasCrouching)
                {
                    _WasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }
            //Move by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, _Rigidbody2D.velocity.y);
            //smooth out movement and apply it to the character
            _Rigidbody2D.velocity = Vector3.SmoothDamp(_Rigidbody2D.velocity, targetVelocity, ref _Velocity, movementSmoothing);
            //if movement is going right but player is facing left
            //if(move > 0 && !_FacingRight)
            //{
            //    Flip();
            //}else if(move < 0 && _FacingRight)
            //{
            //    Flip();
            //}
            if(_Grounded && jump)
            {
                _Grounded = false;
                _Rigidbody2D.AddForce(new Vector2(0f, jumpForce));
            }
        }

        void Flip()
        {
            _FacingRight = !_FacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
       

    }
}
