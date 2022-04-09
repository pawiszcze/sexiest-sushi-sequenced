using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectGender : MonoBehaviour
{
    private GameObject confirm;
    private GameObject change;
    public GameObject greyout1;
    public GameObject greyout2;

    void Start()
    {
        confirm = this.gameObject.transform.GetChild(2).GetChild(1).gameObject;     //Lower to getchild(1) when mix image placed
        change = this.gameObject.transform.GetChild(2).GetChild(2).gameObject;      //Lower to getchild(1) when mix image placed
    }

    public void OnClick(bool i)
    {
        confirm.SetActive(!i);
        change.SetActive(!i);
        greyout1.SetActive(!i);
        greyout2.SetActive(!i);
    }
}
