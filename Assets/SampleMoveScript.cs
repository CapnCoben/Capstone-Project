using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class SampleMoveScript : MonoBehaviour
{
    Animator animator;

    private Rigidbody playerRB;

    int isWalkingHash;
    int isRunningHash;
    int punchHash;
    int kickHash;

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

    float movementAnimator;

    //float initialJumpVelocity;
    //float maxJumpHeight;
    //float maxJumpTime;
    public float jumpHeight = 10f;
    //bool isJumping = false;
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

        //SetupJump();
    }

    // Start is called before the first frame update
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

    //private void FixedUpdate()
    //{
       
    //}

    // Update is called once per frame
    void Update()
    {
        movementAnimator = currentMovement.magnitude;
        AnimatorLogic();
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
    }

    //void SetupJump()
    //{
    //    float timeToApex = maxJumpTime / 2;
    //    gravityScale = (-2 * maxJumpHeight) / Mathf.Pow(timeToApex, 2);
    //    initialJumpVelocity = (2 * maxJumpHeight) / timeToApex;
    //}

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
        
        //playerVelocity.y += gravityScale * Time.deltaTime;
    }

    private void JumpLogic()
    {
        if(jumpPressed && groundedPlayer == true)
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
            //Debug.Log(movementAnimator);
        }
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool punching = animator.GetBool(punchHash);
        bool kicking = animator.GetBool(kickHash);

        if ((runPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
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


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        groundedPlayer = true;

    //        Debug.Log("On Ground");
    //    }
    //    //else if (collision.gameObject.CompareTag("Water"))
    //    //{
    //    //    Debug.Log("Game Over!");
    //    //    gameOver = true;
    //    //    playerAnim.SetBool("Death_b", true);
    //    //    playerAnim.SetInteger("DeathType_int", 1);
    //    //}
    //}
}

public class CameraMove
{
    Transform player;

    //bool autoRotation;

}
