using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KurageDeadControler : MonoBehaviour
{
    public GameObject deadCanvas;
    public GameObject selectCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeadDestroy()
    {
        deadCanvas.SetActive(false);
        selectCanvas.SetActive(true);
    }

    
}
