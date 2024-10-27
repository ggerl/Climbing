using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerCondition playerCondition;
    public InteractableDataSO InteractableDataSO;
    public PlayerController playerController;


    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        playerController = GetComponent<PlayerController>(); 
        playerCondition = GetComponent<PlayerCondition>();  

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
