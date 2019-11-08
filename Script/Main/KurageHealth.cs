using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class KurageHealth : MonoBehaviour
{
    public float startingHealth=70f; //開始時の体力の値
    private Slider slider;　//現在の体力を示すスライダー
    private Image fillImage;　　//スライダーのImageコンポーネント
    public Color fullHealthColor = Color.green;　//体力が満タンの時の体力バーの色
    public Color zeroHealthColor = Color.red;  //体力が0になったときの体力バーの色

    public TimeSpan span;
    public float currentHealth;　　//現在の体力
    public bool dead;  //体力値が0を下回ったかの判定

    private double spanTime;
    private string timestring;
    private float damage = 0.05f;

    
    

   void Awake() 
     {
        slider = GameObject.Find("Slider").GetComponent<Slider>();
        fillImage = GameObject.Find("Fill").GetComponent<Image>();
        
        //アプリ終了時の時間
        timestring = PlayerPrefs.GetString("lastTime",DateTime.Now.ToString());
        //初回起動時の処理
        if (timestring == null || timestring == "")
        {
            timestring = DateTime.Now.ToString();
        }
        //文字列を変換
        DateTime dateTime = DateTime.Parse(timestring);
        //経過時間を求める
        span = DateTime.Now - dateTime;
        //経過時間を分で取得
        spanTime = span.TotalSeconds;


        var time = spanTime / 60;
        currentHealth = PlayerPrefs.GetFloat("hp", 70f);

        currentHealth -= damage * (float)time;

        SetHealthUI();
        if (currentHealth < 0)
        {
            OnDeath();
        }
        
    }


  


    public void TakeEat()
    {
        currentHealth += 5;
       

        //適切なUi要素に変更
        SetHealthUI();

        
    }

    public void TakeDamage()
    {
        currentHealth -=damage;
        SetHealthUI();
            
    }

    public void SetHealthUI()
    {
        //スライダーに適切な値を設定
        slider.value = currentHealth;
        

        //開始時に対する現在の体力のパーセントに基づいて選択した色でバーを満たす
        fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currentHealth / startingHealth);
    }

    public void OnDeath()
    {
        dead = true;

        SceneManager.LoadScene("DeadScene");
        

    }

    private void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            //スライダーの最大を設定しないとエサを大量に与えた場合そのままの数値がhpに保存されることになり体力が減らなくなる
            if (currentHealth > 100f)
            {
                currentHealth = 100f;
                SetHealthUI();
            }

            PlayerPrefs.SetFloat("hp", currentHealth);


            //現在の時刻を取得
            DateTime now = DateTime.Now;
            //文字列に変換して保存
            PlayerPrefs.SetString("lastTime", now.ToString());

            PlayerPrefs.Save();
        }
        else if (true)
        {
            Awake();
        }
    }
    private void OnDisable()
    {
        if (currentHealth > 100f)
        {
            currentHealth = 100f;
            SetHealthUI();
        }
        PlayerPrefs.SetFloat("hp", currentHealth);
        PlayerPrefs.Save();
        
    }
    

    public void StartHP()
    {
        currentHealth = PlayerPrefs.GetFloat("hp", 70f);
        SetHealthUI();
    }

}
