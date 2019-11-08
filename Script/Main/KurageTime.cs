using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KurageTime : MonoBehaviour
{
    private Text timeCoutText;

    private double countTime;
    private double spanTime;
    private string timestring;
    private TimeSpan span;

    public void Awake()
    {
        timeCoutText = GameObject.Find("TimeCountText").GetComponent<Text>();
        //アプリ終了時の時間
        timestring = PlayerPrefs.GetString("lastTime", DateTime.Now.ToString());
        //初回起動時の処理
        if (timestring == null || timestring == "")
        {
            timestring = DateTime.Now.ToString();
        }
        //文字列を変換
        DateTime dateTime = DateTime.Parse(timestring);
        //経過時間を求める
        span = DateTime.Now - dateTime;
        //経過時間を時間で取得
        spanTime = span.TotalHours;
       
        string countTimeString = PlayerPrefs.GetString("countText",0.ToString());
        countTime = double.Parse(countTimeString);
        
        countTime += (spanTime/24d);

        timeCoutText.text =countTime.ToString("f0");
    }
   
    // Update is called once per frame
    void Update()
    {
        var counter = 0d;
        counter += Time.deltaTime;
        if (counter > 3600)
        {
            countTime += 1d;
            counter = 0;
        }
    }
    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            PlayerPrefs.SetString("countText", countTime.ToString());
            PlayerPrefs.Save();
        }
        else if (focus)
        {
            Awake();
        }
       
    }
    private void OnDestroy()
    {
        PlayerPrefs.SetString("countText", countTime.ToString());
        PlayerPrefs.Save();
    }



}
