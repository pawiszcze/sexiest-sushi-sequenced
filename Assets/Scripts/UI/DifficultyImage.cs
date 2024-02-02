using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyImage : MonoBehaviour
{
    public static DifficultyImage instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }
    }
}
