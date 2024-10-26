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
        weapon.transform.SetParent(rightHand); // 오른쪽 손 뼈에 무기를 자식으로 설정
        weapon.transform.localPosition = new Vector3(0,0.2f,0.03f); // 무기 위치 조정
        weapon.transform.localRotation = Quaternion.identity; // 무기 회전 조정
    }
}
