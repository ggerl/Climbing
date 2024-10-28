
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAnimController : MonoBehaviour
{

    public Animator animator;
    public Rigidbody rb;
    private float currentPlayerSpeed;


    private void Update()
    {
        currentPlayerSpeed = rb.velocity.magnitude;
        Debug.Log("현재속도" + currentPlayerSpeed);
        SetPlayerMoveAnim();
        
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void SetPlayerMoveAnim() // ToDo : 리팩토링 Update문 제거
    {

        animator.SetBool("Falling", false);
        if (CharacterManager.Instance.Player.playerController.IsGrounded())
        {
            
           
            animator.SetBool("Run", currentPlayerSpeed > 0.3f);

        }
        else
        {
            animator.SetBool("Falling", currentPlayerSpeed > 0.3f);
        }
             

    }




}



