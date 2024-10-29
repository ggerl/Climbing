using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeController : MonoBehaviour
{
    public GameObject pickaxePrefab; // ��� ������
    public Transform handTransform; // ���� Transform
    public Animator animator; // �÷��̾��� �ִϸ�����
    public string throwAnimationName = "Throw"; // ������ �ִϸ��̼�
    public float throwForce = 10f; // ���� ��

    public float respawnTime;
    public Rigidbody rb;
    private GameObject currentPickaxe; // ���� �տ� �ִ� ���
    private bool isHolding;
    void Start()
    {
        animator = GetComponent<Animator>();
        handTransform = animator.GetBoneTransform(HumanBodyBones.RightHand);
        // ��� ����
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
                Debug.Log("�ӷ�: " + rb.velocity.magnitude);
                currentPickaxe.transform.SetParent(null);



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
        if (currentPickaxe != null) return;

        Debug.Log("��� ����");
        currentPickaxe = Instantiate(pickaxePrefab, handTransform.position, handTransform.rotation );
        rb = currentPickaxe.GetComponent<Rigidbody>();
        isHolding = true;
        rb.isKinematic = isHolding;
        currentPickaxe.transform.SetParent(handTransform); // �տ� ���̱�
        
    }
}

