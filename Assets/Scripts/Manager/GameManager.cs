using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public DayCycle dayCycle;
    public static GameManager Instance { get { return instance; } }

   


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

    }

    private void Start()
    {
        dayCycle = GetComponent<DayCycle>();
    }


}
