using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FadeObject : MonoBehaviour
{
    private TextMeshPro instructionText;

    private float waitTime = 0.5f;

    private void Awake()
    {
        instructionText = GetComponent<TextMeshPro>();

        Color color = instructionText.color;
        color.a = 0f; // Fully transparent
        instructionText.color = color;
    }

    private void Start()
    {
        FadeInObject(waitTime);
    }

    public void FadeInObject(float fadeInTime)
    {
        StartCoroutine(StartFade(fadeInTime, 0f, 1f));
    }

    public void FadeOutObject(float fadeOutTime)
    {
        StartCoroutine(StartFade(fadeOutTime, 1f, 0f));
    }

    private IEnumerator StartFade(float fadeTotalTime, float startAlphaColor, float endAlphaColor)
    {
        // Loop through all objects in the array
        Color startColor = instructionText.color;
        startColor.a = startAlphaColor; // Transparency (Alpha Color)
        instructionText.color = startColor;


        // Fade
        float fadeCurrentTime = 0f;
        while (fadeCurrentTime < fadeTotalTime)
        {
            // Increase value only between 0 and 1
            fadeCurrentTime += Time.deltaTime;
            float newAlphaColor = Mathf.Lerp(startAlphaColor, endAlphaColor, fadeCurrentTime / fadeTotalTime);

            // Update values between 0 and 1 to Alpha Color
            Color updatedColor = instructionText.color;
            updatedColor.a = newAlphaColor;
            instructionText.color = updatedColor;

            yield return null;
        }

        // Fully visible at the end
        Color finalColor = instructionText.color;
        finalColor.a = endAlphaColor;
        instructionText.color = finalColor;
    }
}