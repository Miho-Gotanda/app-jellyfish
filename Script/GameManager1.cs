using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public GameObject backButton;
    public GameObject[] kindKurage;
    public GameObject[] backImage;
    [SerializeField]
    private GameObject kurageCanvas;


    private GameObject obj;

    // Start is called before the first frame update
    void Awake()
    {
       //クラゲの生成と水槽の表示
        int choseKurage = PlayerPrefs.GetInt("choseKurage", 0);
        switch (choseKurage)
        {
            case 0:
                obj = GameObject.Instantiate(kindKurage[0]);
                break;
            case 1:
                obj = GameObject.Instantiate(kindKurage[1]);
                break;
            case 2:
                obj = GameObject.Instantiate(kindKurage[2]);
                break;

        }

        int backchose = PlayerPrefs.GetInt("Back", 1);
        switch (backchose)
        {
            case 0:
                backImage[0].SetActive(true);
                backImage[1].SetActive(false);
                break;
            case 1:
                backImage[0].SetActive(false);
                backImage[1].SetActive(true);
                break;
        }
    }

    //鑑賞ボタン
    public void EyeButton()
    {
         kurageCanvas.SetActive(false);
         backButton.SetActive(true);
    }

    //鑑賞から戻るボタン
    public void EyeBackButton()
    {
        kurageCanvas.SetActive(true);
        backButton.SetActive(false);
    }
 
}
