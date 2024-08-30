using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOutlineStateSwitch : MonoBehaviour,IStateSwitch
{
    [SerializeField] private Outline objectOutline;
    public void SwitchState(bool state)
    {
        objectOutline.enabled = state;
    }
}
