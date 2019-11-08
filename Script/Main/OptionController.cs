using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject optionPanel;
    public AudioMixer audioMixer;
    public Slider bgmSlider;
    public Slider seSlider;
    public GameObject namePanel;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OptionPusshu()
    {
        menuCanvas.SetActive(false);
        optionPanel.SetActive(true);
    }

    //メニューパネルに戻る
    public void OptionReturn()
    {
        optionPanel.SetActive(false);
        menuCanvas.SetActive(true);
    }

    //BGM音量調節
    public float BGMVolume
    {
        set { audioMixer.SetFloat("BGM", bgmSlider.value); } 
    }

    //SE音量調節
    public float SEVolume
    {
        set { audioMixer.SetFloat("SE", seSlider.value); }
    }

    public void NameChange()
    {
        namePanel.SetActive(true);
        optionPanel.SetActive(false);
    }
}
