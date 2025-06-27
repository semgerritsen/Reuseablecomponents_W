using Interfaces;
using UnityEngine;

namespace Movement.inputs
{
    public class MouseWeaponInput : MonoBehaviour, IWeaponInput
    {
        //  This script handles mouse input for weapon firing in a Unity game.
        public bool IsFiring()
        {
            // Check if the left mouse button is pressed down.
            return Input.GetMouseButton(0);
        }
    }
}