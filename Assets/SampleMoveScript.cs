using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class SampleMoveScript : MonoBehaviour
{
    Animator animator;

    int isWalkingHash;
    int isRunningHash;

    SampleCControls inputActions;

    public InputAction moveAction;

    Vector2 currentMovement;

    public float moveSpeed;
    public float runMultiplyer = 1;

    CharacterController cc;

    new float horizontalInput;
    new float verticalInput;

    Vector3 moveDir;

    bool movePressed;
    bool runPressed;
    bool runReleased;
    private void Awake()
    {

        inputActions = new SampleCControls();

        moveAction = inputActions.Movement.Move;
        moveAction.performed += ctx =>
        {
            currentMovement = ctx.ReadValue<Vector2>();
            movePressed = currentMovement.x != 0 || currentMovement.y != 0;
        };

        inputActions.Movement.Move.performed += ctx =>
        {
            currentMovement = ctx.ReadValue<Vector2>();
            movePressed = currentMovement.x != 0 || currentMovement.y != 0;
        };

        inputActions.Movement.Run.performed += ctx => runPressed = true;
        inputActions.Movement.Run.canceled += ctx => runPressed = false;
    }

    private void Run_performed(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void Move_performed(InputAction.CallbackContext obj)
    {
        //vector2 check for if y is greater than 0 to move forward

        //
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        print(runPressed);
        if (movePressed)
        {
            PlayerMove(currentMovement);
            print(currentMovement);
        }
    }

    void PlayerMove(Vector2 magnitude)
    {
        AnimatorLogic();

        float gravity = -9.81f;



        horizontalInput = magnitude.x;
        verticalInput = magnitude.y;

        moveDir =  transform.forward * verticalInput + transform.right * horizontalInput;
        // rb.AddForce(moveDir.normalized * moveSpeed, ForceMode.Force);



        if (runPressed)
        {
            runMultiplyer = 5f;
        }
        else if (!runPressed)
        {
            runMultiplyer = 1;
        }

        cc.Move((moveDir * moveSpeed) * runMultiplyer * Time.deltaTime);
        print(runMultiplyer);
    }

    private void AnimatorLogic()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);

        if (movePressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if (!movePressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if ((movePressed && runPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        if ((!movePressed && !runPressed) && isRunning)
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
}

public class CameraMove
{
    Transform player;

    bool autoRotation;

    float rotSpeed = 4f;


}
