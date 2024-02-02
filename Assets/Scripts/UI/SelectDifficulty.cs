using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDifficulty : MonoBehaviour
{
    public static SelectDifficulty instance;

    [SerializeField] private GameObject genderGroup;
    [SerializeField] private GameObject genderButtons;
    [SerializeField] private GameObject mediumGroup;
    [SerializeField] private GameObject hardGroup;
    [SerializeField] private GameObject difficultyButtons;
    [SerializeField] private GameObject descriptionTextBox;

    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject startButton;

    public GameObject maleFish;
    public GameObject femaleFish;

    public Text descriptionBoxText;

    InputManager inputManager;
    UIManager uiManager;
    GameManager gameManager;
    SaveManager saveManager;

    private int layerCount;
    private string text;

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
    }

    void Start()
    {
        gameManager = GameManager.instance;
        uiManager = UIManager.instance;
        saveManager = SaveManager.instance;
        ShowDifficulty();
        layerCount = 0;
        text = descriptionBoxText.text;
    }

    private void Update()
    {
        if (layerCount > 0)
        {
            if (!uiManager.isPlayingAnAnimation)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    ShowDifficulty();
                }
            }
        }
    }


    #region genderMethods
    public void ShowMale()
    {
        femaleFish.SetActive(false);
        maleFish.SetActive(true);
        descriptionTextBox.SetActive(true);
        startButton.SetActive(true);
        SetGenderInSlot(1);
        descriptionBoxText.text = "Male fish placeholder";
    }
    
    public void ShowFemale()
    {
        femaleFish.SetActive(true);
        maleFish.SetActive(false);
        descriptionTextBox.SetActive(true);
        startButton.SetActive(true);
        SetGenderInSlot(2);
        descriptionBoxText.text = "Female fish placeholder";
    }

    public void ShowBoth()
    {
        femaleFish.SetActive(true);
        maleFish.SetActive(true);
        descriptionTextBox.SetActive(true);
        startButton.SetActive(true);
        SetGenderInSlot(3);
        descriptionBoxText.text = "Both genders placeholder";
    }
    #endregion

    #region difficultyMethods
    void Easy()
    {
        gameManager.difficulty = 1;
        SetDifficultyInSlot(1);
        mediumGroup.SetActive(false);
        hardGroup.SetActive(false);
        descriptionTextBox.SetActive(true);
        nextButton.SetActive(true);
        descriptionBoxText.text = "Easy difficulty placeholder";
    }

    void Medium()
    {
        gameManager.difficulty = 2;
        SetDifficultyInSlot(2);
        mediumGroup.SetActive(true);
        hardGroup.SetActive(false);
        descriptionTextBox.SetActive(true);
        nextButton.SetActive(true);
        descriptionBoxText.text = "Medium difficulty placeholder";
    }

    void Hard()
    {
        gameManager.difficulty = 3;
        SetDifficultyInSlot(3);
        mediumGroup.SetActive(false);
        hardGroup.SetActive(true);
        descriptionTextBox.SetActive(true);
        nextButton.SetActive(true);
        descriptionBoxText.text = "Hard difficulty placeholder";
    }
    #endregion

    public void ShowDifficulty()
    {
        genderGroup.SetActive(false);
        genderButtons.SetActive(false);
        difficultyButtons.SetActive(true);
        if (uiManager.internalLayerCount > 0)
        {
            uiManager.internalLayerCount--;
            descriptionTextBox.SetActive(true);
        }
        else
        {
            descriptionTextBox.SetActive(false);
        }
    }

    public void ShowGender()
    {
        genderGroup.SetActive(true);
        genderButtons.SetActive(true);
        difficultyButtons.SetActive(false);
        descriptionTextBox.SetActive(false);
        uiManager.internalLayerCount++;
        layerCount++;
    }

    public void StartGame()                                                                                                 //to edit, possibly remake from scratch afterwards
    {
        //Debug.Log("Selected Slot is: " + saveManager.selectedSlot);
        saveManager.Save(saveManager.selectedSlot);
    }

    public void SetDifficultyInSlot(int difficulty)
    {
        if (saveManager.saveFileText.Count > 0)
        {
            saveManager.RemoveFromIndex(0);
        }
        saveManager.AddAtIndex(0, difficulty.ToString());
    }

    public void SetGenderInSlot(int gender)
    {
        if (saveManager.saveFileText.Count > 1)
        {
            saveManager.RemoveFromIndex(1);
        }
        saveManager.AddAtIndex(1, gender.ToString());
    }

    public void ClickDifficulty(int i)
    {
        switch (i)
        {
            case 1:
                Easy();
                break;
            case 2:
                Medium();
                break;
            case 3:
                Hard();
                break;
        }
    }
}