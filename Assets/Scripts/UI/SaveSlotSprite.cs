using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveSlotSprite : MonoBehaviour
{
    SaveManager saveManager;
    UIManager uiManager;

    [SerializeField] Sprite easyIMG;
    [SerializeField] Sprite mediumIMG;
    [SerializeField] Sprite hardIMG;
    [SerializeField] int slot;

    int slotDifficulty = 0;
    bool isSaveFile = false;

    private string saveFilePath;
    private Image selfImage;
    
    void Start()
    {
        uiManager = UIManager.instance;
        saveManager = SaveManager.instance;
        saveFilePath = saveManager.saveFilePath;

        selfImage = gameObject.GetComponent<Image>();

        string fullSavePath = saveFilePath + slot + ".txt";
        isSaveFile = System.IO.File.Exists(fullSavePath);
        //Debug.Log("Selected slot is " + slot);

        if (isSaveFile)
        {
            slotDifficulty = int.Parse(saveManager.ReadIndex(slot, 0));
            switch (slotDifficulty){
                case 1:
                    selfImage.sprite = easyIMG;
                    //Debug.Log("Slot " + slot + ", difficulty Easy");
                    break;
                case 2:
                    selfImage.sprite = mediumIMG;
                    //Debug.Log("Slot " + slot + ", difficulty Medium");
                    break;
                case 3:
                    selfImage.sprite = hardIMG;
                    //Debug.Log("Slot " + slot + ", difficulty Hard");
                    break;
                case 0:
                    Debug.Log("sprite bad");
                    break;
            }
            selfImage.color = Color.white;
        }
    }

    public void onClick()
    {
        if (isSaveFile)
        {
            Debug.Log("Loading Game Placeholder");
        } else
        {
            uiManager.MakeDifficultySelectMenu();
            saveManager.Save(slot);
        }
    }
}
