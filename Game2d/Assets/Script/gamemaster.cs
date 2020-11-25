using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gamemaster : MonoBehaviour
{
    public int highscore = 0;
    public Text Inputtext;

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);

        if (PlayerPrefs.HasKey("points"))
        {
            Scene ActiveScreen = SceneManager.GetActiveScene();
            if (ActiveScreen.buildIndex == 0)
            {
                PlayerPrefs.DeleteKey("points");
                highscore = 0;
            }
            else
                highscore = PlayerPrefs.GetInt("points");
        }
    }

    // Update is called once per frame
    void Update(){
        Inputtext.text = ("X " + highscore);
    }
}
