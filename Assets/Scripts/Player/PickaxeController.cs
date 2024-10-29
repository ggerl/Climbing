using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeController : MonoBehaviour
{
    public GameObject pickaxePrefab; 
    public Transform handTransform; 
    public Animator animator; 
    public string throwAnimationName = "Throw"; 
    public float throwForce = 10f; 

    public float respawnTime;
    public Rigidbody rb;
    private GameObject currentPickaxe; 
    private bool isHolding;
    void Start()
    {
        animator = GetComponent<Animator>();
        handTransform = animator.GetBoneTransform(HumanBodyBones.RightHand);
        // °î±ªÀÌ »ý¼º
        SpawnPickaxe();
        CharacterManager.Instance.Player.playerInputController.pickaxeThrow += ThrowPickaxe;

    }




    private void ThrowPickaxe()
    {
        if (currentPickaxe != null)
        {
            isHolding = false;

            if (rb != null)
            {
                Vector3 throwDirection = CharacterManager.Instance.Player.playerController.currentCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 10f)) - handTransform.position;

                throwDirection.Normalize();
                rb.isKinematic = isHolding;
                rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
                Debug.Log("¼Ó·Â: " + rb.velocity.magnitude);
                currentPickaxe.transform.SetParent(null);



            }


            // ÇöÀç °î±ªÀÌ ÂüÁ¶¸¦ null·Î ¼³Á¤

            currentPickaxe = null;
            StartCoroutine(RespawnPickaxe(respawnTime));

        }

    }

    private IEnumerator RespawnPickaxe(float delay)
    {
        yield return new WaitForSeconds(delay); // 5ÃÊ ´ë±â
        SpawnPickaxe(); // °î±ªÀÌ Àç»ý¼º
        
    }
    private void SpawnPickaxe()
    {
        if (currentPickaxe != null) return;

        Debug.Log("°î±ªÀÌ »ý¼º");
        currentPickaxe = Instantiate(pickaxePrefab, handTransform.position, handTransform.rotation );
        rb = currentPickaxe.GetComponent<Rigidbody>();
        isHolding = true;
        rb.isKinematic = isHolding;
        currentPickaxe.transform.SetParent(handTransform); // ¼Õ¿¡ ºÙÀÌ±â
        
    }
}

