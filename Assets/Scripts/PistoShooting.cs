using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PistoShooting : MonoBehaviour
{
    
    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(x => StartShoot());
        grabInteractable.deactivated.AddListener(x => StopShoot());

        
    }
    public void StartShoot()
    {

    }
    public void StopShoot()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
