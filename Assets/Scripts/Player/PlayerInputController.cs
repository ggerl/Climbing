using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private PlayerController playerController;
    public Action pickaxeThrow;
    public Action toggleCamera;
    private Vector2 moveInput;
    public bool followPlatform = false;

    


    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {

        playerController.Move(moveInput);
       
    }

    public void OnMoveInput(InputAction.CallbackContext context) // TODO : 리팩토링 클래스분리
    {
        if (context.phase == InputActionPhase.Performed)
        {
            moveInput = context.ReadValue<Vector2>();
         
        
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            moveInput = Vector2.zero;
        
        }
    }

    public void OnLookInput(InputAction.CallbackContext context) // TODO : 리팩토링 클래스분리
    {
        playerController.CameraLook(context.ReadValue<Vector2>());      
    }

    public void OnThrowInput(InputAction.CallbackContext context) // TODO : 리팩토링 클래스분리
    {
        pickaxeThrow?.Invoke();
    }

    public void OnChangeCamera(InputAction.CallbackContext context) // TODO : 리팩토링 클래스분리
    {
        toggleCamera?.Invoke();
    }

    public void OnJumpInput(InputAction.CallbackContext context) // TODO : 리팩토링 클래스분리
    {
        if (context.phase == InputActionPhase.Performed && playerController.IsGrounded())
        {
            playerController.Jump();
        }
    }
}

