using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    //public DifficultyBoxScript difficultyDescription;

    List<Canvas> activeUITree = new List<Canvas>();

    [SerializeField] private Canvas SlotSelectMenuPrefab;
    [SerializeField] private Canvas DifficultySelectMenuPrefab;
    [SerializeField] private Canvas SettingsMenuPrefab;
    [SerializeField] private Canvas ExtrasMenuPrefab;
    [SerializeField] private Canvas EscMenuPrefab;

    private Text difficultyDescriptionText;
    private Canvas _slotSelectMenu;
    private Canvas _difficultySelectMenu;
    private Canvas _settingsMenu;
    private Canvas _extrasMenu;
    private Canvas _escMenu;

    public Canvas SlotSelectMenu
    {
        get { return _slotSelectMenu; }
        private set { _slotSelectMenu = value; }
    }

    public Canvas DifficultySelectMenu
    {
        get { return _difficultySelectMenu;  }
        private set { _difficultySelectMenu = value; }
    }

    public Canvas ExtrasMenu
    {
        get { return _extrasMenu; }
        private set { _extrasMenu = value; }
    }

    public Canvas SettingsMenu {
        get         { return _settingsMenu;  }
        private set { _settingsMenu = value; }
    }

    public Canvas EscMenu
    {
        get { return _escMenu; }
        private set { _escMenu = value; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        SlotSelectMenu = Instantiate(SlotSelectMenuPrefab, transform);
        DifficultySelectMenu = Instantiate(DifficultySelectMenuPrefab, transform);
        SettingsMenu = Instantiate(SettingsMenuPrefab, transform);
        ExtrasMenu = Instantiate(SettingsMenuPrefab, transform);
        EscMenu = Instantiate(EscMenuPrefab, transform);

        SlotSelectMenu.enabled = false;
        DifficultySelectMenu.enabled = false;
        SettingsMenu.enabled = false;
        ExtrasMenu.enabled = false;
        EscMenu.enabled = false;
    }

    public void MakeSlotSelectMenu()
    {
        Canvas toMake = instance.SlotSelectMenu;
        MakeUI(toMake);
    }

    public void MakeDifficultySelectMenu()
    {
        Canvas toMake = instance.DifficultySelectMenu;
        MakeUI(toMake);
    }

    public void MakeSettingsMenu()
    {
        Canvas toMake = instance.SettingsMenu;
        MakeUI(toMake);
    }

    public void MakeExtrasMenu()
    {
        Canvas toMake = instance.ExtrasMenu;
        MakeUI(toMake);
    }

    public void MakeEscMenu()
    {
        Canvas toMake = instance.EscMenu;
        MakeUI(toMake);
    }

    public void MakeUI(Canvas toMake)
    {
        if (toMake.enabled == false)
        {
            toMake.enabled = true;
            instance.activeUITree.Add(toMake);
        }
    }

    public void RemoveUI(Canvas toRemove)
    {
        toRemove.enabled = false;
        instance.activeUITree.Remove(toRemove);
    }

    public void ChangeDifficultyDescription(int i)
    {
        if (DifficultyDescriptionBoxScript.instance != null)
        {
            difficultyDescriptionText = DifficultyDescriptionBoxScript.instance.gameObject.GetComponent<Text>();
            switch (i)
            {
                case 0:
                    difficultyDescriptionText.text = "> Enemy health reduced \n> Samurai health increased \n> Neutral characters will never attack player \n> Boss enemies will telegraph attacks sooner \n> Collectible radar can be turned on from the start";
                    break;

                case 1:
                    difficultyDescriptionText.text = "> Enemy and Samurai health remain at default levels \n> Neutral characters will attack player if they take damage \n> Boss enemies will telegraph attacks briefly before executing them \n> Collectible radar can be turned on after Stage 5";
                    break;

                case 2:
                    difficultyDescriptionText.text = "> Enemy health increased \n> Samurai health decreased \n> No such thing as neutral characters \n> Boss enemies will telegraph attacks just before attacking \n> Collectible radar unavailable \n> You crazy bastard";
                    break;

                default:
                    break;
            }
        }
    }

    public void StartNewGame(int gameSlot)
    {
        System.IO.File.WriteAllText("C:/Users/pawel/Desktop/SaveSlot" + gameSlot + ".txt", "Game Started1");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(activeUITree.Count==0)
            {
                MakeEscMenu();               
            } else
            {
                RemoveUI(activeUITree[activeUITree.Count - 1]);
            }
        }
    }
}