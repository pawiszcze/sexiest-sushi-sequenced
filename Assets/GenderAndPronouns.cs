using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenderAndPronouns : MonoBehaviour
{
    public static GenderAndPronouns instance;
    public static int activeGender;
    public static int  activePronouns;

    private void Awake()
    {
      
    }

    public void SelectGender(int gender)
    {
        activeGender = gender;                      //1 - Fem, 2 - Masc, 3 - Misc
    }

    public void SelectPronouns(int pronouns)
    {
        activePronouns = pronouns;                  //1 - Fem, 2 - Masc, 3 - They, 4 - Random, 5 - Presenting
        switch (activePronouns)
        {
            case 1:
                Debug.Log("She/Her");
                break;
            case 2:
                Debug.Log("He/Him");
                break;
            case 3:
                Debug.Log("They/Them");
                break;
            case 4:
                Debug.Log("Random");
                break;
            case 5:
                Debug.Log("As presenting");
                break;
        }
    }
}
