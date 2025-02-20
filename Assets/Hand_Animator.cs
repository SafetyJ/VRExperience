using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Hand_Animator : MonoBehaviour
{

    [SerializeField] private NearFarInteractor nearFarInteractor;
    [SerializeField] private SkinnedMeshRenderer handMesh;
    [SerializeField] private GameObject handArmature;
    [SerializeField] private InputActionReference selectActionRef;
    [SerializeField] private InputActionReference activateActionRef;
    [SerializeField] private Animator handAnimator;

    private static readonly int activateAnim = Animator.StringToHash("Activate");
    private static readonly int selectaAnim = Animator.StringToHash("Select");

    private bool emptyHand;
    private void Awake()
    {
        nearFarInteractor.selectEntered.AddListener(OnGrab);
        nearFarInteractor.selectExited.AddListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log("slected");
        handMesh.enabled = false;
        handArmature.SetActive(false);
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        handMesh.enabled = true;
        handArmature.SetActive(true);
    }

    private IEnumerator DelayedGrab()
    {
        yield return new WaitForSeconds(actionDelay);
        handMesh.enabled = false;
        handArmature.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    
    {
        if (emptyHand)
        {
            handAnimator.SetFloat("Activate", activateActionRef.action.ReadValue<float>());
            handAnimator.SetFloat("Select", selectActionRef.action.ReadValue<float>());
        }
    }
}
