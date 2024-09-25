using System;
using InteractableObjects.Interfaces;
using Player.Interfaces;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerUnit : MonoBehaviour, IInteractor, IGrabber
    {
        private ObjectSelector objectSelector;
        private IGrabbable grabbedObject;
        private Camera camera;
        
        private void Start()
        {
            camera = Camera.main;
        }

        [Inject]
        private void Construct(ObjectSelector objectSelector)
        {
            this.objectSelector = objectSelector;
        }

        private void Update()
        {
            InputHandler();
            UpdatedGrabbedObjectPosition();
        }

        private void UpdatedGrabbedObjectPosition()
        {
            if (grabbedObject == null) return;
            var position = camera.ViewportToWorldPoint(new Vector3(1, 0, camera.nearClipPlane + 0.1f));
            grabbedObject.Transform.position = position + grabbedObject.GrabOffset;
        }

        private void InputHandler()
        {
            if (Input.GetKeyDown(KeyCode.E)) Interact();
            if (Input.GetKeyDown(KeyCode.Mouse0)) PickUp();
            if (Input.GetKeyDown(KeyCode.G)) Drop();
        }
        
        public void Interact()
        {
            if (objectSelector.SelectedObject == null) return;
            if (!objectSelector.SelectedObject.Transform.TryGetComponent<IInteractable>(out var interactable)) return;
            interactable.Interact();
        }

        public void PickUp()
        {
            if (objectSelector.SelectedObject == null) return;
            if (!objectSelector.SelectedObject.Transform.TryGetComponent<IGrabbable>(out var grabbable)) return;
            grabbedObject = grabbable;
            grabbedObject.Grab();
            UpdatedGrabbedObjectPosition();//TODO::Animate
        }

        public void Drop()
        {
            if (grabbedObject == null) return;
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out var hitInfo, 2f))
            {
                grabbedObject.Release();
                grabbedObject.Transform.position = hitInfo.point;//TODO::Animate
                grabbedObject = null;
            }
        }
    }
}