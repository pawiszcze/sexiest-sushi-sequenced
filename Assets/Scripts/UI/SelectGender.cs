using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectGender : MonoBehaviour
{
    private GameObject confirm;
    private GameObject greyout;
    public GameObject button1;
    public GameObject greyout1;
    public GameObject button2;
    public GameObject greyout2;
    //public GameObject pronounsSection;

    void Start()
    {
        confirm = this.gameObject.transform.GetChild(2).GetChild(1).gameObject;     //Lower to getchild(1) when mix image placed //Start
        greyout = this.gameObject.transform.GetChild(3).gameObject;                 //Lower to getchild(1) when mix image placed //Greyout
    }

    public void OnClick()
    {
        Deselect();
        confirm.SetActive(true);
        greyout1.SetActive(true);
        greyout2.SetActive(true);
    }

    public void Deselect()
    {
        confirm.SetActive(false);
        greyout.SetActive(false);
        button1.SetActive(false);
        button2.SetActive(false);
        greyout1.SetActive(false);
        greyout2.SetActive(false);

    }
}
