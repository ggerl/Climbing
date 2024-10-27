using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UiCondition uiCondition;
    public PlayerCondition playerCondition;
    public InteractableDataSO InteractableDataSO;
    public PlayerController playerController;


    private void Start()
    {
        CharacterManager.Instance.Player = this;
        playerController = GetComponent<PlayerController>(); 

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
