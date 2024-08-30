using System;
using UnityEngine;

namespace Player
{
    public class PlayerUnit : MonoBehaviour, ISelector
    {
        private const string INTERACTABLE_OBJECT_TAG = "InteractableObject";
        private Ray detectingObjectsRay;
        private RaycastHit HitInfo;
        private Collider selectedObjectColider;

        private void FixedUpdate()
        {
            CheckSelectedObject(INTERACTABLE_OBJECT_TAG);
        }

        public void CheckSelectedObject(string objectTag)
        {
            
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out HitInfo, 5f))
            {
                if (selectedObjectColider is not null)
                {
                    if (HitInfo.collider.GetInstanceID() != selectedObjectColider.GetInstanceID())
                    {
                        selectedObjectColider.GetComponent<ObjectOutlineStateSwitch>().SwitchState(false);
                    }
                }

                Debug.Log(HitInfo.transform.tag);
                if (HitInfo.transform.CompareTag(objectTag))
                {
                    Debug.Log(4);
                    selectedObjectColider = HitInfo.collider;
                    HitInfo.transform.GetComponent<ObjectOutlineStateSwitch>().SwitchState(true);
                }
            }
            else if(selectedObjectColider is not null)
            {
                selectedObjectColider.GetComponent<ObjectOutlineStateSwitch>().SwitchState(false);
                selectedObjectColider = null;
            }
        }
    }
}