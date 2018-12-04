using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockMover : MonoBehaviour
{

    public NumberSprite numSprThis;
    public float lerpSpeed;

    public Transform arrowsParent, upArrow, downArrow, leftArrow, rightArrow;
    public Vector3 finalDestination;                      //final Destination from swipe and allowed direction;


    private bool allowedAtAll,upAllowed, downAllowed, leftAllowed, rightAllowed;//private
    private Vector3 startingPoint;                          //point to come back to if the sum goes over 10;
    private Vector3 destUp, destDown, destLeft, destRight;//possible destination position from Raycast;
    private float disToDest;

    [HideInInspector]
    public bool toMove,toAdd;   //check toAdd to add to other numbersprite blockvalue. //checking against toMove causes issues;
    [HideInInspector]
    public bool up, down, left, right;

    void Awake()
    {
        upAllowed = downAllowed = leftAllowed = rightAllowed = false;
    }

    void Start()
    {
        arrowsParent.gameObject.SetActive(false);
        startingPoint = finalDestination = transform.position;
    }

    //Position Updates in designated direction in the Update loop;
    void Update()
    {
        if (!toMove)
        {
            SetFinalDestination();
        }
        disToDest = Vector3.Distance(transform.position, finalDestination);
        if (disToDest > 0.001f)
        {
            if (disToDest > 0.25f)
            {
                toAdd = true;
            }
            else
            {
                toAdd = false;
            }
            toMove = true;
            
        }
        else
        {

            transform.position = finalDestination;
            finalDestination = transform.position;
            toMove = false;
            
        }
        if (toMove)
        {
            
            Vector3 newPosition = Vector3.Lerp(transform.position, finalDestination, lerpSpeed * Time.deltaTime);
            transform.position = newPosition;
            allowedAtAll = false;
        }
        else
        {
            allowedAtAll = true;
        }
       
        
    }

    

    //Raycast on all directions
    /// <staticRaycastMethod>
    ///public static RaycastHit2D[] RaycastNonAlloc(Vector2 origin, Vector2 direction, RayCastHit2D[] hitArray, float distance = Mathf.Infinity, int layerMask = DefaultRaycastLayers, float minDepth = -Mathf.Infinity, float maxDepth = Mathf.Infinity);
    /// </staticRaycastMethod>
    
    public void CastAllDirections()
    {

        if (allowedAtAll)
        {
            RayCastUp();
            RayCastDown();
            RayCastLeft();
            RayCastRight();

            //Showing Allowed Direction Arrows
            ShowArrows();
        }
        

    }
    private void RayCastUp()                //cast UP^
    {
        RaycastHit2D[] hitUp = new RaycastHit2D[2];
        Physics2D.RaycastNonAlloc(transform.position, Vector2.up, hitUp, 20.0f, 1, -2f, 2f);
        
        if (hitUp[1].collider != null)
        {
            
            string hitTag = hitUp[1].transform.gameObject.tag;
            if (hitTag == "Number")
            {
                BlockMover otherBM = hitUp[1].transform.gameObject.GetComponent<BlockMover>();
                if (otherBM != null)
                {
                    if (otherBM.toMove)
                    {
                        upAllowed = false;
                        return;
                    }
                    else
                    {
                        upAllowed = true;
                        destUp = new Vector3(transform.position.x, hitUp[1].transform.position.y, transform.position.z);
                    }
                }
                else
                {
                    upAllowed = true;
                    destUp = new Vector3(transform.position.x, hitUp[1].transform.position.y, transform.position.z);
                }
                
            }
            else
            {
                if (hitUp[1].distance < 1f)
                {
                    upAllowed = false;
                }
                else
                {
                    upAllowed = true;
                    destUp = new Vector3(transform.position.x, hitUp[1].transform.position.y - 1f, transform.position.z);
                }
            }
            
        }
        
    }

    private void RayCastDown()                //cast Down|
    {
        RaycastHit2D[] hitDown = new RaycastHit2D[2];
        Physics2D.RaycastNonAlloc(transform.position, Vector2.down, hitDown, 20.0f, 1, -2f, 2f);

        if (hitDown[1].collider != null)
        {
            
            string hitTag = hitDown[1].transform.gameObject.tag;
            if (hitTag == "Number")
            {
                BlockMover otherBM = hitDown[1].transform.gameObject.GetComponent<BlockMover>();
                if (otherBM != null)
                {
                    if (otherBM.toMove)
                    {
                        downAllowed = false;
                        return;
                    }
                    else
                    {
                        downAllowed = true;
                        destDown = new Vector3(transform.position.x, hitDown[1].transform.position.y, transform.position.z);
                    }
                }
                else
                {
                    downAllowed = true;
                    destDown = new Vector3(transform.position.x, hitDown[1].transform.position.y, transform.position.z);
                }
                
            }
            else
            {
                if (hitDown[1].distance < 1f)
                {
                    downAllowed = false;
                }
                else
                {
                    downAllowed = true;
                    destDown = new Vector3(transform.position.x, hitDown[1].transform.position.y + 1f, transform.position.z);
                }
            }
           
        }

    }

    private void RayCastLeft()                //cast Left<
    {
        RaycastHit2D[] hitLeft = new RaycastHit2D[2];
        Physics2D.RaycastNonAlloc(transform.position, Vector2.left, hitLeft, 20.0f, 1, -2f, 2f);

        if (hitLeft[1].collider != null)
        {
            
            string hitTag = hitLeft[1].transform.gameObject.tag;
            if (hitTag == "Number")
            {
                BlockMover otherBM = hitLeft[1].transform.gameObject.GetComponent<BlockMover>();
                if (otherBM != null)
                {
                    if (otherBM.toMove)
                    {
                        leftAllowed = false;
                        return;
                    }
                    else
                    {
                        leftAllowed = true;
                        destLeft = new Vector3(hitLeft[1].transform.position.x, transform.position.y, transform.position.z);
                    }
                }
                else
                {
                    leftAllowed = true;
                    destLeft = new Vector3(hitLeft[1].transform.position.x, transform.position.y, transform.position.z);
                }
                
            }
            else
            {
                if (hitLeft[1].distance < 1f)
                {
                    leftAllowed = false;
                }
                else
                {
                    leftAllowed = true;
                    destLeft = new Vector3(hitLeft[1].transform.position.x+1f, transform.position.y, transform.position.z);
                }
            }
           
        }

    }


    private void RayCastRight()                //cast Right>
    {
        RaycastHit2D[] hitRight = new RaycastHit2D[2];
        Physics2D.RaycastNonAlloc(transform.position, Vector2.right, hitRight, 20.0f, 1, -2f, 2f);

        if (hitRight[1].collider != null)
        {
            
            string hitTag = hitRight[1].transform.gameObject.tag;
            if (hitTag == "Number")
            {
                BlockMover otherBM = hitRight[1].transform.gameObject.GetComponent<BlockMover>();
                if (otherBM != null)
                {
                    if (otherBM.toMove)
                    {
                        rightAllowed = false;
                        return;
                    }
                    else
                    {
                        rightAllowed = true;
                        destRight = new Vector3(hitRight[1].transform.position.x, transform.position.y, transform.position.z);
                    }
                }
                else
                {
                    rightAllowed = true;
                    destRight = new Vector3(hitRight[1].transform.position.x, transform.position.y, transform.position.z);
                }
                
            }
            else
            {
                if (hitRight[1].distance < 1f)
                {
                    rightAllowed = false;
                }
                else
                {
                    rightAllowed = true;
                    destRight = new Vector3(hitRight[1].transform.position.x-1, transform.position.y, transform.position.z);
                }
            }
            
        }

    }

    
    
    // Check Allowed Directions And Show Arrows

    private void ShowArrows()
    {
        upArrow.position = destUp;
        upArrow.gameObject.SetActive(upAllowed);

        downArrow.position = destDown;
        downArrow.gameObject.SetActive(downAllowed);

        leftArrow.position = destLeft;
        leftArrow.gameObject.SetActive(leftAllowed);

        rightArrow.position = destRight;
        rightArrow.gameObject.SetActive(rightAllowed);

        arrowsParent.gameObject.SetActive(true);
    }

    public void HideArrows()
    {
        arrowsParent.gameObject.SetActive(false);
    }

    //Listen to swipe input;
    public void SetDirection(bool upSwipe, bool downSwipe, bool leftSwipe, bool rightSwipe)
    {
        if (allowedAtAll)
        {
            up = upSwipe;
            down = downSwipe;
            left = leftSwipe;
            right = rightSwipe;
        }
    }

    //Set Final Destination;
    void SetFinalDestination()
    {
        
            if (upAllowed && up)
            {
                finalDestination = destUp;
                ResetDirections();
            }
            if (downAllowed && down)
            {
                finalDestination = destDown;
                ResetDirections();
        }
            if (leftAllowed && left)
            {
                finalDestination = destLeft;
                ResetDirections();
        }
            if (rightAllowed && right)
            {
                finalDestination = destRight;
                ResetDirections();
        }
            startingPoint = transform.position;
        
            //Debugger.NewLog(transform.name + " ND: "+finalDestination);
    }


    public void ResetAll(Vector3 position)
    {
        ResetDirections();
        toAdd = toMove = false;
        this.transform.position = position;
        startingPoint = transform.position;
    }

    public void ResetDirections()
    {
        upAllowed = downAllowed = leftAllowed = rightAllowed = up = down = left = right = false;
    }

    //If sum goes over 10 go back to previous position
    public void GoBack()
    {
        transform.position = startingPoint;
        ResetAll(transform.position);
        finalDestination = startingPoint;
        toMove = false;
        //Play DUN DUN <As like Not allowed> sound;
        AudioManager.Deny();
    }
}
