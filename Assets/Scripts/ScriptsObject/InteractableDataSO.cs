using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ObjectType
{
    Rock
}

[CreateAssetMenu(fileName = "Interactable")]
public class InteractableDataSO : ScriptableObject 
{
    public string Objectname;
    public string Description;

}
