using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip buttonSound;
    public AudioSource buttonSource;
    // Start is called before the first frame update

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
    public void ButtonClick()
    {
        buttonSource.clip = buttonSound;
        buttonSource.Play();
    }
}
