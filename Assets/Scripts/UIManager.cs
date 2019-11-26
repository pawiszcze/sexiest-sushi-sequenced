using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    int UIDepth;
    List<Canvas> activeUITree = new List<Canvas>();
    [SerializeField] private Canvas Level1MenuPrefab;
    [SerializeField] private Canvas Level2MenuPrefab;

    public Canvas EscMenu {                                                             //Jestem prawie pewien, że błąd leży gdzieś w tych przypisaniach, C# Properties są dla mnie zupełnie nowe ^^'
        get;
        private set;
    }

    public Canvas SettingsMenu {
        get;
        private set;
    }

    private void Start()
    {
        UIDepth = 0;

        EscMenu = Instantiate(Level1MenuPrefab, transform);
        SettingsMenu = Instantiate(Level2MenuPrefab, transform);

        EscMenu.enabled = false;
        SettingsMenu.enabled = false;
    }

    public void MakeUI (Canvas toMake)
    {
        toMake.enabled = true;
        activeUITree.Add(toMake);
    }

    public void RemoveUI(Canvas toRemove)
    {
        toRemove.enabled = false;
        activeUITree.Remove(toRemove);
    }

    public void DebugCall()
    {
        Debug.Log("Button was clicked");
    }

    private void Update()
    {
        Debug.Log(activeUITree.Count);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(activeUITree.Count==0)
            {
                MakeUI(EscMenu);
            } else
            {
                RemoveUI(activeUITree[activeUITree.Count - 1]);
            }
        }
    }
}
