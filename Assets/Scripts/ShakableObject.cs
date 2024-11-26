using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakableObject : MonoBehaviour
{
    private float shakeIntensity = 0.1f;
    private float shakeTotalTime = 0.5f;

    public void ShakeObject()
    {
        StartCoroutine(StartShake());
    }

    private IEnumerator StartShake()
    {
        float currentTime = 0f;

        while (currentTime < shakeTotalTime)
        {
            transform.position += (Vector3)Random.insideUnitCircle * shakeIntensity;

            currentTime += Time.deltaTime;
            yield return null;
        }
    }
}