using System;
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
    public Action startNight;
    public Action endNight;


    private void Awake()
    {
     
        isNight = false;
    }

    void Update()
    {
        
        currentTime += Time.deltaTime;
        rotationAngle = (currentTime / dayLength) * 360f;

        if (rotationAngle >= 360f)
        {
             
            currentTime = 0; 
        }


        sun.transform.rotation = Quaternion.Euler(rotationAngle, 0, 0);

        isNightTime();
    }

    void isNightTime()
    {
        bool wasNight = isNight; 

        isNight = rotationAngle > 180f; 

        
        if (!isNight && wasNight) 
        {
            Debug.Log("�¾��");
            SunRise();
        }
        else if (isNight && !wasNight) 
        {
            Debug.Log("�¾�ȶ�");
            SunSet();
        }
    }

    void SunRise()
    {
        startNight?.Invoke();
    }

    void SunSet()
    {
        endNight?.Invoke();
    }
}




