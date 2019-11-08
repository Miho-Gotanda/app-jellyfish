using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGround : MonoBehaviour
{

    public GameObject[] back;
    private int backkind;
    private int changeback;
    [SerializeField]
    private GameObject confirmationPanel;
    [SerializeField]
    private GameObject ChosePanel;


    private void Awake()
    {
        changeback = PlayerPrefs.GetInt("Back", 0);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        switch (changeback)
        {
            case 0:
                back[0].SetActive(true);
                back[1].SetActive(false);
                break;
            case 1:
                back[0].SetActive(false);
                back[1].SetActive(true);
                break;
        }
    }
    
   public void Image0()
    {
        backkind = 0;
        ChosePanel.SetActive(false);
        confirmationPanel.SetActive(true);
    }

    public void Image1()
    {
        backkind = 1;
        ChosePanel.SetActive(false);
        confirmationPanel.SetActive(true);
    }

    public void ChengeYes()
    {
        PlayerPrefs.SetInt("Back", backkind);
        SceneManager.LoadScene("Main");
    }

    public void ChengeNo()
    {
        confirmationPanel.SetActive(false);
        ChosePanel.SetActive(true);
    }

    public void ReturnScene()
    {
        SceneManager.LoadScene("Main");
    }

    

}
