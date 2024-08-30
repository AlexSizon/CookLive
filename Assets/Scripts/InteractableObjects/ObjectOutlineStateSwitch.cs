using InteractableObjects.Interfaces;
using UnityEngine;

namespace InteractableObjects
{
    public class ObjectOutlineStateSwitch : MonoBehaviour,IStateSwitch
    {
        [SerializeField] private Outline objectOutline;
        public void SwitchState(bool state)
        {
            objectOutline.enabled = state;
        }
    }
}
