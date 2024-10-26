using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSpace : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpMagnitude;
    private void OnCollisionEnter(Collision collision)
    {
        playerRb = collision.rigidbody;

        if(playerRb != null)
        {
            playerRb.AddForce(Vector3.up * jumpMagnitude, ForceMode.Impulse);
        }
    }
}
