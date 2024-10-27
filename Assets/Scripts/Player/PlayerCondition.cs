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
    public float frozenAmount = 10f; // 밤에 감소할 값


    void Update()
    {

        frozenDecayOnNight();

        if (frozen.curValue <= 0f)
        {
            TakePhysicalDamage(noFrozenHealthDecay * Time.deltaTime);
        }

        if(health.curValue <= 0f)
        {
            Die();
        }
    }
    public void Heal(float amount,ObjectType objectType)
    {
        switch(objectType)
        {
            case ObjectType.HealingPotion:
                health.Add(amount);
                break;
            case ObjectType.WarmPotion:
                frozen.Add(amount);
                break;
        }       
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

    public void frozenDecayOnNight()
    {
        if(GameManager.Instance == null)
        {
            Debug.Log("널이야");
        }


        if (GameManager.Instance.dayCycle.isNight)
        {
            
            frozen.Subtract(frozenAmount);
        }
       
    }
}

