using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    private static CharacterManager instance;

    public Player player;
    public static CharacterManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
 

    }
}
