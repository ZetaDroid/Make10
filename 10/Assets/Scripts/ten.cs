using UnityEngine;

public class ten : MonoBehaviour
{
    private bool boxReported;
	
	
	
	void OnTriggerEnter2D(Collider2D other)
    {
        if (!boxReported)
        {
            if (other.gameObject.CompareTag("Box"))
            {
                GameController.TenInBox();
                boxReported = true;
                Debugger.Log("Box");                    //DEBUG only
            }
        }
    }
}
