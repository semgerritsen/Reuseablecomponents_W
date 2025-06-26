using Interfaces;
using UnityEngine;

namespace Movement.inputs
{
    public class ControllerWeaponInput : MonoBehaviour, IWeaponInput
    {
        public bool IsFiring()
        {
            return Input.GetAxis("RightTrigger") > 0.1f;
        }
    }
}