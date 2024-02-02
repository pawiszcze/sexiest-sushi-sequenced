using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : Jump
{

    private void OnEnable()
    {
        InputManager.SpaceDown += PerformJump;
        //InputManager.KeyADown += PerformJump;
    }
}
