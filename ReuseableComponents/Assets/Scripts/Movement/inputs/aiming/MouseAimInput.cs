using Interfaces;
using UnityEngine;

namespace Movement.inputs
{
    public class MouseAimInput : MonoBehaviour, IAimInput
    {
        public Ray GetAimDirection()
        {
            // Get the mouse position in screen coordinates
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}