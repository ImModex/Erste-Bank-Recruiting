using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scr : MonoBehaviour
{
    public float maxTime = 5f;
    public float timeLeft;

    private RectTransform rectComponent;
    private Image imageComp;
    public float speed = 0.0f;
    void Start()
    {
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        imageComp.fillAmount = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!imageComp) return;

        if (imageComp.fillAmount != 0f)
        {
            imageComp.fillAmount = imageComp.fillAmount - Time.deltaTime * speed;

        }
        else
        {
            Debug.Log("Time has run out!");
        }
    }
}
