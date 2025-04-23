using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Soda")
        {
            GameEvents.current.SetBinTrigger();
        }
    }
}
