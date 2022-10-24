using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

namespace IBR
{
    public class PlayerMover : MonoBehaviourPun
    {
        Animator animator;

        public ParticleSystem dust;

        private Rigidbody playerRB;

        int isWalkingHash;
        int isRunningHash;
        int punchHash;
        int kickHash;
        int dodgeHash;

        SampleCControls inputActions;

        public InputAction moveAction;
        public InputAction rotateRightAction;
        public InputAction rotateLeftAction;

        Vector2 currentMovement;
        Vector3 playerVelocity;

        public float moveSpeed = 3;
        public float runSpeed = 8;

        CharacterController cc;

        float horizontalInput;
        float verticalInput;

        public Transform groundCheck;
        float groundDistance = .5f;
        public LayerMask groundMask;

        Vector3 moveDir;

        bool walkPressed;
        bool runPressed;
        bool jumpPressed;
        bool punchPressed;
        bool kickPressed;
        bool dodgePressed;

        float movementAnimator;

        public float jumpHeight = 10f;
        private bool groundedPlayer;
        public float gravityScale = -9.81f;
        public float gravityModifyer;

        private void Awake()
        {
            inputActions = new SampleCControls();

            moveAction = inputActions.Movement.Move;

            moveAction.performed += ctx => currentMovement = ctx.ReadValue<Vector2>();
            moveAction.canceled += ctx => currentMovement = Vector2.zero;

            rotateRightAction.performed += ctx => ReadStick(ctx);

            walkPressed = currentMovement.x >= 0 || currentMovement.y >= 0;

            inputActions.Movement.Jump.performed += ctx => jumpPressed = true;
            inputActions.Movement.Jump.canceled += ctx => jumpPressed = false;

            inputActions.Movement.Run.performed += ctx => runPressed = true;
            inputActions.Movement.Run.canceled += ctx => runPressed = false;

            inputActions.Combat.Punck.performed += ctx => punchPressed = true;
            inputActions.Combat.Punck.canceled += ctx => punchPressed = false;

            inputActions.Combat.Kick.performed += ctx => kickPressed = true;
            inputActions.Combat.Kick.canceled += ctx => kickPressed = false;

            inputActions.Combat.Dodge.performed += ctx => dodgePressed = true;
            inputActions.Combat.Dodge.canceled += ctx => dodgePressed = false;

        }

        void Start()
        {
            cc = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
            Physics.gravity *= gravityModifyer;

            playerRB = GetComponent<Rigidbody>();

            isWalkingHash = Animator.StringToHash("isWalking");
            isRunningHash = Animator.StringToHash("isRunning");
            punchHash = Animator.StringToHash("Punch");
            kickHash = Animator.StringToHash("Kick");
            dodgeHash = Animator.StringToHash("Dodge");

            movementAnimator = Animator.StringToHash("Movement");
            animator.SetFloat("Movement", 0);

        }

        public void ReadStick(InputAction.CallbackContext ctx)
        {
            Vector2 stickDirection = ctx.ReadValue<Vector2>().normalized;

            RotateRight(stickDirection);
        }

        private void RotateAim(Vector2 direction)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        }

        public void RotateRight(Vector2 direction)
        {
            Vector3 targetDirection = new Vector3(direction.x, 0, direction.y);

            Quaternion lookRotation = Quaternion.LookRotation(targetDirection);

            Vector3 rotation = Vector3.RotateTowards(transform.forward, targetDirection, Time.deltaTime * 30, 0.0f);

            transform.rotation = Quaternion.LookRotation(rotation);

        }

        public void RotateLeft()
        {
            Vector3 targetDirection = transform.forward - new Vector3(0, -20, 0);

            Quaternion lookRotation = Quaternion.LookRotation(targetDirection);

            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 30).eulerAngles;

            transform.rotation = Quaternion.Euler(0, rotation.y, 0);
        }

        void Update()
        {
            // if (photonView.IsMine prevents other user input from affecting your character

            //if (photonView.IsMine)
            //{
                movementAnimator = currentMovement.magnitude;
                RaycastHit hit;
                if (Physics.Raycast(groundCheck.position, Vector3.down, out hit, groundDistance, groundMask))
                {
                    groundedPlayer = true;
                }
                if (moveAction.IsPressed())
                {
                    PlayerMove(currentMovement);
                }
                JumpLogic();
                AnimatorLogic();
            //}  
        }

        public void PlayerMove(Vector2 magnitude)
        {
            horizontalInput = magnitude.x;
            verticalInput = magnitude.y;

            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }
            moveDir = verticalInput * transform.forward + horizontalInput * transform.right;

            float speed = runPressed ? runSpeed : moveSpeed;
            transform.position += moveDir * speed * Time.deltaTime;
        }

        private void JumpLogic()
        {
            if (jumpPressed && groundedPlayer == true)
            {
                playerRB.AddForce((Vector3.up * jumpHeight), ForceMode.Impulse);
                groundedPlayer = false;
                animator.SetTrigger("Jump");
            }

        }

        private void AnimatorLogic()
        {
            if (walkPressed)
            {
                animator.SetFloat("Movement", movementAnimator);
            }
            bool isRunning = animator.GetBool(isRunningHash);
            bool isWalking = animator.GetBool(isWalkingHash);
            bool punching = animator.GetBool(punchHash);
            bool kicking = animator.GetBool(kickHash);
            bool isDodging = animator.GetBool(dodgeHash);

            if ((runPressed) && !isRunning)
            {
                animator.SetBool(isRunningHash, true);
                dust.Play();
            }
            if ((!runPressed && isRunning))
            {
                animator.SetBool(isRunningHash, false);
            }
            if (punchPressed)
            {
                if (!punching && groundedPlayer)
                {
                    animator.SetBool(punchHash, true);
                }
            }
            if (!punchPressed)
            {
                animator.SetBool(punchHash, false);
            }
            if (kickPressed)
            {
                if (!kicking && groundedPlayer)
                {
                    animator.SetBool(kickHash, true);
                }
            }
            if (!kickPressed)
            {
                animator.SetBool(kickHash, false);
            }
            if (dodgePressed) 
            {
                if(!isDodging && groundedPlayer && moveDir.x <=0 && moveDir.z >= 0) // allows dodge only if walking backwards
                {
                    animator.SetBool(dodgeHash, true);
                }
            }
            if (!dodgePressed)
            {
                animator.SetBool(dodgeHash, false);
            }
        }

        private void OnEnable()
        {
            inputActions.Movement.Enable();
            inputActions.Combat.Enable();
            rotateLeftAction.Enable();
            rotateRightAction.Enable();
        }

        private void OnDisable()
        {
            inputActions.Movement.Disable();
            inputActions.Combat.Disable();
            rotateLeftAction.Disable();
            rotateRightAction.Disable();
        }

    }

    public class CameraMove
    {
        Transform player;
    }

}
