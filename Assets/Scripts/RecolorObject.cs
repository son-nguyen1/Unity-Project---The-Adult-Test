using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolorObject : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private Color targetColor;

    private float recolorSpeed = 2f;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        targetColor = Color.white;
        spriteRenderer.color = targetColor;
    }

    private void Update()
    {
        StartRecolor();
    }

    private void StartRecolor()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            targetColor = Color.white;
        }
        else
        {
            targetColor = Color.red;
        }

        spriteRenderer.color = Color.Lerp(spriteRenderer.color, targetColor, recolorSpeed * Time.deltaTime);
    }    
}