
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAnimController : MonoBehaviour 
{

    public Animator animator;
    public Rigidbody rb;
    


    private void Update()
    {
        SetPlayerAnim();
        Debug.Log("현재 속도값" + rb.velocity.magnitude);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();  
        rb = GetComponent<Rigidbody>();
    }

    private void SetPlayerAnim()
    {
        animator.SetBool("Run", rb.velocity.magnitude > 0.3);
    }

}
