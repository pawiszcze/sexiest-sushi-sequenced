using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    public Transform selfTransform;

    void Start()
    {
        selfTransform = this.gameObject.transform;
    }

    protected void PerformFlip()
    {
        selfTransform.localScale = new Vector3(selfTransform.localScale.x*-1, 1,1);
    }

    public void FlipRight()
    {
        selfTransform.localScale = new Vector3(1, 1, 1);
    }

    public void FlipLeft()
    {
        selfTransform.localScale = new Vector3(-1, 1, 1);
    }
}
