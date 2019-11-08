using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }


    //スタートボタンを押したら実行する
    public void GameStart()
    {
        SceneManager.LoadScene("Main");
    }


    
}
