using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour
{
    public enum ClickableType
    {

    }

    [SerializeField] private ClickableType clickableType;

    private void Start()
    {

    }

    private void OnMouseDown()
    {
        GetComponent<BoxCollider2D>().enabled = false;
    }
}