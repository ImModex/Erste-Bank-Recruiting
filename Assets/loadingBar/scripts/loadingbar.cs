using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadingbar : MonoBehaviour
{
    private RectTransform rectComponent;
    private Image imageComp;
    public float maxTime = 50.0f;
    private float timeLeft;
    public Image borderImage;
    public Text textComp;
    public GameObject teleporter;
    void Start()
    {
        rectComponent = GetComponent<RectTransform>();
        imageComp = GetComponent<Image>();
        timeLeft = maxTime;
        imageComp.fillAmount = 1.0f;
        borderImage = transform.parent.GetComponent<Image>();
        textComp = transform.parent.GetComponentInChildren<Text>();
    }

    void Update()
    {
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

            // Optional: Blende das GameObject "vica" aus

            // Szene neu laden
            //CustomSceneManager.Restart();
            //teleporter.SetActive(true);
        }
    }
}
