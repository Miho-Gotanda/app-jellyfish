using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;



public class WaitButton : MonoBehaviour
{
    Button btn;
   
    
    // Start is called before the first frame update
    void Start()
    {
        btn =gameObject.GetComponent<Button>();
       
        
        
    }

    public void Button1()
    {
        btn.interactable = false;
        StartCoroutine(Button2());
    }

   IEnumerator Button2()
    {
        yield return new WaitForSeconds(3f);
        btn.interactable = true;
       
       
    }
}
