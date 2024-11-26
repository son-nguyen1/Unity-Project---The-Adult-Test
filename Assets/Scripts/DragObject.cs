using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    private void Start()
    {
        
    }

    private void OnMouseDown()
    {
        if (!enabled) return;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mousePos.x, mousePos.y, 0f);
        isDragging = true;
    }

    private void OnMouseDrag()
    {
        if (!enabled || !isDragging) return;

        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePos.x, mousePos.y, 0f) + offset;
        }
    }

    private void OnMouseUp()
    {
        if (!enabled) return;

        isDragging = false;
    }
}