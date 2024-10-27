﻿using System.Collections;
using UnityEngine;

public class Potion : Object
{
    public InteractableDataSO InteractableDataSO;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            switch (interactableDataSO.objectType)
            {
                case ObjectType.HealingPotion:
                    CharacterManager.Instance.Player.playerCondition.Heal(interactableDataSO.itemValue,interactableDataSO.objectType);
                    break;

                case ObjectType.WarmPotion:
                    CharacterManager.Instance.Player.playerCondition.Heal(interactableDataSO.itemValue, interactableDataSO.objectType);
                    break;


            }
                
        }
    }



}