using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactController : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {

        if (other.tag == "Kurage")
        {
            other.GetComponent<KurageMove>().ImpactMove();
        }
    }

}