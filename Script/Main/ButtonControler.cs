using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControler : MonoBehaviour
{
    
    public GameObject foodPrefab;
    private KurageMove kurage;
    public bool foodButton = false;
    public GameObject eatButton;
    private Image eatImage;
    public Sprite on;
    public Sprite off;


    private void Start()
    {
        kurage = GameObject.FindGameObjectWithTag("Kurage").GetComponent<KurageMove>();
        eatImage = eatButton.GetComponent<Image>();
    }
   

    public void Hoge()
    {
        eatImage.sprite = (foodButton) ? on : off;
        eatImage.SetNativeSize();
        foodButton = !foodButton;
    }

   
}

