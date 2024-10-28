using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Potion : Object
{
    
    public float maxTime;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            switch (interactableDataSO.objectType)
            {
                case ObjectType.HealingPotion:
                    CharacterManager.Instance.Player.playerCondition.Heal(interactableDataSO.itemValue,interactableDataSO.objectType);
                    Destroy(gameObject);
                    break;

                case ObjectType.WarmPotion:
                    CharacterManager.Instance.Player.playerCondition.Heal(interactableDataSO.itemValue, interactableDataSO.objectType);
                    Destroy(gameObject);
                    break;

                case ObjectType.SpeedPotion:
                    CharacterManager.Instance.Player.playerController.SpeedChangeCoroutine(interactableDataSO.itemValue, maxTime);   
                    Destroy(gameObject);
                    break;

            }
                
        }
    }

   





}