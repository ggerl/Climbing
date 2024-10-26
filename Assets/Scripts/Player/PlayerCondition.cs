using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IDamageable
{
    void TakePhysicalDamage(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamageable
{
    public UiCondition uiCondition;


    Condition health { get { return uiCondition.health; } }
    Condition frozen { get { return uiCondition.frozen; } }

    public float noHungerHealthDecay;
    public event Action onTakeDamage;

    void Update()
    {
    
    }
    public void Heal(float amount)
    {
        health.Add(amount);

    }


    public void Die()
    {
        Debug.Log("사망");
    }

    public void TakePhysicalDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }


}

