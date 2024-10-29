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
    private Rigidbody rb;
    private float lastCheckTime;
    public float tempReduceCoolDown;
    private bool tempZero;
    
    Condition health { get { return uiCondition.health; } }
    Condition frozen { get { return uiCondition.frozen; } }
    Condition temp { get { return uiCondition.temp; } }

    public float noFrozenHealthDecay;
    public event Action onTakeDamage;
    public float frozenAmount = 3f; // 밤에 감소할 값
    public float frozenTempReduceAmount;
    public float frozenTempAddAmount;
    private void Start()
    {
        rb= GetComponent<Rigidbody>();
        tempZero = false;
    }

    void Update()
    {
        TempControl();
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

        if (GameManager.Instance.dayCycle.isNight && tempZero)
        {
            
            frozen.Subtract(frozenAmount);
        }
       
    }

    private void TempControl()
    {

     if(GameManager.Instance.dayCycle.isNight && rb.velocity.magnitude < 0.3f)
        {
            temp.Subtract(frozenTempReduceAmount);
        }
     else
        {
            temp.Add(frozenTempAddAmount);
        }



        tempZero = temp.curValue <= 0f;
    }


}

