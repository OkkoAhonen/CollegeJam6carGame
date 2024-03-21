using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : DistanceTracker
{
    public Image progressbar;
    private float progress;

    // Start is called before the first frame update
    void Start()
    {
        Progress(1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Progress(float newProgress)
    {
        if(newProgress <= 1)
        {
            progress = newProgress;
        }
        else
        {
            progress = 1;
        }

        progressbar.transform.localScale = new Vector3 (progress, progressbar.transform.localScale.y, progressbar.transform.localScale.z);
    }
}
