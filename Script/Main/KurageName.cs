using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KurageName : MonoBehaviour
{
    public InputField inputField;
    public Text nameText;
    private new string name;
    private string getname;
   

    public GameObject namePanel;


    private void Awake()
    {
        getname = PlayerPrefs.GetString("Name", null);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (getname == null || getname == "")
        {
            namePanel.SetActive(true);

        }
        else
        {
            namePanel.SetActive(false);
            nameText.text = getname;
        }
    }

    // Update is called once per frame
   
//名前をテキストに反映
    public void Name()
    {
        name = inputField.text;
        nameText.text = name;
         PlayerPrefs.SetString("Name",name);
         
    }
//名前入力を非表示にする
    public void NameEnter()
    {
        if (!String.IsNullOrEmpty(inputField.text))
        {
            namePanel.SetActive(false);

        }

    }

   


   
}
