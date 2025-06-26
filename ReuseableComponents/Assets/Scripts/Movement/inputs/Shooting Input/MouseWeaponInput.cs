using Interfaces;
using UnityEngine;

namespace Movement.inputs
{
    public class MouseWeaponInput : MonoBehaviour, IWeaponInput
    {
        public bool IsFiring()
        {
            return Input.GetMouseButton(0);
        }
    }
}