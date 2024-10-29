using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface HaveLaser
{

    public void ShootLaser();

}

public abstract class Trap : MonoBehaviour
{
    public LayerMask LayerMask;
    protected abstract void OnCollide(Collision collision);
   

}

