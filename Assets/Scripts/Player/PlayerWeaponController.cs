using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject weaponPrefab;
    public Transform rightHand;
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rightHand = animator.GetBoneTransform(HumanBodyBones.RightHand);
        Debug.Log(rightHand);
        EquipWeapon();
    }
    void EquipWeapon()
    {
        GameObject weapon = Instantiate(weaponPrefab, rightHand.position, rightHand.rotation);
        weapon.transform.SetParent(rightHand); // ������ �� ���� ���⸦ �ڽ����� ����
        weapon.transform.localPosition = new Vector3(0,0.2f,0.03f); // ���� ��ġ ����
        weapon.transform.localRotation = Quaternion.identity; // ���� ȸ�� ����
    }
}
