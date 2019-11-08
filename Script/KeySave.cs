using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string coutString = PlayerPrefs.GetString("countMoss", 0.ToString());
        float currentHealth = PlayerPrefs.GetFloat("hp", 70f);
        PlayerPrefs.Save();

        PlayerPrefs.DeleteKey("lastTime");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
