using UnityEngine;

namespace InteractableObjects.Interfaces
{
    public interface IGrabbable
    {
        public const int DefaultLayer = 0;
        public const int GrabLayer = 31;
        
        public Transform Transform { get; }
        public Vector3 GrabOffset { get; }
        
        public void Grab();
        public void Release();
    }
}