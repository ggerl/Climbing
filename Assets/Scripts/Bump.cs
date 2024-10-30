using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bump : MonoBehaviour
{
    private MovingPlatform platform;


    private void Awake()
    {
        platform = GetComponentInParent<MovingPlatform>();  

    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Ground"))
        {
            platform.ReversVec();
        }


    
    }

  


}
