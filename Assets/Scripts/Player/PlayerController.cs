using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.InputSystem;



public partial class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpForce;
    [Header("Look")]
    public Transform CameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float cameraSensitivity;
    public bool canLook = true;

    public Camera currentCamera;
    private Rigidbody rb;
    public LayerMask laymask;
    public Action pickaxeThrow;
    public Action toggleCamera;
    public bool isPlayerPush = false;
    public bool followPlatform = false;



    private void Start()
    {
        currentCamera = Camera.main.GetComponent<Camera>();
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

    }

 

    public void Move(Vector2 vector2)
    {
        if (!isPlayerPush)
        {
            Debug.Log("이동중");
            Vector3 dir = transform.forward * vector2.y + transform.right * vector2.x;
            dir *= moveSpeed;
            dir.y = rb.velocity.y;

            rb.velocity = dir;
        }
    
    }


    public void Jump()
    {     
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    public void CameraLook(Vector2 vector2)
    {
        camCurXRot += vector2.y * cameraSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        CameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, vector2.x * cameraSensitivity, 0);
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

    public void AddPlayerForce(Vector3 value,float force)
    {
        rb.AddForce(value * force, ForceMode.Impulse);
    }

    public void PlayerPushToggleCoroutine()
    {
        Debug.Log("토글 코루틴 실행");
        StartCoroutine(PlyaerPushToggle());
    }

    private IEnumerator PlyaerPushToggle()
    {
        isPlayerPush = true;
        yield return new WaitForSeconds(2f);
        isPlayerPush = false ;

    }

    public void FollowPlatform(Vector3 moveVec)
    {
        if (followPlatform)
        {
            transform.position += moveVec;
        }
        
    }

   
}

