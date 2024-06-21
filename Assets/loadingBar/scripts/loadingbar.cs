﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadingbar : MonoBehaviour {

    private RectTransform rectComponent;
    private Image imageComp;
    public float speed = 0.001f;
   

    // Use this for initialization
    void Start () {
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        imageComp.fillAmount = 1.0f;
    }

    void Update()
    {
        if (imageComp.fillAmount != 0.0f)
        {
            imageComp.fillAmount = imageComp.fillAmount - Time.deltaTime * speed;
            
        }
    }
}