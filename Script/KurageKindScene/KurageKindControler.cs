using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KurageKindControler : MonoBehaviour
{
    public GameObject mizukuragePanel;
    public GameObject panel;
    public GameObject okikuragePanel;
    public GameObject mizukurageChangePanel;
    public GameObject okikurageChangePanel;
    // public GameObject takokuragePanel;
    // public GameObject takokurageChangePanel;

    
    private int choseKind;
   
    void Start()
    {
        choseKind=PlayerPrefs.GetInt("choseKurage", 0);
    }
    void Delete()
    {
        PlayerPrefs.DeleteKey("hp");
        PlayerPrefs.DeleteKey("lastTime");
        PlayerPrefs.DeleteKey("countText");
        PlayerPrefs.DeleteKey("Name");
    }
    //水クラゲ詳細を表示する
    public void MizuKurageButton()
    {
        panel.SetActive(false);
        mizukuragePanel.SetActive(true);
    }
    //オキクラゲ詳細を表示する
    public void OkiKurageButton()
    {
        panel.SetActive(false);
        okikuragePanel.SetActive(true);
    }
    /*
    //タコクラゲ詳細を表示する
    public void TakoKurageButton()
    {
        panel.SetActive(false);
        takokuragePanel.SetActive(true);
    }
    */

    //クラゲ一覧画面に戻す
    public void CanselButton()
    {
        mizukuragePanel.SetActive(false);
        panel.SetActive(true);
        okikuragePanel.SetActive(false);
        // takokuragePanel.SetActive(false);
    }

    //メイン画面に戻る
    public void SceneCanselButton()
    {
        SceneManager.LoadScene("Main");
    }
    //水クラゲ選択時の変更
    public void MizuKurageChose()
    {
        Delete();
        choseKind = 0;
        SceneManager.LoadScene("Main");
        PlayerPrefs.SetInt("choseKurage", choseKind);
    }
    //オキクラゲ変更
    public void OkiKurageChose()
    {
        Delete();
        choseKind = 1;
        SceneManager.LoadScene("Main");
        PlayerPrefs.SetInt("choseKurage", choseKind);
    }
    /*
    //タコクラゲ変更
    public void TakoKurageChose()
    {
        Delete();
        choseKind = 2;
        SceneManager.LoadScene("Main");
        PlayerPrefs.SetInt("choseKurage", choseKind);
    }
    */

    public void MizuKurageChangeButton()
    {
        mizukuragePanel.SetActive(false);
        mizukurageChangePanel.SetActive(true);
    }

    public void MizuKurageChangeCanselButton()
    {
        mizukurageChangePanel.SetActive(false);
        panel.SetActive(true);
    }

    public void OkiKurageChangeButton()
    {
        okikuragePanel.SetActive(false);
        okikurageChangePanel.SetActive(true);
    }

    public void OkiKurageChangeCanselButton()
    {
        okikurageChangePanel.SetActive(false);
        panel.SetActive(true);
    }
    /*
    public void TakoKurageChangeButton()
    {
        takokuragePanel.SetActive(false);
        takokurageChangePanel.SetActive(true);
    }

    public void TakoKurageChangeCanselButton()
    {
        takokurageChangePanel.SetActive(false);
        panel.SetActive(true);
    }
    */

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("choseKurage", choseKind);
    }
}
