using InteractableObjects.Interfaces;
using UnityEngine;

namespace InteractableObjects
{
    [RequireComponent(typeof(Outline))]
    public class ObjectOutlineSelectable : MonoBehaviour, ISelectable, IGrabbable
    {
        [SerializeField] private Outline objectOutline;
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private Vector3 grabOffset;

        public Transform Transform => transform;
        public Vector3 GrabOffset => grabOffset;

        public void Select() => objectOutline.enabled = true;

        public void Deselect() => objectOutline.enabled = false;

        public void Grab()
        {
            gameObject.layer = IGrabbable.GrabLayer;
            rigidbody.useGravity = false;
            rigidbody.isKinematic = true;
            rigidbody.WakeUp();
        }

        public void Release()
        {
            gameObject.layer = IGrabbable.DefaultLayer;
            rigidbody.isKinematic = false;
            rigidbody.useGravity = true;
            rigidbody.WakeUp();
        }
    }
}