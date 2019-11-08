using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KurageScale : MonoBehaviour
{
    private Text countText;
    private float timevalue;
    private float scale;
    // Start is called before the first frame update
    void Start()
    {
       countText=GameObject.Find("TimeCountText").GetComponent<Text>();
        timevalue = float.Parse(countText.text);

        if (timevalue <= 0)
        {
            this.transform.localScale = new Vector3(0.10f, 0.10f, 0.10f);
        }
        else
        {
            scale = timevalue * 0.02f + 0.10f;
            this.transform.localScale = new Vector3(scale, scale, scale);
            if (scale >= 0.4f)
            {
                this.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
