using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bump : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("�ݶ��̴��浹");
        if (collider.TryGetComponent<MovingPlatform>(out MovingPlatform movingPlatform))
        {
           
            movingPlatform.ReversVec();
        }

    }

   
}
