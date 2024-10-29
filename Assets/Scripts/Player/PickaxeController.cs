using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeController : MonoBehaviour // TODO : �����丵 ����
{
    public GameObject pickaxePrefab;
    public Transform handTransform;
    public Animator animator;
    public float throwForce = 10f;

    public float respawnTime;
    public Rigidbody rb;
    private GameObject currentPickaxe;
    public Action<Vector3, float> throwPa;
    Vector3 throwDirection;
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
            throwDirection = CharacterManager.Instance.Player.playerController.currentCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10f)) - handTransform.position;
            throwDirection.Normalize();
            currentPickaxe.transform.SetParent(null);
            throwPa?.Invoke(throwDirection, throwForce);
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
        currentPickaxe = Instantiate(pickaxePrefab, handTransform.position, handTransform.rotation);
        currentPickaxe.transform.SetParent(handTransform); // �տ� ���̱�

    }
}

