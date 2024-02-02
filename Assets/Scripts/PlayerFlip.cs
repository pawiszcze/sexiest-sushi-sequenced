using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlip : Flip
{
    private void OnEnable()
    {
        InputManager.KeyADown += FlipLeft;
        InputManager.ArrowLeftDown += FlipLeft;
        InputManager.KeyDDown += FlipRight;
        InputManager.ArrowRightDown += FlipRight;
    }
}
