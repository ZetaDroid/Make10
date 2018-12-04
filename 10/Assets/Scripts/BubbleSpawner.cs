using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    //Random bubble spawner in the Intro Scene;

    public GameObject NumBubble, pop;
    public float minDelay, maxDelay;
    public float speed,minX,maxX;
    private float delay = 0;
    float counter;
    Vector3 velocity;

    void Update()
    {
        if (counter >= delay)
        {
            Spawn();
        }
        else
        {
            counter += Time.deltaTime;
        }
        if (transform.position.x >= maxX)
        {
            speed = -speed;
        }
        else if (transform.position.x <= minX)
        {
            speed = -speed;
        }
        velocity.x = speed * Time.deltaTime;
        transform.position += velocity;

        if (Input.GetMouseButtonDown(0))
        {
            Collider2D hit = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            if (hit != null)
            {
                if (hit.gameObject.CompareTag("Number"))
                {
                    Destroy(hit.gameObject);
                    Instantiate(pop, hit.transform.position, hit.transform.rotation);
                    AudioManager.Pop();
                }
            }
        }


    }
    private void Spawn()
    {
        counter = 0;
        delay = Random.Range(minDelay, maxDelay);
        Instantiate(NumBubble, transform.position, transform.rotation);
    }
	
}
