using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public delegate void InputGiven();
    public static event InputGiven EscDown;
    public static event InputGiven KeyWDown;
    public static event InputGiven KeyADown;
    public static event InputGiven KeyDDown;
    public static event InputGiven SpaceDown;

    public static event InputGiven ArrowLeftDown;
    public static event InputGiven ArrowRightDown;

    public static event InputGiven EscUp;
    public static event InputGiven KeyWUp;
    public static event InputGiven KeyAUp;
    public static event InputGiven KeyDUp;
    public static event InputGiven SpaceUp;
    //public static event InputGiven EitherMouseButtonDown;                   // Czy w przypadku dużej ilości inputów ten manager nie będzie zbyt bulky? Z nullcheckiem dla każdego eventu z osobna?

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (EscDown != null)
            {
                EscDown();
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (KeyWDown != null)
            {
                KeyWDown();
            }
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (KeyADown != null)
            {
                KeyADown();
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (KeyDDown != null)
            {
                KeyDDown();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (SpaceDown != null)
            {
                SpaceDown();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (ArrowLeftDown != null)
            {
                ArrowLeftDown();
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (ArrowRightDown != null)
            {
                ArrowRightDown();
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (SpaceUp != null)
            {
                SpaceUp();
            }
        }

        /*if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            if (EitherMouseButtonDown != null)
            {
                EitherMouseButtonDown.Invoke();
            }
        }*/
    }
}