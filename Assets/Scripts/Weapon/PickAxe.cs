using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PickAxe : MonoBehaviour // 함정체크용 도구
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        CharacterManager.Instance.Player.pickaxeController.throwPa += Throw;
    }
   
    public void Throw(Vector3 dir, float value)
    {
        rb.isKinematic = false;

        rb.AddForce(dir * value, ForceMode.Impulse);
        
     
    }

}
