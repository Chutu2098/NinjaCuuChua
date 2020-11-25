using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public int Levelload = 1;
    public gamemaster gm; // sửa đếm

    // Use this for initialization
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<gamemaster>(); //sửa đếm
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (Input.GetKey(KeyCode.E))
            {
                savescore();
                SceneManager.LoadScene(Levelload);
            }
        }
    }
    void savescore()
    {
        PlayerPrefs.SetInt("points", gm.highscore);
    }
}
