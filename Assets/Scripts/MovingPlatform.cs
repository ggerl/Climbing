using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


public class MovingPlatform : MonoBehaviour
{

    public enum MoveDirection
    {
        front,
        right,
        left,
        back
    }
    [SerializeField] MoveDirection myDir;
    private Rigidbody rb;
    private Vector3 dir;
    public float moveSpeed;
    private Vector3 moveVec;
    PlayerController playercontroller;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // 방향 벡터 초기화
        switch (myDir)
        {
            case MoveDirection.front:
                dir = Vector3.forward;
                break;
            case MoveDirection.right:
                dir = Vector3.right;
                break;
            case MoveDirection.left:
                dir = Vector3.left;
                break;
            case MoveDirection.back:
                dir = Vector3.back;
                break;
        }
    }

    void FixedUpdate()
    {
        moveVec = dir * moveSpeed * Time.fixedDeltaTime;
        Vector3 newPosition = new Vector3(transform.position.x + moveVec.x, transform.position.y, transform.position.z + moveVec.z);
        rb.MovePosition(newPosition);
        if (playercontroller != null)
        {
            playercontroller.FollowPlatform(moveVec);
        }
        
    }

    public void ReversVec()
    {
        dir = -dir;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.collider.TryGetComponent<PlayerController>(out playercontroller))
        {
            Debug.Log("PlayerController를 찾았습니다.");
            playercontroller.followPlatform = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (playercontroller == null) return;

        playercontroller.followPlatform = false;
        playercontroller = null;


    }


}
