using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSprite : MonoBehaviour
{
    public GameObject ten,pop;


    public SpriteRenderer sprRenderer;
    public int blockValue;
    public Sprite[] numberSprites;
    public Sprite extra;

    private Transform minus;
    private BlockMover otherBM;
    private NumberSprite otherNS;
    void Awake()
    {
        minus = transform.Find("minus");
    }
    void Start()
    {
        SetSprite(blockValue);
    }

    //Test Update Block

    void Update()
    {
        SetSprite(blockValue);
    }


    
    public void SetSprite(int value)
    {
        if (value < 0)
        {
            sprRenderer.sprite = numberSprites[-1*value];
            minus.gameObject.SetActive(true);
        }
        else if(0<value && value<numberSprites.Length)
        {
            sprRenderer.sprite = numberSprites[value];
            minus.gameObject.SetActive(false);
        }
        else
        {
            sprRenderer.sprite = extra;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Number"))
        {
            otherBM = other.gameObject.GetComponent<BlockMover>();
            otherNS = other.gameObject.GetComponent<NumberSprite>();

            if(otherBM != null)
            {
                if (otherBM.toAdd)               //Check
                {
                    if (otherNS != null)
                    {
                        int i = otherNS.blockValue + this.blockValue;
                        if (i > 10 || i <= -10)
                        {
                            otherBM.GoBack();
                        }
                        else
                        {
                            if(i == 10)
                            {
                                Instantiate(ten, otherBM.finalDestination, this.transform.rotation);// Instantiate 10 sprite ////Check
                                Destroy(this.gameObject);
                                Destroy(other.gameObject);
                                GameController.Gone(2);                                             // Alert GameController;
                                Instantiate(pop, this.transform.position, this.transform.rotation);//Pop ParticleEffect;
                                AudioManager.Pop();                                                 //Play Pop Sound
                               // Debugger.Log("OtherFD: " + otherBM.finalDestination);
                            }
                            else if (i == 0)
                            {
                                Destroy(this.gameObject);
                                Destroy(other.gameObject);
                                GameController.Gone(2);
                                Instantiate(pop, this.transform.position, this.transform.rotation);//Pop ParticleEffect;
                                AudioManager.Pop();                                                 //Play Pop Sound
                            }
                            else
                            {
                                //otherBM.ResetAll(this.transform.position);
                                GameController.Gone(1);                                             // Alert GameController;
                                Instantiate(pop, this.transform.position, this.transform.rotation);//Pop ParticleEffect;
                                AudioManager.Pop();                                                 //Play Pop Sound
                                blockValue = i;
                                Destroy(other.gameObject);///////////////////////////////////////////////////////////////////////check

                            }
                        }

                       
                    }
                }
            }
        }
    }

	
}
