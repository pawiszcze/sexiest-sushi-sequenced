using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanel : MonoBehaviour {

    public static UIPanel instance;
    public static int UILevel;
    public int ID;

    private void Start()
    {
        instance = this;
        UILevel++;
        ID = UILevel;
    }

    private void Update()
    {
        if (ID == UILevel)
        {
            instance = this;
        }
        Debug.Log(instance);
    }

    public void DestroyPanel()
    {
        UILevel--;
        Destroy(gameObject);
    }
    
}
