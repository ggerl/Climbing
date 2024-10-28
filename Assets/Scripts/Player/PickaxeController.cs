using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeController : MonoBehaviour
{
    public GameObject pickaxePrefab; // ��� ������
    public Transform handTransform; // ���� Transform
    public Animator animator; // �÷��̾��� �ִϸ�����
    public string throwAnimationName = "Throw"; // ������ �ִϸ��̼� �̸�
    public float throwForce = 10f; // ���� ��

    public float respawnTime;
    public Rigidbody rb;
    private GameObject currentPickaxe; // ���� �տ� �ִ� ���
    private bool isHolding = true;
    void Start()
    {
        animator = GetComponent<Animator>();
        handTransform = animator.GetBoneTransform(HumanBodyBones.RightHand);
        // ��� ����
        SpawnPickaxe();


    }

    void Update()
    {
        // Ư�� Ű�� ������ �� �ִϸ��̼� ���
        if (Input.GetKey(KeyCode.R)) // ��: RŰ�� ������ ��
        {
            animator.SetBool(throwAnimationName, true); // �ִϸ��̼� ���
        }
        else
        {
            animator.SetBool(throwAnimationName, false); // �ִϸ��̼� ����
        }

        // ������ ��ư�� ������ ��
        if (Input.GetMouseButtonDown(0)) // ���콺 ���� ��ư Ŭ��
        {
            ThrowPickaxe();
        }
    }

    private void ThrowPickaxe()
    {
        if (currentPickaxe != null)
        {
            // ��̸� �տ��� �и�
            currentPickaxe.transform.SetParent(null);
            isHolding = false;
            rb.isKinematic = isHolding;

            if (rb != null)
            {
                
                Ray cameraRay = Camera.main.ScreenPointToRay(new Vector3(Screen.width /2 , Screen.height /2 ));
                RaycastHit hit;

                // ���콺 Ŭ�� ��ġ�� ã�� ���� ����ĳ��Ʈ
                if (Physics.Raycast(cameraRay, out hit))
                {
                    // Ŭ�� �������� ���� ����
                    Vector3 throwDirection = (hit.point - handTransform.position).normalized;
                    rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
                }
            }

            // ���� ��� ������ null�� ����

            currentPickaxe = null;
            StartCoroutine(RespawnPickaxe(respawnTime));

        }

    }

    private IEnumerator RespawnPickaxe(float delay)
    {
        yield return new WaitForSeconds(delay); // 5�� ���
        SpawnPickaxe(); // ��� �����
        
    }
    private void SpawnPickaxe()
    {
        if (currentPickaxe != null)
        {
            Destroy(currentPickaxe); // ���� ��� �ı�
        }

        Debug.Log("��� ����");
        currentPickaxe = Instantiate(pickaxePrefab, handTransform.position, handTransform.rotation);
        rb = currentPickaxe.GetComponent<Rigidbody>();
        isHolding = true;
        rb.isKinematic = isHolding;
        currentPickaxe.transform.SetParent(handTransform); // �տ� ���̱�
        
    }
}

