using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMake : MonoBehaviour {

    public Canvas panelToMake;

	public void MakeUI()
    {
        Instantiate(panelToMake);
    }
}
