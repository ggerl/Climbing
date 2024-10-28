using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public GameObject sun; 
    public float dayLength = 60f; // 하루 길이 (초 단위)
    

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
        // 하루 길이에 따라 시간 업데이트
        currentTime += Time.deltaTime;
        rotationAngle = (currentTime / dayLength) * 360f;

        // 태양 회전
        sun.transform.rotation = Quaternion.Euler(rotationAngle, 0, 0);

        isNightTime();
    }

    void isNightTime()
    {
        bool wasNight = isNight; 
        isNight = rotationAngle > 180f; 

        
        if (!isNight && wasNight) 
        {
            Debug.Log("태양뜸");
            SunRise();
        }
        else if (isNight && !wasNight) 
        {
            Debug.Log("태양안뜸");
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




