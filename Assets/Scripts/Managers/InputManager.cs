using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void InputGiven();
    public static event InputGiven EscDown;                                 // Czy w przypadku dużej ilości inputów ten manager nie będzie zbyt bulky? Z nullcheckiem dla każdego eventu z osobna?

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (EscDown != null)
            {
                EscDown();
            }
        }
    }
}