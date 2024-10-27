using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public GameObject sun; 
    public float dayLength = 60f; // �Ϸ� ���� (�� ����)
    

    public bool isNight;
    private float currentTime;
    float rotationAngle;

    

    private void Awake()
    {
     
        isNight = false;
    }

    void Update()
    {
        // �Ϸ� ���̿� ���� �ð� ������Ʈ
        currentTime += Time.deltaTime;
        rotationAngle = (currentTime / dayLength) * 360f;

        // �¾� ȸ��
        sun.transform.rotation = Quaternion.Euler(rotationAngle, 0, 0);

        isNightTime();
    }

    void isNightTime()
    {
        isNight = rotationAngle > 180f;
        if(isNight == true)
        {
            Debug.Log("������ ���Դϴ�");
        }

        Debug.Log("������ ���Դϴ�");
    }
    

}


