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

    SampleCControls inputActions;

    public InputAction moveAction;

    Vector2 currentMovement;
    Vector3 playerVelocity;

    public float moveSpeed;
    public float runMultiplyer = 1;

    CharacterController cc;

    float horizontalInput;
    float verticalInput;

    public Transform groundCheck;
    float groundDistance = 1;
    public LayerMask groundMask;

    Vector3 moveDir;

    bool movePressed;
    bool runPressed;
    bool jumpPressed;

    float gravity = 3f;
    public float jumpHeight = 10f;
    private bool groundedPlayer;

    private Vector2 currentImputVector;
    private Vector2 smoothDampVelocity;

    [SerializeField] private float smoothInputSpeed = .2f;
    private void Awake()
    {

        inputActions = new SampleCControls();

        moveAction = inputActions.Movement.Move;

        moveAction.performed += ctx =>
        {
            currentMovement = ctx.ReadValue<Vector2>();
            movePressed = currentMovement != Vector2.zero && moveAction.IsPressed();
        };

        inputActions.Movement.Jump.performed += ctx => jumpPressed = true;
        inputActions.Movement.Jump.canceled += ctx => jumpPressed = false;

        inputActions.Movement.Run.performed += ctx => runPressed = true;
        inputActions.Movement.Run.canceled += ctx => runPressed = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        gravity = Physics.gravity.y * 2;

        playerRB = GetComponent<Rigidbody>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, Vector3.down, out hit, groundDistance, groundMask))
        {
            groundedPlayer = true;
        }
        Debug.Log("Hey" + groundedPlayer);
        if (moveAction.IsPressed() && groundedPlayer)
        {
            PlayerMove(currentMovement);
        }
    }

    public void PlayerMove(Vector2 magnitude)
    {
        AnimatorLogic();
        horizontalInput = magnitude.x;
        verticalInput = magnitude.y;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        moveDir = verticalInput * transform.forward + horizontalInput * transform.right;

        playerVelocity = moveDir;

        if (runPressed)
        {
          runMultiplyer = 5f; 
        }
        else if (!runPressed)
        {
          runMultiplyer = 1;
        }

        transform.position += playerVelocity * runMultiplyer * moveSpeed * Time.deltaTime;
        
        //playerRB.velocity = new Vector3(playerVelocity.x, 0, playerVelocity.y) * runMultiplyer * moveSpeed * Time.deltaTime;

        //horizontalInput = magnitude.x;
        //verticalInput = magnitude.y;

        //moveDir = verticalInput * transform.forward + horizontalInput * transform.right;

        //playerVelocity = moveDir.normalized;

        //if (runPressed)
        //{
        //    runMultiplyer = 5f;
        //}
        //else if (!runPressed)
        //{
        //    runMultiplyer = 1;
        //}

        //transform.position += playerVelocity * runMultiplyer * moveSpeed * Time.deltaTime;

        if (jumpPressed && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
        playerVelocity.y += gravity * Time.deltaTime;

        if (jumpPressed && groundedPlayer)
        {
            playerRB.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            groundedPlayer = false;
            //playerAnim.SetTrigger("Jump_trig");
        }
    }

    private void AnimatorLogic()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);

        if (movePressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if (movePressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if ((movePressed && runPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        if ((movePressed && !runPressed) && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    private void OnEnable()
    {
        inputActions.Movement.Enable();
    }

    private void OnDisable()
    {
        inputActions.Movement.Disable();
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

    bool autoRotation;

    float rotSpeed = 4f;


}
