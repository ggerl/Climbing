using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public interface IDamageable
{
    void TakePhysicalDamage(float damage);
}

public class PlayerCondition : MonoBehaviour, IDamageable
{
    public UiCondition uiCondition;


    Condition health { get { return uiCondition.health; } }
    Condition frozen { get { return uiCondition.frozen; } }

    public float noFrozenHealthDecay;
    public event Action onTakeDamage;

    void Update()
    {
    
        if(frozen.curValue <= 0f)
        {
            TakePhysicalDamage(noFrozenHealthDecay * Time.deltaTime);
        }

        if(health.curValue <= 0f)
        {
            Die();
        }
    }
    public void Heal(float amount)
    {
        health.Add(amount);

    }


    public void Die()
    {
        Debug.Log("사망");
    }

    public void TakePhysicalDamage(float damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }


}

