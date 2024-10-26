using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{

    public TextMeshProUGUI tooltipUiName;
    public TextMeshProUGUI tooltipUiDescription;
    public LayerMask layermask;
    public GameObject ToolTipUi;
    public float maxInteractionDistance;

    private GameObject currentInteractObject;
    private IInterractable currentInteractable;
    private Camera cam;

    private float lastCheckTime;
    public float checkRate;


    private void Start()
    {
        cam = Camera.main;

    }
    private void Update()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;


            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxInteractionDistance, layermask))
            {
                if (hit.collider.gameObject != currentInteractObject)
                {
                    currentInteractObject = hit.collider.gameObject;
                    currentInteractable = hit.collider.GetComponent<IInterractable>();
                    SetTooltip();
                    Debug.DrawRay(ray.origin, ray.direction * maxInteractionDistance, Color.red);
                }
             
            }
            else
            {
                currentInteractObject = null;
                currentInteractable = null;
                ToolTipUi.SetActive(false);
                
                
            }
        }
    }


    private void SetTooltip()
    {
        ToolTipUi.SetActive(true);
        

        tooltipUiDescription.text = currentInteractable.GetInteractTooltipDescription();
        tooltipUiName.text = currentInteractable.GetInteractTooltipName();


    }

}
