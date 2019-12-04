using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyDescriptionBoxScript : MonoBehaviour
{
    public static DifficultyDescriptionBoxScript instance;

    void Start()
    {
        instance = this;    
    }
}
