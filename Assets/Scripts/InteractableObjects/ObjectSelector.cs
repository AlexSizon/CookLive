using System;
using System.Collections;
using System.Collections.Generic;
using InteractableObjects;
using InteractableObjects.Interfaces;
using Player.Interfaces;
using UnityEngine;

public class ObjectSelector : MonoBehaviour, ISelector
{
    private Ray detectingObjectsRay;
    private RaycastHit hitInfo;
    private ISelectable selectedObject;
    private Transform mainCamera;
    public ISelectable SelectedObject => selectedObject;

    private void Start()
    {
        mainCamera = Camera.main.transform;
    }

    private void Update()
    {
        CheckSelectedObject();
    }

    private void CheckSelectedObject()
    {
        if (Physics.Raycast(mainCamera.position, mainCamera.forward, out hitInfo, 2f))
        {
            if (!hitInfo.transform.TryGetComponent<ISelectable>(out var selectable))
            {
                selectedObject?.Deselect();
                selectedObject = null;
                return;
            }
            
            if (selectedObject == selectable) return;

            selectedObject?.Deselect();
            selectedObject = selectable;
            selectedObject.Select();
            return;
        }

        if (selectedObject == null) return;
        selectedObject.Deselect();
        selectedObject = null;
    }
}