using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public Transform sun; // �¾� Transform
    public float dayLength = 60f; // �Ϸ� ���� (�� ����)
    

    public bool isNight;
    private float currentTime;
    float rotationAngle;

    

    private void Start()
    {
        isNight = false;
    }
    void Update()
    {
        // �Ϸ� ���̿� ���� �ð� ������Ʈ
        currentTime += Time.deltaTime;
        rotationAngle = (currentTime / dayLength) * 360f;

        // �¾� ȸ��
        sun.rotation = Quaternion.Euler(rotationAngle, 0, 0);

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


