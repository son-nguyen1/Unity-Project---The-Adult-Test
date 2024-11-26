using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    public enum MovableType
    {

    }

    [SerializeField] private MovableType movableType;

    // Positions
    private Vector3 phoneNoonPos = new Vector3(5.75f, -2f, 0f);
    private Vector3 centerPos = new Vector3(0f, 0f, 0f);
    public Vector3 leftboundPos = new Vector3(-15f, 0f, 0f);

    private Vector3 startPos;
    private Vector3 randomPos;

    private float moveSpeed = 6.75f;

    private float delayTime = 0.1f;
    private float repeatInterval = 0.1f;
    private float vibrateOffset = 0.2f;

    private void Start()
    {
        startPos = transform.position;

        InvokeRepeating("SetRandomMovement", delayTime, repeatInterval);

        StartCoroutine(HandleMovement());
    }

    private IEnumerator HandleMovement()
    {
        yield return StartCoroutine(MoveToPosition(phoneNoonPos, moveSpeed));
        GetComponent<BoxCollider2D>().enabled = true;           
    }

    public IEnumerator MoveToPosition(Vector3 targetPos, float moveSpeed)
    {
        while (transform.position != targetPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private void DestroyObject()
    {
        if (Vector3.Distance(transform.position, leftboundPos) < 0.01f)
        {
            Destroy(gameObject);
        }
    }

    private void SetRandomMovement()
    {
        float xRandomPos = Random.Range(-vibrateOffset, vibrateOffset);
        float yRandomPos = Random.Range(-vibrateOffset, vibrateOffset);
        randomPos = new Vector3(startPos.x + xRandomPos, startPos.y + yRandomPos, startPos.z);

        transform.position = randomPos;
    }
}