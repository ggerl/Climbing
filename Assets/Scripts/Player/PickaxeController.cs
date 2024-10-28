using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeController : MonoBehaviour
{
    public GameObject pickaxePrefab; // 곡괭이 프리펩
    public Transform handTransform; // 손의 Transform
    public Animator animator; // 플레이어의 애니메이터
    public string throwAnimationName = "Throw"; // 던지기 애니메이션 이름
    public float throwForce = 10f; // 던질 힘

    public float respawnTime;
    public Rigidbody rb;
    private GameObject currentPickaxe; // 현재 손에 있는 곡괭이
    private bool isHolding = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        handTransform = animator.GetBoneTransform(HumanBodyBones.RightHand);
        // 곡괭이 생성
        SpawnPickaxe();


    }

    void Update()
    {
        // 특정 키를 눌렀을 때 애니메이션 재생
        if (Input.GetKey(KeyCode.R)) // 예: R키를 눌렀을 때
        {
            animator.SetBool(throwAnimationName, true); // 애니메이션 재생
        }
        else
        {
            animator.SetBool(throwAnimationName, false); // 애니메이션 정지
        }

        // 던지기 버튼을 눌렀을 때
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 클릭
        {
            ThrowPickaxe();
        }
    }

    private void ThrowPickaxe()
    {
        if (currentPickaxe != null)
        {
            // 곡괭이를 손에서 분리
            currentPickaxe.transform.SetParent(null);
            isHolding = false;
            rb.isKinematic = isHolding;

            if (rb != null)
            {
                
                Ray cameraRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width /2 , Screen.height /2 ));
                RaycastHit hit;

                // 마우스 클릭 위치를 찾기 위한 레이캐스트
                if (Physics.Raycast(cameraRay, out hit))
                {
                    // 클릭 방향으로 힘을 가함
                    Vector3 throwDirection = (hit.point - handTransform.position).normalized;
                    rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
                }
            }

            // 현재 곡괭이 참조를 null로 설정

            currentPickaxe = null;
            StartCoroutine(RespawnPickaxe(respawnTime));

        }

    }

    private IEnumerator RespawnPickaxe(float delay)
    {
        yield return new WaitForSeconds(delay); // 5초 대기
        SpawnPickaxe(); // 곡괭이 재생성
        
    }
    private void SpawnPickaxe()
    {
        if (currentPickaxe != null)
        {
            Destroy(currentPickaxe); // 기존 곡괭이 파괴
        }

        Debug.Log("곡괭이 생성");
        currentPickaxe = Instantiate(pickaxePrefab, handTransform.position, handTransform.rotation);
        rb = currentPickaxe.GetComponent<Rigidbody>();
        isHolding = true;
        rb.isKinematic = isHolding;
        currentPickaxe.transform.SetParent(handTransform); // 손에 붙이기
        
    }
}

