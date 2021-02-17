﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField]
    private Transform viewCamera;
    public LayerMask[] LayerToRayCast = new LayerMask[5];
    [SerializeField]
    private float interactionDistance = 5f;
    public RaycastHit? DoRayCasting()
    {
        Ray ray = new Ray(viewCamera.position, viewCamera.forward);
        RaycastHit hit;
        Debug.DrawRay(viewCamera.position, viewCamera.forward);
        foreach (var layer in LayerToRayCast)
        {
            bool hasHit = Physics.Raycast(ray, out hit, interactionDistance, layer);
            if (hasHit)
            {
                return hit;
            }
        }
        return null;
    }

    private void Update()
    {
        //вот тут
        if(Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit Hit = (RaycastHit)DoRayCasting();
            OpenButton openButton = Hit.transform.GetComponentInParent<OpenButton>();
            Key key = Hit.transform.GetComponentInParent<Key>();

            if(key!=null)
            {
                key.OnButtonB();
            }
            if(openButton!=null)
            {
                openButton.OnClickB();
            }
            Debug.Log(Hit.transform.name);
        }

        
        
        
        
        //лок мышки
        if(Input.GetKeyDown(KeyCode.O))
        {
            if(Cursor.lockState == CursorLockMode.Locked)
            Cursor.lockState = CursorLockMode.None;
            else if (Cursor.lockState != CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
