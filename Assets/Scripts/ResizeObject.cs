using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeObject : MonoBehaviour
{
    public enum ResizableType
    {
        LeftEye,
        RightEye
    }

    [SerializeField] private ResizableType resizableType;

    private Vector3 targetScale;

    private float resizeSpeed = 5f;

    private void Start()
    {
        targetScale = new Vector3(1.5f, 1.5f, 1f);
        transform.localScale = targetScale;
    }

    private void Update()
    {
        switch (resizableType)
        {
            case ResizableType.LeftEye:
                StartResize(KeyCode.S);
                break;

            case ResizableType.RightEye:
                StartResize(KeyCode.D);
                break;
        }
    }

    private void StartResize(KeyCode resizeKey)
    {
        if (Input.GetKey(resizeKey))
        {
            targetScale = new Vector3(1.5f, 1.5f, 1f);
        }
        else
        {
            targetScale = new Vector3(0.5f, 0.5f, 1f);
        }

        Vector3 newScale = Vector3.Lerp(transform.localScale, targetScale, resizeSpeed * Time.deltaTime);
        transform.localScale = newScale;
    }
}