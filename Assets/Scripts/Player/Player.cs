using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public UiCondition uiCondition;
    public PlayerCondition playerCondition;
    private void Awake()
    {
        CharacterManager.Instance.player = this;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
