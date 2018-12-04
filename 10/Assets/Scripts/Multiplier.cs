using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multiplier : MonoBehaviour
{
    public GameObject ten,pop;
    public bool isDivider;
    public int multiplier = 1; // number to multiply with. Check And confirm sprite;
    public float divider = 1;// number to divide with. Check And confirm sprite;

    private BlockMover otherBM;
    private NumberSprite otherNS;

    


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Number"))
        {
            otherBM = other.gameObject.GetComponent<BlockMover>();
            otherNS = other.gameObject.GetComponent<NumberSprite>();

            if (otherBM != null)
            {
                if (otherBM.toAdd)
                {
                    if (otherNS != null)
                    {
                        if (isDivider)
                        { 
                            float i = otherNS.blockValue / divider;
                            float r = otherNS.blockValue % divider;

                            if (r != 0)
                            {
                                otherBM.GoBack();
                            }
                            else
                            {
                                otherNS.blockValue = (int)i;
                                otherBM.ResetAll(this.transform.position);
                                Destroy(this.gameObject);
                                GameController.Gone(1);                                
                            }
                        }
                        else
                        {
                            int i = otherNS.blockValue * multiplier;
                            if (i > 10 || i <= -10)
                            {
                                otherBM.GoBack();
                            }
                            else
                            {
                                if (i == 10)
                                {
                                    Destroy(this.gameObject);
                                    Destroy(other.gameObject);
                                    Instantiate(ten, this.transform.position, this.transform.rotation);// Instantiate 10 sprite//////check
                                    GameController.Gone(2);                                             // Alert GameController;
                                    Instantiate(pop, this.transform.position, this.transform.rotation); //Pop ParticleEffect;
                                    AudioManager.Pop();                                                 //Play Pop Sound
                                }
                                else if (i == 0)
                                {
                                    Destroy(this.gameObject);
                                    Destroy(other.gameObject);
                                    GameController.Gone(2);
                                    Instantiate(pop, this.transform.position, this.transform.rotation); //Pop ParticleEffect;
                                    AudioManager.Pop();
                                }
                                else
                                {
                                    otherBM.ResetAll(this.transform.position);
                                    Destroy(this.gameObject);///////////////////////////////////////////////////////////////////////check
                                    GameController.Gone(1);                                             // Alert GameController;
                                    Instantiate(pop, this.transform.position, this.transform.rotation); //Pop ParticleEffect;
                                    AudioManager.Pop();                                                 //Play Pop Sound
                                    otherNS.blockValue = i;

                                }
                            }
                        }


                    }
                }
            }
        }
    }

}
