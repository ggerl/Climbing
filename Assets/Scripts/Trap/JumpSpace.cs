using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpSpace : Trap
{
    private Rigidbody playerRb;
    public float jumpForce;
    private void OnCollisionEnter(Collision collision)
    {
        OnCollide(collision);
    }

    protected override void OnCollide(Collision collision)
    {

        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

        if (playerController != null)
        {
            
            playerController.AddPlayerForce(Vector3.up, jumpForce);

        }
    }
}
