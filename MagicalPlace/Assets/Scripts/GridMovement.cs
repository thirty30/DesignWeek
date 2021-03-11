using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public float moveSpeed;
    public float moveDistance;
    public LayerMask obstacleLayer;
    public bool isRecharging;


    private bool isLookingLeft;
    private Vector2 moveToPoint;
    private bool isMoving;


    void Update()
    {
        if (isMoving)
        {
            transform.position = Vector2.MoveTowards(transform.position, moveToPoint, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, moveToPoint)<= 0.2f)
            {
                transform.position = moveToPoint;
                isMoving = false;
                moveToPoint = new Vector2(0, 0);
                this.GetComponent<Animator>().SetFloat("speed", 0);
            }
        }
        else if (!isMoving && this.GetComponent<Animator>().GetFloat("speed") > 0)
        {
            this.GetComponent<Animator>().SetFloat("speed", 0);
        }



        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f && !isMoving && !isRecharging)
        {
            SetNewMoveLocation();
            this.GetComponent<Animator>().SetFloat("speed", Mathf.Abs(Input.GetAxis("Horizontal")));

            if (Input.GetAxisRaw("Horizontal") < 0 && !isLookingLeft)
            {
                isLookingLeft = true;
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if (Input.GetAxisRaw("Horizontal") > 0 && isLookingLeft)
            {
                isLookingLeft = false;
                GetComponent<SpriteRenderer>().flipX = false;
            }
            
        }
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f && !isMoving && !isRecharging)
        {
            SetNewMoveLocation();
            this.GetComponent<Animator>().SetFloat("speed", Mathf.Abs(Input.GetAxis("Vertical")));
        }
    }

    void SetNewMoveLocation()
    {
        moveToPoint = new Vector2(transform.position.x + Input.GetAxisRaw("Horizontal") * moveDistance, transform.position.y + Input.GetAxisRaw("Vertical") * moveDistance);

        if (!Physics2D.OverlapCircle(moveToPoint, 0.2f, obstacleLayer))
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
            this.GetComponent<Animator>().SetFloat("speed", 0);
        }
    }
}
