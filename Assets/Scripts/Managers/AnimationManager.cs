using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager instance;
    InputManager inputManager;
    UIManager uiManager;
    AudioManager audioManager;

    [SerializeField] Sprite[] CT001_Intro;
    [SerializeField] VideoClip VD001_Intro;

    [SerializeField] VideoPlayer vplayer;

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

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.instance;
        uiManager = UIManager.instance;
        audioManager = AudioManager.instance;

        GameObject camera = GameObject.Find("Main Camera");
        vplayer = camera.AddComponent<VideoPlayer>();
        vplayer.renderMode = VideoRenderMode.CameraNearPlane;
        vplayer.playOnAwake = false;
    }

    public void PlayClickThroughAnimation(Sprite[] animation)
    {
        
    }

    public void PlayVideo(VideoClip videoClip)
    {
        vplayer.clip = videoClip;
        uiManager.HideAllUILayers();
        audioManager.GetComponent<AudioSource>().Stop();
        vplayer.Play();
    }
    /*public void EndReached(VideoPlayer vp)
    {
        
    }*/
}
