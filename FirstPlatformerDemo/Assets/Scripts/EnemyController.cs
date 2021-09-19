using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float moveSpeed;
    public float horizontalMoveDistance;
    public float verticalMoveDistance;

    private bool forwards;
    private Vector2 startPosition;
    private float moveProgress = 0;

    // Start is called before the first frame update, we store our start position here
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //Calculate the next position of our enemy, then move them there
    private void Move()
    {
        if (forwards)
        {
            Mathf.Min(moveProgress += (Time.deltaTime * moveSpeed * GameManager.instance.GetTimeScale()), 1);
        }
        else
        {
            Mathf.Max(moveProgress -= (Time.deltaTime * moveSpeed * GameManager.instance.GetTimeScale()), 0);
        }
        Vector2 horizontalOffset = (Vector2.right * horizontalMoveDistance * Mathf.Sin((Mathf.PI / 2f) * moveProgress));
        Vector2 verticalOffset = (Vector2.up * verticalMoveDistance * Mathf.Sin((Mathf.PI / 2f) * moveProgress));
        transform.position = startPosition + horizontalOffset + verticalOffset;

        if (moveProgress == 0f || moveProgress == 1f)
        {
            forwards = !forwards;
        }
    }
}
