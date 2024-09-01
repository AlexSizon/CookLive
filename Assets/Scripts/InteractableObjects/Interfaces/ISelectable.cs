using UnityEngine;

namespace InteractableObjects.Interfaces
{
    public interface ISelectable
    {
        public void Select();
        public void Deselect();
        Rigidbody Rigidbody { get; }
    }
}
