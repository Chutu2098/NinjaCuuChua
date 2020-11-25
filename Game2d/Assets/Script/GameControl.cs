using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public int GamePoint = 0;
    
    public Text txtPoint;
    
    // Start is called before the first frame update
    void Start()
    {
       
        
    }// mai sửa // mai sửa

    // Update is called once per frame
    void Update()
    {
        txtPoint.text = "X " + GamePoint.ToString();
    }

    //public void GetPoint()
    //{
    //    txtPoint.text = "X " + GamePoint.ToString(); // dùng tạm thời
    //}
}
