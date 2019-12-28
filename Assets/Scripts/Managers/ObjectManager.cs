﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public static ObjectManager instance;

    public UIManager UIManager;                                            // Czy w skrócie tak ma wyglądać działanie Object Managera?
    public InputManager InputManager;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        } else
        {
            Destroy(this);
        }        
    }                                               // Null Check - poprawny?
}
