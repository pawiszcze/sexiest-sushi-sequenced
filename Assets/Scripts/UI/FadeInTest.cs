using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInTest : MonoBehaviour
{
    UIManager uiManager;

    //private int frame;

    [SerializeField] private Image image1;
    [SerializeField] private Image image2;
    [SerializeField] private Image image3;
    [SerializeField] private Image image4;
    [SerializeField] private Image image5;
    [SerializeField] private Image image6;
    [SerializeField] private float animationLength;

    public void Awake()
    {
        uiManager = UIManager.instance;
    }

    //private void Start()
    //{
    //    frame = 0;
    //}

    public void FadeIn()
    {
        uiManager.isPlayingAnAnimation = true;
        StartCoroutine(FadeImage(image1));
        StartCoroutine(DelayedStart(FadeImage(image2), 1));
        StartCoroutine(DelayedStart(FadeImage(image3), 2));
        StartCoroutine(DelayedStart(FadeImage(image4), 3));
        StartCoroutine(DelayedStart(FadeImage(image5), 4));
        StartCoroutine(DelayedStart(FadeImage(image6), 5));
        StartCoroutine(DelayedChange(animationLength));
    }

    private void OnDisable()
    {
        InputManager.EscDown += uiManager.EscToggle;
    }

    IEnumerator DelayedChange(float delay)
    {
        uiManager.isPlayingAnAnimation = true;
        yield return new WaitForSeconds(delay);

    }

    IEnumerator DelayedStart(IEnumerator toPlay, int delay)
    {
        for (float i = delay; i >= 0; i -= Time.deltaTime)
        {
            yield return null;
        }
        StartCoroutine(toPlay);
    }

    IEnumerator FadeImage(Image image)
    {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                image.color = new Color(1, 1, 1, i);
                yield return null;
            }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space)/* || Input.GetMouseButton(0) || Input.GetMouseButton(1)*/)
        {
            Skip();
        }
    }

    private void Skip()
    {
        Color fullColor = Color.white;
        StopAllCoroutines();
        image1.color = fullColor;
        image2.color = fullColor;
        image3.color = fullColor;
        image4.color = fullColor;
        image5.color = fullColor;
        image6.color = fullColor;
    }
}
