using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour
{
    public Transform sun; // 태양 Transform
    public float dayLength = 60f; // 하루 길이 (초 단위)
    

    public bool isNight;
    private float currentTime;
    float rotationAngle;

    

    private void Start()
    {
        isNight = false;
    }
    void Update()
    {
        // 하루 길이에 따라 시간 업데이트
        currentTime += Time.deltaTime;
        rotationAngle = (currentTime / dayLength) * 360f;

        // 태양 회전
        sun.rotation = Quaternion.Euler(rotationAngle, 0, 0);

        isNightTime();
    }

    void isNightTime()
    {
        isNight = rotationAngle > 180f;
        if(isNight == true)
        {
            Debug.Log("지금은 밤입니다");
        }

        Debug.Log("지금은 낮입니다");
    }
    

}


