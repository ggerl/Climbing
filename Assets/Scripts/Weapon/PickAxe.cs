using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PickAxe : MonoBehaviour
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
