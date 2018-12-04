using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBubble : MonoBehaviour
{
    public GameObject pop;
    public NumberSprite ns;
    public float speed;

    void Start()
    {
        ns.blockValue = (int)Random.Range(1.5f, 9.1f);
        float randomScale = Random.Range(.5f, 1f);
        transform.localScale = new Vector3(randomScale, randomScale, 0f);
    }
    void Update()
    {
        Vector3 randomVel = new Vector3(transform.position.x+Random.Range(-1f, 1f), 4f, 0f);
        transform.position = Vector3.Lerp(transform.position, randomVel, speed*Time.deltaTime);


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);
        Destroy(other.gameObject);
        Instantiate(pop, this.transform.position, this.transform.rotation);
        AudioManager.Pop();
    }
	
}
