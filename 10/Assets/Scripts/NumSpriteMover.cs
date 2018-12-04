using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumSpriteMover : MonoBehaviour
{
    public bool up, down, left, right;
    public float speed;
    public NumberSprite numberSpriteThis;




    private bool toMove = false;
    private NumberSprite numberSprOther;
    private Vector3 posUpdate;

    void Update()
    {
        CheckDirection();
        if (toMove)
        {
            transform.position = transform.position + posUpdate * speed * Time.deltaTime;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Number"))
        {
            numberSprOther = other.gameObject.GetComponent<NumberSprite>();
            if (numberSprOther != null)
            {
                numberSprOther.blockValue += numberSpriteThis.blockValue;
                this.gameObject.SetActive(false);
                numberSprOther = null;
            }
        }
        else
        {
            ResetDirection();
            
        }
        
    }



    void CheckDirection()
    {
        if (up)
        {
            posUpdate = Vector3.up;
            toMove = true;
        }
        else if (down)
        {
            posUpdate = Vector3.down;
            toMove = true;
        }
        else if (left)
        {
            posUpdate = Vector3.left;
            toMove = true;
        }
        else if (right)
        {
            posUpdate = Vector3.right;
            toMove = true;
        }
        else
        {
            posUpdate = Vector3.zero;
            toMove = false;
        }
    }
    void ResetDirection()
    {
        up = down = left = right = false;
        toMove = false;
    }
	
}
