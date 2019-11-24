﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Canvas escMenu;

    bool isGamePaused = false;

	void Start () {
		
	}
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (isGamePaused)
            {
                UIPanel activeUIPanel = UIPanel.instance;
                activeUIPanel.DestroyPanel();
                if(UIPanel.UILevel == 0)
                {
                    isGamePaused = false;
                }
            }
            else
            {
                Instantiate(escMenu);
                isGamePaused = true;
            }
        }
	}
}
