using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bump : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("콜라이더충돌");
        if (collider.TryGetComponent<MovingPlatform>(out MovingPlatform movingPlatform))
        {
           
            movingPlatform.ReversVec();
        }

    }

   
}
