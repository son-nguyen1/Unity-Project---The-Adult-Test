using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private float moveSpeed = 200f;
    private float hoverOffset = -50f;

    private Vector3 startPos;
    private Vector3 targetPos;

    private bool isHovering = false;

    private void Start()
    {
        startPos = transform.localPosition;
        targetPos = startPos + new Vector3(hoverOffset, 0f, 0f);
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        if (isHovering)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, startPos, moveSpeed * Time.deltaTime);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }
}