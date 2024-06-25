using System.Collections;
using System.Collections.Generic;
using SpatialSys.Samples.InputOverride;
using UnityEngine;
using UnityEngine.UI;

public class loadingbar : MonoBehaviour
{
    public float maxTime = 50.0f;
    public bool pause = false;
    
    private float timeLeft;
    
    private Image imageComp;
    public Image borderImage;
    public Text textComp;

    public ErsteBankTask task;
    
    void Start()
    {
        imageComp = GetComponent<Image>();
        timeLeft = maxTime;
        imageComp.fillAmount = 1.0f;
        //borderImage = transform.parent.GetComponent<Image>();
        //textComp = transform.parent.GetComponentInChildren<Text>();
    }

    void Update()
    {
        if (pause) return;
        
        if (imageComp != null && imageComp.fillAmount > 0.0f)
        {
            timeLeft -= Time.deltaTime;
            imageComp.fillAmount = timeLeft / maxTime;
        }
        else if (imageComp != null && imageComp.fillAmount <= 0.0f)
        {

            if (borderImage != null)
            {
                borderImage.enabled = false;
            }
            if (textComp != null)
            {
                textComp.enabled = false;
            }

            task.FailTask();
        }
    }
}
