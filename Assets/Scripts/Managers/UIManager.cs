using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class UIManager : MonoBehaviour {

    public static UIManager instance;

    ObjectManager objectManager;
    SaveManager saveManager;
    SelectDifficulty selectDifficulty;

    List<Canvas> activeUITree = new List<Canvas>();

    [SerializeField] private Canvas SlotSelectMenuPrefab;
    [SerializeField] private Canvas DifficultySelectMenuPrefab;
    [SerializeField] private Canvas GenderSelectMenuPrefab;
    [SerializeField] private Canvas SettingsMenuPrefab;
    [SerializeField] private Canvas ExtrasMenuPrefab;
    [SerializeField] private Canvas EscMenuPrefab;

    private Text difficultyDescriptionText;
    private Image difficultyImage;
    private Canvas _slotSelectMenu;
    private Canvas _difficultySelectMenu;
    private Canvas _genderSelectMenu;
    private Canvas _settingsMenu;
    private Canvas _extrasMenu;
    private Canvas _escMenu;

    public Sprite easyBG;
    public Sprite mediBG;
    public Sprite hardBG;
    public Sprite defaultBG;

    public int layerCount;
    public int internalLayerCount;

    public bool isPlayingAnAnimation;

    string saveFilePath;

    public List<string> saveFileText;

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
    
    public Canvas GenderSelectMenu
    {
        get { return _genderSelectMenu; }
        private set { _genderSelectMenu = value; }
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
        else
        {
            Destroy(this);
        }

        SlotSelectMenu = Instantiate(SlotSelectMenuPrefab, transform);
        DifficultySelectMenu = Instantiate(DifficultySelectMenuPrefab, transform);
        GenderSelectMenu = Instantiate(GenderSelectMenuPrefab, transform);
        SettingsMenu = Instantiate(SettingsMenuPrefab, transform);
        ExtrasMenu = Instantiate(ExtrasMenuPrefab, transform);
        EscMenu = Instantiate(EscMenuPrefab, transform);

        SlotSelectMenu.enabled          = false;
        DifficultySelectMenu.enabled    = false;
        GenderSelectMenu.enabled        = false;
        SettingsMenu.enabled            = false;
        ExtrasMenu.enabled              = false;
        EscMenu.enabled                 = false;
    }

    private void Start()
    {
        saveManager         = SaveManager.instance;
        selectDifficulty    = SelectDifficulty.instance;
        objectManager       = ObjectManager.instance;
        objectManager.UIManager = this;
        layerCount = 0;
        internalLayerCount  = 0;
        isPlayingAnAnimation = false;
    }

    private void OnEnable() { 
        InputManager.EscDown += EscToggle;
    }

    private void OnDisable() {
        InputManager.EscDown -= EscToggle;
    }

    public void MakeSlotSelectMenu() {                                                        // Wszystkie te Make____Menu wydają mi się straszliwie nieprofesjonalne, a po dodaniu Object Managera przestały jeszcze działać. Czy jest jakaś forma usprawnienia tego, czy walczyć z tym aż to ruszy?
        Canvas toMake = instance.SlotSelectMenu;                                                                                          // Wiesz, całe to [SerializedField], obsługa tego, te get/set i teraz to sprawiają, że ten manager zaczyna się mocno rozrastać, a jakby nie patrzeć to tylko 5 okienek póki co.
        MakeUI(toMake);
    }

    public void MakeDifficultySelectMenu()
    {
        Canvas toMake = instance.DifficultySelectMenu;
        MakeUI(toMake);
    }
    public void MakeGenderSelectMenu() { 
        Canvas toMake = instance.GenderSelectMenu;
        MakeUI(toMake);
    }

    public void MakeSettingsMenu() { 
        Canvas toMake = instance.SettingsMenu;
        MakeUI(toMake);
    }

    public void MakeExtrasMenu() {
        Canvas toMake = instance.ExtrasMenu;
        MakeUI(toMake);
    }

    public void MakeEscMenu()
    {
        Canvas toMake = instance.EscMenu;
        MakeUI(toMake);
    }

    public void MakeUI(Canvas toMake) {
        if (toMake.enabled == false)
        {
            toMake.enabled = true;
            instance.activeUITree.Add(toMake);
        }
    }

    public void UnMakeUI() {                                                          //unloading UI this way should alllow using the MakeNewUI method without forever stacking canvases
        
    }

    public void RemoveUI(Canvas toRemove) {
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
                    difficultyDescriptionText.text = "";
                    break;
            }
        }



        if(DifficultyImage.instance != null)
        {
            difficultyImage = DifficultyImage.instance.gameObject.GetComponent<Image>();
            switch (i)
            {
                case 0:
                    difficultyImage.sprite = easyBG;
                    break;

                case 1:
                    difficultyImage.sprite = mediBG;
                    break;

                case 2:
                    difficultyImage.sprite = hardBG;
                    break;

                default:
                    difficultyImage.sprite = defaultBG;
                    break;
            }
        }
    }

    public void StartNewGame(int gameSlot)
    {
        Debug.Log(gameSlot);
        saveManager = SaveManager.instance;
        saveManager.Save(gameSlot);
    }

    public void EscToggle() {
        if (!isPlayingAnAnimation)
        {
            if (internalLayerCount == 0)
            {
                if (activeUITree.Count == 0)
                {
                    MakeEscMenu();
                }
                else if (layerCount == 0)
                {
                    RemoveUI(activeUITree[activeUITree.Count - 1]);
                }
            }
            else
            {
                internalLayerCount--;
            }
        }
    }

   /* public void Update()
    {
        Debug.Log("LayerCount " + internalLayerCount);
    }*/
}