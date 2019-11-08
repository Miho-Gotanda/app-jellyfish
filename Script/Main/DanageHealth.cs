using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanageHealth : MonoBehaviour
{
    KurageHealth kurageHealth;
    private float timeOut = 60f;
    private float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        kurageHealth = gameObject.GetComponent<KurageHealth>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut)
        {
            kurageHealth.TakeDamage();
            timeElapsed = 0.0f;
        }
        if (kurageHealth.currentHealth < 0)
        {
            kurageHealth.OnDeath();
        }
    }
}
