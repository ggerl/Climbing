using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiCondition : MonoBehaviour
{
    public Condition health;
    public Condition frozen;
    public Condition temp;

    void Start()
    {
       if(CharacterManager.Instance.Player.playerCondition == null)
        {
            Debug.Log("ĳ���� ����� ��");
        }
        CharacterManager.Instance.Player.playerCondition.uiCondition = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
