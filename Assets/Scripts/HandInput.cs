using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandInput : MonoBehaviour
{

    private OVRGrabber grabber;
    private Gun gun;
    private bool isItemGrabbed;
    private bool isTriggerPressed;

    private void Awake()
    {
        grabber = GetComponent<OVRGrabber>();
    }
    void Update()
    {
        if (isItemGrabbed)
        {
            if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            {
                if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !isTriggerPressed)
                {
                    isTriggerPressed = true;
                    if(gun != null)
                    {
                        gun.TriggerPress();
                    }
                }
                else if(isTriggerPressed)
                {
                    isTriggerPressed = false;
                    gun.TriggerUnPress();
                }
            }
            else 
            { 
                isItemGrabbed = false;
                if (gun != null)
                {
                    gun = null;
                }
            }
        }
        else
        {
            if (OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            {
                if (grabber.grabbedObject != null)
                {
                    isItemGrabbed = true;
                    grabber.grabbedObject.TryGetComponent<Gun>(out gun);
                }
                
            }
        }
    }
}
