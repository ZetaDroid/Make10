using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelText : MonoBehaviour
{
    public Text levelText;
	// Use this for initialization
	void Start ()
    {
		levelText.text = "Level: "+ SceneManager.GetActiveScene().buildIndex;
    }
}
