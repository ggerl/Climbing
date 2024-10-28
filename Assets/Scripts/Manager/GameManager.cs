using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
  
    public static GameManager Instance { get { return instance; } }

    public DayCycle dayCycle;

   

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            dayCycle = GetComponent<DayCycle>();
            DontDestroyOnLoad(gameObject);   
        }
        else
        {
            if (instance != null)
                Destroy(gameObject);
        }
    }

  

}
