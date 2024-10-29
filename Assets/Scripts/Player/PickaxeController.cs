using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeController : MonoBehaviour
{
    public GameObject pickaxePrefab; // 곡괭이 프리펩
    public Transform handTransform; // 손의 Transform
    public Animator animator; // 플레이어의 애니메이터
    public string throwAnimationName = "Throw"; // 던지기 애니메이션
    public float throwForce = 10f; // 던질 힘

    public float respawnTime;
    public Rigidbody rb;
    private GameObject currentPickaxe; // 현재 손에 있는 곡괭이
    private bool isHolding;
    void Start()
    {
        animator = GetComponent<Animator>();
        handTransform = animator.GetBoneTransform(HumanBodyBones.RightHand);
        // 곡괭이 생성
        SpawnPickaxe();
        CharacterManager.Instance.Player.playerInputController.pickaxeThrow += ThrowPickaxe;

    }




    private void ThrowPickaxe()
    {
        if (currentPickaxe != null)
        {
            isHolding = false;

            if (rb != null)
            {
                Vector3 throwDirection = CharacterManager.Instance.Player.playerController.currentCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10f)) - handTransform.position;

                throwDirection.Normalize();
                rb.isKinematic = isHolding;
                rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
                Debug.Log("속력: " + rb.velocity.magnitude);
                currentPickaxe.transform.SetParent(null);



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
        if (currentPickaxe != null) return;

        Debug.Log("곡괭이 생성");
        currentPickaxe = Instantiate(pickaxePrefab, handTransform.position, handTransform.rotation );
        rb = currentPickaxe.GetComponent<Rigidbody>();
        isHolding = true;
        rb.isKinematic = isHolding;
        currentPickaxe.transform.SetParent(handTransform); // 손에 붙이기
        
    }
}

