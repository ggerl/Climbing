using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInterractable
{
    public string GetInteractTooltipName(); 
    public string GetInteractTooltipDescription();  
}

public class Object : MonoBehaviour, IInterractable
{

    public InteractableDataSO interactableDataSO;
    public string GetInteractTooltipName()
    {

        return interactableDataSO.Objectname;
    }
    
    public string GetInteractTooltipDescription()
    {
        return interactableDataSO.Description;
    }
}
