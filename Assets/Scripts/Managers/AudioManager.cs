using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip buttonSound;
    public AudioSource buttonSource;
    // Start is called before the first frame update
   public void ButtonClick()
    {
        buttonSource.clip = buttonSound;
        buttonSource.Play();
    }
}
