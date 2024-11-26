using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightManager : MonoBehaviour
{
    private Light2D light2D;

    private void Awake()
    {
        light2D = GetComponent<Light2D>();
    }

    private void Start()
    {
        light2D.color = Color.white;
    }

    public IEnumerator StartFadeToWhite(float fadeTime = 1f)
    {
        yield return StartCoroutine(FadeLightEffect(fadeTime, Color.black, Color.white));
    }

    public IEnumerator StartFadeToBlack(float fadeTime = 1f)
    {
        yield return StartCoroutine(FadeLightEffect(fadeTime, Color.white, Color.black));
    }

    private IEnumerator FadeLightEffect(float fadeTotalTime, Color startColor, Color targetColor)
    {
        float fadeCurrentTime = 0f;
        
        while (fadeCurrentTime < fadeTotalTime)
        {
            // Slowly fade the light color over time
            fadeCurrentTime += Time.deltaTime;
            light2D.color = Color.Lerp(startColor, targetColor, fadeCurrentTime / fadeTotalTime);
            yield return null;
        }

        // Ensure the light matches its target color at the end 
        light2D.color = targetColor;
    }
}