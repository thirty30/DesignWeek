using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float moveSpeed;
    public Vector2 moveToPoint;
    public bool isMoving;


    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveToPoint, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveToPoint)<= 0.5f)
            {
                transform.position = moveToPoint;
                isMoving = false;
                moveToPoint = new Vector2(0, 0);
            }
        }

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f && !isMoving)
        {
            SetNewMoveLocation();
        }
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f && !isMoving)
        {
            SetNewMoveLocation();
        }
    }

    void SetNewMoveLocation()
    {
        moveToPoint = new Vector2(transform.position.x + Input.GetAxisRaw("Horizontal"), transform.position.y + Input.GetAxisRaw("Vertical"));
        isMoving = true;
    }
}
