using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCondition : MonoBehaviour
{
    public Condition health;
    public Condition frozen;

    void Start()
    {
        CharacterManager.Instance.player.playerCondition.uiCondition = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
