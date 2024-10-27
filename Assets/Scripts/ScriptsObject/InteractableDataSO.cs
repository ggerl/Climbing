using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObjectType
{
    Rock,
    HealingPotion,
    WarmPotion

}

[CreateAssetMenu(fileName = "Interactable")]
public class InteractableDataSO : ScriptableObject 
{
    public string Objectname;
    public string Description;
    public ObjectType objectType;
    public float itemValue;
}
