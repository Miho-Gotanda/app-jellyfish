using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossControler : MonoBehaviour
{

    public GameObject mossPrefab;
    public GameObject flashPrefab;

    private GameObject mossCanvas;
    private GameObject obj;
    private Vector3 left_top;
    private Vector3 right_bottom;
    private float timer=0f;
    public double cout;
   

    private void Awake()
    {

        string coutString = PlayerPrefs.GetString("countMoss", 0.ToString());
        cout = double.Parse(coutString);
        string timestring = PlayerPrefs.GetString("lastTime", DateTime.Now.ToString());

        DateTime dateTime = DateTime.Parse(timestring);

        TimeSpan span = DateTime.Now - dateTime;

        double timeSpan = span.TotalHours;
       
        cout += timeSpan;

        if (cout > 15)
            cout = 15d;

    }
    // Start is called before the first frame update
    void Start()
    {
        mossCanvas = GameObject.Find("MossCanvas");
        left_top = new Vector3(-543f,954f, 0);
        right_bottom = new Vector3(535f, -954, 0);

        if (cout >=1d)
        {
            for (var i = 0d; i < cout; i++)
            {
                InstansMoss();
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {

       
        //実行中の時間経過によって一時間に一つコケを増やす
        timer += Time.deltaTime;
        if (timer > 3600f&&cout<15)
        {
            InstansMoss();
            
            timer = 0f;
            cout++;    
        }
    }

    //ランダムな位置を設定
    Vector3 GetRandPos() 
    {
        var x = UnityEngine.Random.Range(left_top.x, right_bottom.x);
        var y = UnityEngine.Random.Range(left_top.y, right_bottom.y);
        return new Vector3(x, y, 0f);
        
    }

    void InstansMoss()
    {
        var x = UnityEngine.Random.Range(left_top.x, right_bottom.x);
        var y = UnityEngine.Random.Range(left_top.y, right_bottom.y);
        obj = GameObject.Instantiate(mossPrefab,new Vector3(x,y,0f), Quaternion.identity);

        obj.transform.SetParent(mossCanvas.transform, false);
        
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            PlayerPrefs.SetString("countMoss", cout.ToString());
            PlayerPrefs.Save();
        }
        else if (focus)
        {
            Awake();
        }
    }

    public void DestroyMoss()
    {
        var clones = GameObject.FindGameObjectsWithTag("Moss");
        var foods = GameObject.FindGameObjectsWithTag("Food");
        foreach(var clone in clones)
        {
            Destroy(clone);
        }
        foreach(var food in foods)
        {
            Destroy(food);
        }
        cout = 0d;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetString("countMoss", cout.ToString());
        PlayerPrefs.Save();
    }

    public void OnFlash()
    {
        flashPrefab.GetComponent<ParticleSystem>().Play();
    }
    
}
