using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    // Game Objects
    [SerializeField] private GameObject leftEye;
    [SerializeField] private GameObject rightEye;

    [SerializeField] private GameObject leftBrow;
    [SerializeField] private GameObject rightBrow;

    [SerializeField] private GameObject leftMouth;
    [SerializeField] private GameObject rightMouth;

    // Scripts
    private DragObject[] draggableObjects;
    private SwingObject[] swingableObjects;
    private ResizeObject[] resizableObjects;
    private RecolorObject[] recolorableObjects;

    private SwingObject leftBrowSwing;
    private SwingObject rightBrowSwing;
    private SwingObject leftMouthSwing;
    private SwingObject rightMouthSwing;

    private void Awake()
    {
        leftBrowSwing = leftBrow.GetComponent<SwingObject>();
        rightBrowSwing = rightBrow.GetComponent<SwingObject>();
        leftMouthSwing = leftMouth.GetComponent<SwingObject>();
        rightMouthSwing = rightMouth.GetComponent<SwingObject>();

        draggableObjects = FindObjectsOfType<DragObject>();
        swingableObjects = FindObjectsOfType<SwingObject>();
        resizableObjects = FindObjectsOfType<ResizeObject>();
        recolorableObjects = FindObjectsOfType<RecolorObject>();
    }

    public void ShakeObject()
    {
        leftEye.GetComponent<ShakableObject>().ShakeObject();
        rightEye.GetComponent<ShakableObject>().ShakeObject();

        leftBrow.GetComponent<ShakableObject>().ShakeObject();
        rightBrow.GetComponent<ShakableObject>().ShakeObject();

        leftMouth.GetComponent<ShakableObject>().ShakeObject();
        rightMouth.GetComponent<ShakableObject>().ShakeObject();
    }

    public void DisableDragObject()
    {
        foreach (DragObject obj in draggableObjects)
        {
            obj.enabled = false;
        }
    }

    public void EnableDragObject()
    {
        foreach (DragObject obj in draggableObjects)
        {
            obj.enabled = true;
        }
    }

    public void DisableSwingObject()
    {
        foreach (SwingObject obj in swingableObjects)
        {
            obj.enabled = false;
        }
    }

    public void EnableSwingBrow()
    {
        leftBrowSwing.enabled = true;
        rightBrowSwing.enabled = true;
    }

    public void EnableSwingMouth()
    {
        leftMouthSwing.enabled = true;
        rightMouthSwing.enabled = true;
    }

    public void DisableResizeObject()
    {
        foreach (ResizeObject obj in resizableObjects)
        {
            obj.enabled = false;
        }
    }

    public void EnableResizeObject()
    {
        foreach (ResizeObject obj in resizableObjects)
        {
            obj.enabled = true;
        }
    }

    public void DisableRecolorObject()
    {
        foreach (RecolorObject obj in recolorableObjects)
        {
            obj.enabled = false;
        }
    }

    public void EnableRecolorObject()
    {
        foreach (RecolorObject obj in recolorableObjects)
        {
            obj.enabled = true;
        }
    }
}