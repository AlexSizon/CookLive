using System;
using DG.Tweening;
using DG.Tweening.Core;
using InteractableObjects;
using Player.Interfaces;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerUnit : MonoBehaviour, IInteractor
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerRotation playerRotation;
        [SerializeField] private Transform rightHand;

        private const string INTERACTABLE_OBJECT_TAG = "InteractableObject";
        private Rigidbody handChildObject;
        private ObjectSelector objectSelector;

        [Inject]
        private void Construct(ObjectSelector objectSelector)
        {
            this.objectSelector = objectSelector;
        }

        private void Update()
        {
            InputHandler();
        }

        public void PickUp()
        {
            if (objectSelector.SelectedObject != null)
            {
                //TODO::
                handChildObject = objectSelector.SelectedObject.Rigidbody;
                handChildObject.transform.SetParent(rightHand);
                handChildObject.rotation = Quaternion.identity;
                handChildObject.useGravity = false;
                handChildObject.isKinematic = true;
                handChildObject.WakeUp();
                //handChildObject.localPosition = Vector3.zero;
            }
        }

        public void Drop()
        {
            if (handChildObject is null) return;
            handChildObject.transform.SetParent(null);
            handChildObject.isKinematic = false;
            handChildObject.useGravity = true;
            handChildObject = null;
        }

        private void InputHandler()
        {
            if (Input.GetKey(KeyCode.Mouse0)) PickUp();
            if (Input.GetKey(KeyCode.G)) Drop();
        }
    }
}