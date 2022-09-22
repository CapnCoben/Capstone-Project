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


    Vector2 currentMovement;

    bool movePressed;
    bool runPressed;
    private void Awake()
    {
        inputActions = new SampleCControls();


        inputActions.Movement.Move.performed += ctx =>
        {
            currentMovement = ctx.ReadValue<Vector2>();
            movePressed = currentMovement.x != 0 || currentMovement.y != 0;
        };

        inputActions.Movement.Run.performed += ctx => runPressed = ctx.ReadValueAsButton();
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
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);

        if(movePressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }
        if(!movePressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }

        if((movePressed && runPressed) && !isRunning) 
        {
            animator.SetBool(isRunningHash, true);
        }
        if((!movePressed && !runPressed) && isRunning)
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
