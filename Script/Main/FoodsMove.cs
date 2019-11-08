using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodsMove : MonoBehaviour
{
    KurageHealth kurageHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigd = GetComponent<Rigidbody>();
        kurageHealth = GameObject.FindGameObjectWithTag("Kurage").GetComponent<KurageHealth>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y>=14.0f)
        {
            transform.Translate(0, -0.015f, 0);
        }
        else
        {
            transform.Translate(0, -0.005f, 0);
        }

        if (transform.position.y < -12.5f )
        {
            Destroy(gameObject);
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Kurage")
        {
            Destroy(gameObject);
            kurageHealth.TakeEat();
        }
    }
}
