using System.Collections;
using System.Collections.Generic;
using InteractableObjects.Interfaces;
using UnityEngine;

public abstract class EquipmentTemplate : MonoBehaviour,IInteractable
{
    [SerializeField] private QteType qteType;
    public void Interact()
    {
        
    }
}
