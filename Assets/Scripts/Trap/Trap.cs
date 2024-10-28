using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PushAble
{
    public void PushCharacter();

}

public abstract class Trap : MonoBehaviour
{

    public abstract void OnCollide();
   

}

