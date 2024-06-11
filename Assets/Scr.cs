using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr : MonoBehaviour
{
    public float maxTime = 5f;
    public float timeLeft;

    private RectTransform rectComponent;
    private SpriteRenderer spriteRenderer; // Verwende SpriteRenderer
    public float speed = 1.0f; // Ändere die Geschwindigkeit, wenn nötig

    void Start()
    {
        rectComponent = GetComponent<RectTransform>();
        spriteRenderer = rectComponent.GetComponent<SpriteRenderer>(); // Ändere zu SpriteRenderer

        if (spriteRenderer != null)
        {
            timeLeft = maxTime;
        }
        else
        {
            Debug.LogError("SpriteRenderer component not found!");
        }
    }

    // Update wird einmal pro Frame aufgerufen
    void Update()
    {
        if (spriteRenderer == null) return;

        if (timeLeft > 0f)
        {
            timeLeft -= Time.deltaTime * speed;
            float scaleX = Mathf.Clamp(timeLeft / maxTime, 0, 1);
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            Debug.Log("Time has run out!");
        }
    }
}
