using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectDifficulty : MonoBehaviour
{
    private GameObject confirm;
    private GameObject change;
    public  GameObject other1;
    public  GameObject other2;
    public  GameObject separator1;
    public  GameObject separator2;
    private Image other1Image;
    private Image other2Image;
    private Button other1Button;
    private Button other2Button;
    public Sprite thisSprite;
    private Sprite other1Sprite;
    private Sprite other2Sprite;
    private bool debugToggle;

    void Start()
    {
        debugToggle = false;
        confirm = this.gameObject.transform.GetChild(0).GetChild(1).gameObject;
        change = this.gameObject.transform.GetChild(0).GetChild(2).gameObject;
        other1Image = other1.GetComponent<Image>();
        other2Image = other2.GetComponent<Image>();
        other1Button = other1.GetComponent<Button>();
        other2Button = other2.GetComponent<Button>();
        other1Sprite = other1Image.sprite;
        other2Sprite = other2Image.sprite;
        thisSprite = this.gameObject.GetComponent<Image>().sprite;
    }

    public void OnClick(bool i)
    {
        confirm.SetActive(!i);
        change.SetActive(!i);
        separator1.SetActive(i);
        separator2.SetActive(i);
        other1.transform.GetChild(0).gameObject.SetActive(i);
        other2.transform.GetChild(0).gameObject.SetActive(i);
        other1Button.enabled = i;
        other2Button.enabled = i;
        if (i)
        {
            other1Image.sprite = other1Sprite;
            other2Image.sprite = other2Sprite;
        }
        else
        {
            other1Image.sprite = thisSprite;
            other2Image.sprite = thisSprite;
        }
        debugToggle = !debugToggle;
    }
}
