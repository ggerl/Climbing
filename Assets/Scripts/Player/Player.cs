using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UiCondition uiCondition;
    public PlayerCondition playerCondition;
    public InteractableDataSO InteractableDataSO;


    private void Awake()
    {
        CharacterManager.Instance.Player = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
