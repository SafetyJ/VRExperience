using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurbineScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    void Start()
    {
        
        GameEvents.current.eventBinTrigger += TurnOn;
    }

  
    private void TurnOn()
    {
        animator.SetBool("On", true);
    }
    private void TurnOff()
    {
        animator.SetBool("On", false);
    }
}

