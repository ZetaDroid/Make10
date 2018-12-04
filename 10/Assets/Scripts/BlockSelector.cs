using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSelector : MonoBehaviour
{
    public float swipeThreshold;

    private bool upSwipe, downSwipe, leftSwipe, rightSwipe;
    private BlockMover blockToMove;
    private Vector3 mouseDownPos, mouseUpPos;
    
    void Awake()
    {
        ResetSwipe();
    }
    void Update()
    {
        if (blockToMove == null)
            {
                if (Input.GetMouseButton(0))
                {
                    Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    if (hit != null)
                    {
                        mouseDownPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        blockToMove = hit.gameObject.GetComponent<BlockMover>();
                    }
                    if (blockToMove != null)
                    {
                        blockToMove.ResetDirections();
                        blockToMove.CastAllDirections();
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (blockToMove != null)
                {
                    mouseUpPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    blockToMove.HideArrows();
                    CheckSwipe();
                    blockToMove.SetDirection(upSwipe, downSwipe, leftSwipe, rightSwipe);
                    ResetSwipe();
                    blockToMove = null;
                }
            }

        
    }

    void ResetSwipe()
    {
        upSwipe = downSwipe = leftSwipe = rightSwipe = false;
    }

    void CheckSwipe()
    {
        if (mouseUpPos.x - mouseDownPos.x > swipeThreshold)
        {
            ResetSwipe();
            rightSwipe = true;
        }
        if(mouseUpPos.x - mouseDownPos.x < -swipeThreshold)
        {
            ResetSwipe();
            leftSwipe = true;
        }
        if(mouseUpPos.y - mouseDownPos.y > swipeThreshold)
        {
            ResetSwipe();
            upSwipe = true;
        }
        if(mouseUpPos.y - mouseDownPos.y < -swipeThreshold)
        {
            ResetSwipe();
            downSwipe = true;
        }
    }
}
