using InteractableObjects.Interfaces;
using UnityEngine;

namespace InteractableObjects
{
    [RequireComponent(typeof(Rigidbody))]
    public class ObjectOutlineSelectable : MonoBehaviour, ISelectable
    {
        [SerializeField] private Outline objectOutline;

        private Rigidbody _rigidbody;

        public Rigidbody Rigidbody => _rigidbody ??= GetComponent<Rigidbody>();
        
        public void Select() => objectOutline.enabled = true;
        
        public void Deselect() => objectOutline.enabled = false;
    }
}
