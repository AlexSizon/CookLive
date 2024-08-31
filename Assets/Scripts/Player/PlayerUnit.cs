using System;
using DG.Tweening;
using DG.Tweening.Core;
using InteractableObjects;
using Player.Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerUnit : MonoBehaviour, ISelector, IInteractor
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private PlayerRotation playerRotation;
        [SerializeField] private Transform rightHand;
        [Range(0, 5)] [SerializeField] private float dropObjectForceModifier = 2f;
        private const string INTERACTABLE_OBJECT_TAG = "InteractableObject";
        private Ray detectingObjectsRay;
        private RaycastHit HitInfo;
        private Collider selectedObjectColider;
        private Rigidbody handChildObject;
        private Transform mainCamera;

        private void Start()
        {
            mainCamera = playerRotation.playerCamera.transform;
        }

        private void Update()
        {
            InputHandler();
        }

        private void FixedUpdate()
        {
            CheckSelectedObject(INTERACTABLE_OBJECT_TAG);
        }

        public void CheckSelectedObject(string objectTag)
        {
            if (Physics.Raycast(mainCamera.position, mainCamera.forward, out HitInfo, 2f))
            {
                if (HitInfo.transform.CompareTag(objectTag))
                {
                    selectedObjectColider = HitInfo.collider;
                    HitInfo.transform.GetComponent<ObjectOutlineStateSwitch>().SwitchState(true);
                }
                if (selectedObjectColider is null) return;
                if (HitInfo.collider.GetInstanceID() != selectedObjectColider.GetInstanceID())
                {
                    selectedObjectColider.GetComponent<ObjectOutlineStateSwitch>().SwitchState(false);
                }
            }
            else if (selectedObjectColider is not null)
            {
                selectedObjectColider.GetComponent<ObjectOutlineStateSwitch>().SwitchState(false);
                selectedObjectColider = null;
            }
        }

        public void PickUp()
        {
            if (selectedObjectColider != null && selectedObjectColider.CompareTag(INTERACTABLE_OBJECT_TAG))
            {
                handChildObject = selectedObjectColider.GetComponent<Rigidbody>();
                handChildObject.transform.SetParent(rightHand);
                handChildObject.rotation = Quaternion.identity;
                handChildObject.useGravity = false;
                //handChildObject.isKinematic = true;
                //handChildObject.WakeUp();
                //handChildObject.localPosition = Vector3.zero;
            }
        }

        public void Drop()
        {
            if (handChildObject is null) return;
            handChildObject.transform.SetParent(null);
            //handChildObject.isKinematic = false;
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