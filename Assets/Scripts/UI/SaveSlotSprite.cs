using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlotSprite : MonoBehaviour
{
    SaveManager saveManager;
    UIManager uiManager;

    [SerializeField] GameObject toRefresh;

    [SerializeField] Sprite defaultIMG;
    [SerializeField] Sprite easyIMG;
    [SerializeField] Sprite mediumIMG;
    [SerializeField] Sprite hardIMG;
    [SerializeField] GameObject child;
    [SerializeField] Texture femmeIMG;
    [SerializeField] Texture bothIMG;
    [SerializeField] Texture mascIMG;
    [SerializeField] bool shouldRefresh;
    [SerializeField] GameObject deleteSaveButton;
    [SerializeField] int slot;

    int slotDifficulty = 0;
    int slotGender = 0;
    bool isSaveFile = false;

    private string saveFilePath;
    private Image selfDifficultyImage;
    private RawImage selfGenderRImage;
    
    void Start()
    {
        uiManager = UIManager.instance;
        saveManager = SaveManager.instance;
        saveFilePath = saveManager.saveFilePath;

        if (shouldRefresh)
        {
            Refresh();
        }
    }

    public void Refresh()
    {
        string fullSavePath = saveFilePath + slot + ".txt";
        isSaveFile = System.IO.File.Exists(fullSavePath);
        Debug.Log("The save file exists? " + isSaveFile);

        selfDifficultyImage = gameObject.GetComponent<Image>();
        selfGenderRImage = child.GetComponent<RawImage>();

        if (isSaveFile)
        {
            slotDifficulty = int.Parse(saveManager.ReadIndex(slot, 0));
            Debug.Log("For slot " + slot + "Read difficulty as: " + slotDifficulty);
            slotGender = int.Parse(saveManager.ReadIndex(slot, 1));
            Debug.Log("For slot " + slot + "Read gender as: " + slotGender);
            switch (slotDifficulty)
            {
                case 1:
                    selfDifficultyImage.sprite = easyIMG;
                    break;
                case 2:
                    selfDifficultyImage.sprite = mediumIMG;
                    break;
                case 3:
                    selfDifficultyImage.sprite = hardIMG;
                    break;
                case 0:
                    Debug.Log("sprite bad");
                    break;
            }

            selfDifficultyImage.color = Color.white;
            selfGenderRImage.color = Color.white;
            deleteSaveButton.SetActive(true);

            switch (slotGender)
            {
                case 1:
                    selfGenderRImage.texture = femmeIMG;
                    break;
                case 2:
                    selfGenderRImage.texture = bothIMG;
                    break;
                case 3:
                    selfGenderRImage.texture = mascIMG;
                    break;
                case 0:
                    Debug.Log("sprite bad");
                    break;
            }
        }
        else
        {
            Debug.Log("Clearing");
            selfDifficultyImage.sprite = defaultIMG;
            Debug.Log(defaultIMG);
            selfGenderRImage.color = Color.clear;
            Debug.Log(selfGenderRImage.color.a);
            deleteSaveButton.SetActive(false);
        }
        Debug.Log("Refreshed");
    }

    public void onClick()
    {
        if (isSaveFile)
        {
            int controlInteger = int.Parse(saveManager.ReadIndex(slot, 0));
            if (controlInteger != 0)
            {
                Debug.Log("Loading Game Placeholder");
            }            
        } else
        {
            saveManager.selectedSlot = slot;
            uiManager.MakeDifficultySelectMenu();
        }
    }

    public void clearSlot(int i)
    {
        saveManager.DeleteSave(i);
        toRefresh.GetComponent<SaveSlotSprite>().Refresh();
    }
}
