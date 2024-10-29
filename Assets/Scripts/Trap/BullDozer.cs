

using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class BullDozer : Trap, HaveLaser
{
   
    public float laserRange;
    public Transform firePoint;
    public Vector3 boxSize;
    private Rigidbody rb;
    public float dashForce;
    public float pushForce;
    
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        ShootLaser();
    }
    protected override void OnCollide(Collision collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

        if (playerController != null) 
        {

            playerController.PlayerPushToggleCoroutine();
            playerController.AddPlayerForce(rb.velocity.normalized,pushForce);
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnCollide(collision);

    }
 
    public void ShootLaser()
    {
        RaycastHit hit;      
        if (Physics.BoxCast(firePoint.position, boxSize, firePoint.forward, out hit, Quaternion.identity, laserRange))
        {
            rb.AddForce(Vector3.left * dashForce, ForceMode.Impulse);
        }

    }

   
}

