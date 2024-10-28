using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;
    public float jumpForce;
    [Header("Look")]
    public Transform CameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float cameraSensitivity;
    public bool canLook = true;
    private Vector2 mouseDelta;

    public Camera currentCamera;
    private Rigidbody rb;
    public LayerMask laymask;
    public Action pickaxeThrow;
    public Action toggleCamera;

    private void Start()
    {
        currentCamera = Camera.main.GetComponent<Camera>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {
        Debug.Log(IsGrounded());
    }

    private void FixedUpdate()
    {
        Move();

    }

    private void LateUpdate()
    {
        CameraLook();
    }
    public void OnMoveInput(InputAction.CallbackContext context) // ToDo : 리팩토링 클래스분리
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

    public void OnLookInput(InputAction.CallbackContext context) // ToDo : 리팩토링 클래스분리
    {
        mouseDelta = context.ReadValue<Vector2>();
        Debug.Log(mouseDelta);
    }

    public void OnThrowInput(InputAction.CallbackContext context) // ToDo : 리팩토링 클래스분리
    {
        pickaxeThrow?.Invoke();
    }

    public void OnChangeCamera(InputAction.CallbackContext context) // ToDo : 리팩토링 클래스분리
    {
        toggleCamera?.Invoke();
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = rb.velocity.y;

        rb.velocity = dir;
    }
    public void OnJumpInput(InputAction.CallbackContext context) // ToDo : 리팩토링 클래스분리
    {
        if (context.phase == InputActionPhase.Performed && IsGrounded())
        {
            Jump();
        }
    }

    private void Jump()
    {
        Debug.Log("점프");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }

    private void CameraLook()
    {
        camCurXRot += mouseDelta.y * cameraSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        CameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * cameraSensitivity, 0);
    }

    public bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.1f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.1f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.1f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.1f), Vector3.down)

        };

        for (int i = 0; i < rays.Length; i++)
        {
            RaycastHit hit;
            if (Physics.Raycast(rays[i], out hit, 0.5f))
            {
                Debug.DrawRay(rays[i].origin, rays[i].direction * 0.5f, Color.red);
                if (hit.collider.CompareTag("Ground"))
                {
                    Debug.Log("땅에 있음");
                    return true;
                }

            }
            Debug.DrawRay(rays[i].origin, rays[i].direction * 1f, Color.green);

        }
        Debug.Log("공중에 있음");
        return false;

    }


    public void SpeedChangeCoroutine(float speed, float time)
    {
        StartCoroutine(ChangeMoveSpeed(speed, time));
    }
    public IEnumerator ChangeMoveSpeed(float speed, float time)
    {
        moveSpeed += speed;

        yield return new WaitForSeconds(time);

        moveSpeed -= speed;

    }

    void ToggleCursor()
    {
        bool toggle = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;

    }

  
}

