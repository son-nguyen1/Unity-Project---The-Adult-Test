using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingObject : MonoBehaviour
{
    public enum SwingableType
    {
        LeftBrow,
        RightBrow,

        LeftMouth,
        RightMouth,
    }

    [SerializeField] private SwingableType swingableType;

    private float swingSpeed = 150f;

    private float currentAngle;
    private float targetAngle;

    private void Start()
    {
        // Set the initial angle
        //currentAngle = 30f;
        //transform.parent.rotation = Quaternion.Euler(0f, 0f, currentAngle);
    }

    private void Update()
    {
        switch (swingableType)
        {
            case SwingableType.LeftBrow:
                StartSwing(KeyCode.Q, 15f, -15f);
                break;

            case SwingableType.RightBrow:
                StartSwing(KeyCode.R, -15f, 15f);
                break;

            case SwingableType.LeftMouth:
                StartSwing(KeyCode.X, -30f, 0f);
                break;

            case SwingableType.RightMouth:
                StartSwing(KeyCode.X, 30f, 0f);
                break;
        }
    }

    private void StartSwing(KeyCode swingKey, float desiredAngle, float forcedAngle)
    {
        if (Input.GetKey(swingKey))
        {
            targetAngle = desiredAngle;
        }
        else
        {
            targetAngle = forcedAngle;
        }

        currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, swingSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(0f, 0f, currentAngle);
    }
}