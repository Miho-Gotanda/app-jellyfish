using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonControler : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject namePanel;
    public GameObject optionPanel;
    
    public AudioSource sound;
    public AudioClip se;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    //メニューボタンを押したらポップアップの表示
   public void MenuButtonDown()
    {
        menuPanel.SetActive(true);
        PlaySound();
    }


    public void ModoruButtonDown()
    {
        menuPanel.SetActive(false);
        PlaySound();
    }

     public void PlaySound()
    {
      sound.PlayOneShot(se);
    }

   
    public void KurageKindSceneLoad()
    {
        SceneManager.LoadScene("KurageKindScene");
    }

    public void BackKindSceneLoad()
    {
        SceneManager.LoadScene("BackGroundChose");
    }

    public void NameCansel()
    {
        if (namePanel.activeSelf)
        {
            namePanel.SetActive(false);
        }
    }

    public void OptionCansel()
    {
        if (optionPanel.activeSelf)
        {
            optionPanel.SetActive(false);
        }
    }
}
