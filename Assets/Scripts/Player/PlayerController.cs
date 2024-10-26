using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;
    [Header("Look")]
    public Transform CameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float cameraSensitivity;
    public bool canLook = true;
    private Vector2 mouseDelta;


    private Rigidbody rb;
   

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
          
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
        
    }

    private void LateUpdate()
    {
        CameraLook();
    }
    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
        Debug.Log(mouseDelta);
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = rb.velocity.y;

        rb.velocity = dir;
    }

    private void CameraLook()
    {
        camCurXRot += mouseDelta.y * cameraSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        CameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * cameraSensitivity, 0);
    }

   
}
