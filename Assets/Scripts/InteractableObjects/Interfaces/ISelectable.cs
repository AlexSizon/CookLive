using UnityEngine;

namespace InteractableObjects.Interfaces
{
    public interface ISelectable
    {
        public void Select();
        public void Deselect();
        Transform Transform { get; }
    }
}
