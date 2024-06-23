using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class loadingbar : MonoBehaviour
{
    private RectTransform rectComponent;
    private Image imageComp;
    public float speed = 0.001f;
    public Image borderImage;
    public Text textComp;
    public GameObject teleporter;
    // Use this for initialization
    void Start()
    {
        rectComponent = GetComponent<RectTransform>();
        imageComp = GetComponent<Image>();
        if (imageComp != null)
        {
            imageComp.fillAmount = 1.0f;
        }
        else
        {
            Debug.LogError("Image component is missing on this GameObject.");
        }

        // Annahme: Das borderImage ist das Image des Elternobjekts "loading3"
        borderImage = transform.parent.GetComponent<Image>();
        if (borderImage == null)
        {
            Debug.LogError("Border image not found in parent GameObject.");
        }

        // Finde das Text-Element im Elternobjekt
        textComp = transform.parent.GetComponentInChildren<Text>();
        if (textComp == null)
        {
            Debug.LogError("Text component not found in parent GameObject.");
        }
    }

    void Update()
    {
        if (imageComp != null && imageComp.fillAmount > 0.0f)
        {
            imageComp.fillAmount -= Time.deltaTime * speed;
        }
        else if (imageComp != null && imageComp.fillAmount <= 0.0f)
        {
            // Blende das borderImage aus
            if (borderImage != null)
            {
                borderImage.enabled = false;
            }

            // Blende das Text-Element aus
            if (textComp != null)
            {
                textComp.enabled = false;
            }

            // Optional: Blende das GameObject "vica" aus

            // Szene neu laden
            //CustomSceneManager.Restart();
            teleporter.SetActive(true);
        }
    }
}
